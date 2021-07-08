using System;
using System.Collections.Generic;
namespace SecondAPI.Models
{
    public class WitcherCharacter
    {
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string race { get; set; }
        public string profession { get; set; }
        public string image { get; set; }
    }
    public class Character
    {
        public List<WitcherCharacter> character { get; set; }
    }
}
