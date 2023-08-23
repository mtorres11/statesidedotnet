using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;

namespace StatesideJokes.Parser
{
    public class JSONParser
    {
        private readonly ILogger<JSONParser> logger;

        public JSONParser(ILogger<JSONParser> logger)
        {
            this.logger = logger;
        }

        public int ParseJokeCountResponse(String jsonResponse)
        {
            try
            {
                JObject jsonObject = JObject.Parse(jsonResponse);
                if (jsonObject.GetValue("success").Value<bool>())
                {
                    return jsonObject.GetValue("body").Value<int>();
                }
                else
                {
                    logger.LogError("Failed to fetch joke count");
                    throw new Exception("Failed to fetch joke count");
                }
            }
            catch (Exception e)
            {
                logger.LogError("Failed to parse JSON response", e);
                throw new Exception("Failed to parse JSON response", e);
            }
        }

        public string ParseRandomJokeResponse(string jsonResponse)
        {
            try
            {
                JObject jsonObject = JObject.Parse(jsonResponse);
                if (jsonObject.GetValue("success").Value<bool>())
                {
                    JArray jokesArray = jsonObject.GetValue("body") as JArray;
                    if (jokesArray != null && jokesArray.Count > 0)
                    {
                        JObject jokeObject = jokesArray[0] as JObject;
                        if (jokeObject != null)
                        {
                            string setup = jokeObject.GetValue("setup").Value<string>();
                            string punchline = jokeObject.GetValue("punchline").Value<string>();
                            return setup + " " + punchline;
                        }
                        else
                        {
                            logger.LogError("No jokes found in the response");
                            throw new Exception("No jokes found in the response");
                        }
                    }
                    else
                    {
                        logger.LogError("No jokes found in the response");
                        throw new Exception("No jokes found in the response");
                    }
                }
                else
                {
                    logger.LogError("Failed to fetch random joke");
                    throw new Exception("Failed to fetch random joke");
                }
            }
            catch (Exception e)
            {
                logger.LogError("Failed to parse JSON response", e);
                throw new Exception("Failed to parse JSON response", e);
            }
        }

    }
}
