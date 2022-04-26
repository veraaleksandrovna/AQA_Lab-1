using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Wrappers.Services.Configuration
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> s_configuration;
        public static IConfiguration Configuration => s_configuration.Value;
        
        
        public static string SliderUrl => Configuration.GetSection("Url").GetSection("Slider").Value;
        public static string TableUrl => Configuration.GetSection("Url").GetSection("Table").Value;
        
        

        public static string BrowserType => Configuration.GetSection("Service").GetSection("BrowserType").Value;
        public static int WaitTimeout => int.Parse( Configuration.GetSection("Service").GetSection("WaitTimeout").Value);

        static Configurator()
        {
            s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json");

            var appSettingFiles = Directory.EnumerateFiles(basePath, "appsettings.*.json");

            foreach (var appSettingFile in appSettingFiles) builder.AddJsonFile(appSettingFile);

            return builder.Build();
        }
    }
}
