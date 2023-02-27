using System.Collections.Generic;
using System.Text.Json;
using Pulumi;
using Pulumi.Aws.Iam;
using Pulumi.Aws.Lambda;
using Pulumi.Aws.Lambda.Inputs;
using Pulumi.Aws.S3;
using Pulumi.Command.Local;

return await Deployment.RunAsync(() =>
{
    var config = new Config();
    var environment = Deployment.Instance.StackName;
    var projectName = Deployment.Instance.ProjectName;
    var artifactPath = config.Get("artifactPath") ?? "release/";
    var tags = new InputMap<string>
    {
        { "vfd:stack", environment },
        { "vfd:project", projectName }
    };

    var role = new Role($"{projectName}-role-{environment}", new RoleArgs
    {
        AssumeRolePolicy = JsonSerializer.Serialize(new Dictionary<string, object?>
        {
            { "Version", "2012-10-17" },
            {
                "Statement", new[]
                {
                    new Dictionary<string, object?>
                    {
                        { "Action", "sts:AssumeRole" },
                        { "Effect", "Allow" },
                        { "Sid", "" },
                        {
                            "Principal", new Dictionary<string, object?>
                            {
                                { "Service", "lambda.amazonaws.com" }
                            }
                        }
                    }
                }
            }
        })
    });

    // Create an AWS resource (S3 Bucket)
    var bucket = new Bucket($"{projectName}-s3-{environment}", new BucketArgs
    {
        Acl = "private",
        Tags = tags
    });

    var s3BucketPolicy = new Policy($"{projectName}-s3-policy-{environment}", new PolicyArgs
    {
        Description = "Access policy for S3 bucket",
        PolicyDocument = Output.Format($@"{{
                ""Statement"": [
                    {{
                        ""Action"": [
                            ""s3:ListBucket"",
                            ""s3:PutObject"",
                            ""s3:GetObject"",
                            ""s3:DeleteObject""
                        ],
                        ""Effect"": ""Allow"",
                        ""Resource"": [
                            ""{bucket.Arn}"",
                            ""{bucket.Arn}/*""
                        ]
                    }}
                ],
                ""Version"": ""2012-10-17""
            }}
        "),
        Tags = tags
    });

    var s3RolePolicyAttachment = new RolePolicyAttachment($"{projectName}-s3-role-attachment-{environment}",
        new RolePolicyAttachmentArgs
        {
            Role = role.Name,
            PolicyArn = s3BucketPolicy.Arn
        });
    
    var lambdaRolePolicyAttachment = new RolePolicyAttachment($"{projectName}-lambda-role-attachment-{environment}",
        new RolePolicyAttachmentArgs
        {
            Role = role.Name,
            PolicyArn = ManagedPolicy.AWSLambdaBasicExecutionRole.ToString()
        });

    var lambdaFunction = new Function($"{projectName}-{environment}", new FunctionArgs
    {
        Role = role.Arn,
        Runtime = "dotnet6",
        Handler = "PrhApi",
        Timeout = 15,
        MemorySize = 1024,
        Environment = new FunctionEnvironmentArgs
        {
            Variables =
            {
                { "ASPNETCORE_ENVIRONMENT", environment },
                { "Aws:PrhBucketName", bucket.BucketName }
            }
        },
        Code = new FileArchive(artifactPath),
        Tags = tags
    });

    
    var functionUrl = new FunctionUrl($"{projectName}-function-url-{environment}", new FunctionUrlArgs
    {
        FunctionName = lambdaFunction.Arn,
        AuthorizationType = "NONE"
    });

    var command = new Command($"{projectName}-add-permissions-command-{environment}", new CommandArgs
        {
            Create = Output.Format(
                $"aws lambda add-permission --function-name {lambdaFunction.Arn} --action lambda:InvokeFunctionUrl --principal '*' --function-url-auth-type NONE --statement-id FunctionUrlAllowAccess")
        }, new CustomResourceOptions
        {
            DeleteBeforeReplace = true,
            DependsOn = new InputList<Resource> { lambdaFunction }
        }
    );
    

    // Export the name of the bucket
    return new Dictionary<string, object?>
    {
        ["ApplicationUrl"] = functionUrl.FunctionUrlResult,
        ["BucketName"] = bucket.Id,
        ["Tags"] = tags
    };
});
