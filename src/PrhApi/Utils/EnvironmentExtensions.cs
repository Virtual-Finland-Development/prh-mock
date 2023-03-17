namespace PrhApi.Utils;

public static class VirtualFinlandEnvironments
{
    private const string Development = "dev";
    private const string Staging = "staging";
    private const string Production = "prod";

    public static bool IsDevelopment(this IHostEnvironment hostEnvironment)
    {
        if (hostEnvironment == null)
        {
            throw new ArgumentNullException(nameof(hostEnvironment));
        }

        return hostEnvironment.IsEnvironment(Development);
    }

    public static bool IsStaging(this IHostEnvironment hostEnvironment)
    {
        if (hostEnvironment == null)
        {
            throw new ArgumentException(nameof(hostEnvironment));
        }
        
        return hostEnvironment.IsEnvironment(Staging);
    }
    
    public static bool IsProduction(this IHostEnvironment hostEnvironment)
    {
        if (hostEnvironment == null)
        {
            throw new ArgumentException(nameof(hostEnvironment));
        }
        
        return hostEnvironment.IsEnvironment(Production);
    }
}
