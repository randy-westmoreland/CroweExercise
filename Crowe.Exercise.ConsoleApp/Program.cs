using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http;

namespace Crowe.Exercise.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //var collection = new ServiceCollection();
            //collection.AddHttpClient()
            //var serviceProvider = collection.BuildServiceProvider();

            //serviceProvider.add

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            Console.WriteLine(configuration.GetConnectionString("Storage"));

            var serviceProvider = new ServiceCollection()
                .AddHttpClient()
                .BuildServiceProvider();

            var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();

            var client = httpClientFactory.CreateClient();

            //client.GetAsync()

        }
    }
}