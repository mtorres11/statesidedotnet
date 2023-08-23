using System;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.Extensions.Logging;
using StatesideJokes.Parser;

namespace StatesideJokes.Models
{
    public class DadJokesAsync : DadJokes
    {
        private readonly HttpClient _httpClient;

        public DadJokesAsync(ILogger<DadJokesAsync> logger, JSONParser parser) : base(logger, parser)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "dad-jokes.p.rapidapi.com");
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", API_KEY);
        }

        private async Task<string> MakeRequest(string endpoint)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(new Uri(BASE_URL + endpoint));
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                logger.LogError("Error making request", e);
                throw new Exception("Error making request", e);
            }
        }

        public override async Task<String> GetRandomJoke()
        {
            String jsonResponse = await MakeRequest(RANDOM_JOKE_URL);
            return jsonParser.ParseRandomJokeResponse(jsonResponse);
        }

        public override async Task<int> GetJokeCount()
        {
            string jsonResponse = await MakeRequest(COUNT_JOKES_URL);
            return jsonParser.ParseJokeCountResponse(jsonResponse);
        }
    }
}
