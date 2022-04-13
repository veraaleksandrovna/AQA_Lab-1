using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace PageObject.Services;

public static class UsersConfigurator
{
    private static readonly Lazy<IConfiguration> u_configuration;


    static UsersConfigurator()
    {
        u_configuration = new Lazy<IConfiguration>(BuildConfiguration);
    }

    public static IConfiguration Configuration => u_configuration.Value;

    public static string StandardUserName => Configuration[nameof(StandardUserName)];
    public static string LockedOutUserName => Configuration[nameof(LockedOutUserName)];
    public static string ProblemUserName => Configuration[nameof(ProblemUserName)];
    public static string PerformanceGlitchUserName => Configuration[nameof(PerformanceGlitchUserName)];
    public static string Password => Configuration[nameof(Password)];
    public static string FirstName => Configuration[nameof(FirstName)];
    public static string LastName => Configuration[nameof(LastName)];
    public static string PostalCode => Configuration[nameof(PostalCode)];

    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("usersData.json");

        return builder.Build();
    }
}