using Microsoft.Extensions.Logging;
using StatesideJokes.Parser;

namespace StatesideJokes.Models
{
    public abstract class DadJokes
    {
        protected readonly JSONParser jsonParser;
        protected readonly ILogger<DadJokes> logger;

        protected const String BASE_URL = "https://dad-jokes.p.rapidapi.com/";
        protected const String RANDOM_JOKE_URL = "random/joke";
        protected const String COUNT_JOKES_URL = "joke/count";
        protected const String API_KEY = "479d27064emshc531da2ecb0c5b7p1827a2jsnc864c0abe0c4";

        public DadJokes(ILogger<DadJokes> logger, JSONParser parser)
        {
            this.logger = logger;
            jsonParser = parser;
        }

        public abstract Task<String> GetRandomJoke();

        public abstract Task<int> GetJokeCount();
    }
}
