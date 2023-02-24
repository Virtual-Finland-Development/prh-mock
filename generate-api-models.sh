# Docker command for generating POCOs from Open API specification file

docker run --rm -v "${PWD}:/local" \
    openapitools/openapi-generator-cli generate \
    -i /local/openapi/prh-mock.yaml \
    -g csharp-netcore \
    -o /local \
    --global-property=apiTests=false,modelTests=false,modelDocs=false \
    --additional-properties=packageName=PrhApi.Models.CodeGen,targetFramework=net6.0
