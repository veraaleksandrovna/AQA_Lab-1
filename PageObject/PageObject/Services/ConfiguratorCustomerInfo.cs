using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace PageObject.Services;

public class ConfiguratorCustomerInfo
{
    private static readonly Lazy<IConfiguration> s_configuration;
    public static IConfiguration Configuration => s_configuration.Value;
    
    public static string Name => Configuration[nameof(Name)];
    public static string LastName => Configuration[nameof(LastName)];
    public static string ZipCode => Configuration[nameof(ZipCode)];
    
    static ConfiguratorCustomerInfo()
    {
        s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
    }

    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("CustomerInfo.json");

        var dataFiles = Directory.EnumerateFiles(basePath, "CustomerInfo.*.json");

        foreach (var dataFile in dataFiles)
        {
            builder.AddJsonFile(dataFile);
        }

        return builder.Build();
    }
}
