using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OWDocuments.Services;
using System;
using System.Threading.Tasks;

namespace OWDocuments
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            // create a new ServiceCollection 
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // create a new ServiceProvider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // overall catch-all to log any exception that might 
            // happen to the console & wait for key input afterwards so we can easily 
            // inspect the issue.  
            try
            {
                // Run IntegrationService 
                await serviceProvider.GetService<IIntegrationService>().Run();
            }
            catch (Exception generalException)
            {
                // log the exception
                var logger = serviceProvider.GetService<ILogger<Program>>();
                logger.LogError(generalException,
                    "An exception happened while running the integration service.");
            }

            Console.ReadKey();


        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add loggers 
            serviceCollection.AddSingleton(LoggerFactory.Create(build=>build
            .AddConsole()
            .AddDebug()));
            

            serviceCollection.AddLogging();

            // register the integration service with a 
            // scoped lifetime
            serviceCollection.AddScoped<IIntegrationService, CRUDService>();

        }
    }
}
