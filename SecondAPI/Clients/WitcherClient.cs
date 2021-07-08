using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using SecondAPI.Models;
namespace SecondAPI.Clients
{
    public class WitcherClient
    {
        private HttpClient _theWitcher;
        private static string _address;

        public WitcherClient()
        {
            _address = Constants.address;
            _theWitcher = new HttpClient();
            _theWitcher.BaseAddress = new Uri(_address);
        }
        public async Task<List<WitcherCharacter>> GetCharacterByName(string name)
        {
            var response = await _theWitcher.GetAsync($"/api/characters/name/{name}");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<WitcherCharacter>>(content);
            return result;
        }

        public async Task<List<Info>> GetMonsterByName(string name)
        {
            var response = await _theWitcher.GetAsync($"/api/creatures/name/{name}");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<Info>>(content);
            return result;
        }

        public async Task<List<QuestInfo>> GetQuestByName(string name)
        {
            var response = await _theWitcher.GetAsync($"/api/quests/name/{name}");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<QuestInfo>>(content);
            return result;
        }
    }
}