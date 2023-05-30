namespace Roa.Domain;
public static class Configuration
{
    public static bool IsLocalEnvironment() => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Local";
    public static bool IsDevEnvironment() => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
}
