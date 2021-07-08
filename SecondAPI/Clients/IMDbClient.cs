using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using SecondAPI;
using System.Collections.Generic;
using SecondAPI.Models;

namespace SecondAPI.Clients
{
    public class IMDbClient
    {
        public HttpClient _IMDb;


        public async Task<IMDbModelForFilms> GetMovieOrSeries(string query)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://imdb8.p.rapidapi.com/title/find?q={query}"),
                Headers =
                {
                    { "x-rapidapi-key", "1b593720e0mshec2a0097679a778p1cfe6ajsn2ee5b16b11c9" },
                    { "x-rapidapi-host", "imdb8.p.rapidapi.com" },
                },
            };
            string body;
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadAsStringAsync();
            }

            var result = JsonConvert.DeserializeObject<IMDbModelForFilms>(body);
            return result;
        }

        

    }
}
