using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecondAPI.Clients;
using SecondAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class M_and_S_Controller : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<M_and_S_Controller> _logger;
        private readonly IMDbClient _IMDbClient;
        private readonly WitcherClient _witcher;

        public M_and_S_Controller(ILogger<M_and_S_Controller> logger, IMDbClient client, WitcherClient witcher)
        {
            _logger = logger;
            _IMDbClient = client;
            _witcher = witcher;
        }

        [HttpGet("title")]
        public async Task<IMDbModelForFilms> GetFilm([FromQuery] string query)
        {
            IMDbModelForFilms films = await _IMDbClient.GetMovieOrSeries(query);
            return films;
        }

        [HttpGet("name")]
        public async Task<List<WitcherCharacter>> GetByName([FromQuery] string name)
        {
            List<WitcherCharacter> character = await _witcher.GetCharacterByName(name);
            return character;
        }

        [HttpGet("creatureName")]
        public async Task<List<Info>> GetCreatureByName([FromQuery] string name)
        {
            List<Info> monster = await _witcher.GetMonsterByName(name);
            return monster;
        }

        [HttpGet("questName")]
        public async Task<List<QuestInfo>> GetQuest(string name)
        {
            List<QuestInfo> quest = await _witcher.GetQuestByName(name);
            return quest;
        }
    }
}
