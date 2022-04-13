using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace AlertsWaits.Services;

public static class Configurator
{
    private static readonly Lazy<IConfiguration> SConfiguration;
    public static IConfiguration Configuration => SConfiguration.Value;
    public static string? BrowserType => Configuration[nameof(BrowserType)];
    public static int WaitTimeout => int.Parse(Configuration[nameof(WaitTimeout)]);
    public static string HerokuappUrl => Configuration[nameof(HerokuappUrl)];
    public static string CatalogOnlinerUrl => Configuration[nameof(CatalogOnlinerUrl)];
    public static string VkUrl => Configuration[nameof(VkUrl)];
    public static string TwitterUrl => Configuration[nameof(TwitterUrl)];
    public static string FacebookUrl => Configuration[nameof(FacebookUrl)];

    static Configurator()
    {
        SConfiguration = new Lazy<IConfiguration>(BuildConfiguration);
    }

    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json");

        var appSettingFiles = Directory.EnumerateFiles(basePath, "appsettings.*.json");

        foreach (var appSettingFile in appSettingFiles)
        {
            builder.AddJsonFile(appSettingFile);
        }

        return builder.Build();
    }
}
