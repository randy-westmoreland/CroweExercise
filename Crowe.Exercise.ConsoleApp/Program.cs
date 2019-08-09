using Crowe.Exercise.Common;
using Crowe.Exercise.Common.Utils;
using Crowe.Exercise.Model.Api;
using Crowe.Exercise.Model.View;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Crowe.Exercise.ConsoleApp
{
    /// <summary>
    /// Program Class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        public static void Main()
        {
            ConfigureBuilder(out AppSettingsConfig appSettings);
            ConfigureServices(out HttpClient client);

            Console.WriteLine(GetMessage(appSettings, client)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult()
                .Message);
        }

        /// <summary>
        /// Configures the builder.
        /// </summary>
        /// <param name="appSettings">The application settings.</param>
        private static void ConfigureBuilder(out AppSettingsConfig appSettings)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Constants.APPSETTINGS, optional: true, reloadOnChange: true);

            appSettings = new AppSettingsConfig();
            var configuration = builder.Build();

            configuration.GetSection(Constants.CROWE_EXERCISE_SETTINGS).Bind(appSettings);
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

        private static async Task<MessageApiModel> GetMessage(AppSettingsConfig appSettings, HttpClient client)
        {
            var endpoint = AppSettings.Get<Uri>(appSettings.GetMessageEndpoint);
            var response = await client.GetAsync(endpoint).ConfigureAwait(false);
            var result = response.Content.ReadAsStringAsync().Result;

            response.Dispose();

            return JsonConvert.DeserializeObject<MessageApiModel>(result);
        }
    }
}