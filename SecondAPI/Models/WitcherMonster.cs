using System;
using System.Collections.Generic;
namespace SecondAPI.Models
{
    public class WitcherMonster
    {
        public List<Info> creatures { get; set; }
    }

    public class Info
    {
        public int id { get; set; }
        public string name { get; set; }
        public string Class { get; set; }
        public string susceptibility { get; set; }
        public string immunity { get; set; }
        public string image { get; set; }
    }
}
