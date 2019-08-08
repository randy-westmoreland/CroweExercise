using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Net.Http;

namespace Crowe.Exercise.ConsoleApp
{
    /// <summary>
    /// Program Class.
    /// </summary>
    public static class Program
    {
        public static void Main()
        {
            ConfigureBuilder(out IConfigurationRoot configuration);
            ConfigureServices(out HttpClient client);

            configuration.GetSection("");
            client.GetAsync("");
        }

        /// <summary>
        /// Configures the builder.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        private static void ConfigureBuilder(out IConfigurationRoot configuration)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="client">The client.</param>
        private static void ConfigureServices(out HttpClient client)
        {
            var serviceProvider = new ServiceCollection()
                .AddHttpClient()
                .BuildServiceProvider();

            var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            client = httpClientFactory.CreateClient();
        }
    }
}