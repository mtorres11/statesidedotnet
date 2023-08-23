using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StatesideJokes.Models;
using StatesideJokes.Parser;

namespace StatesideJokesApp
{
    class CLIApp
    {
        /*static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder =>
                {
                    builder.AddConsole(options =>
                    {
                        options.LogToStandardErrorThreshold = LogLevel.Information;
                    });
                })
                .BuildServiceProvider();

            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

            var jsonParser = new JSONParser(serviceProvider.GetRequiredService<ILogger<JSONParser>>()); 
            var dadJokesAsync = new DadJokesAsync(serviceProvider.GetRequiredService<ILogger<DadJokesAsync>>(), jsonParser); 

            try
            {
                // Call GetJokeCount and GetRandomJoke methods
                int jokeCount = await dadJokesAsync.GetJokeCount();
                logger.LogInformation($"Joke count: {jokeCount}");

                string randomJoke = await dadJokesAsync.GetRandomJoke();
                logger.LogInformation($"Random joke: {randomJoke}");
            }
            catch (Exception ex)
            {
                logger.LogError($"An error occurred: {ex.Message}");
            }

            Console.ReadKey();
        }*/
    }
}
