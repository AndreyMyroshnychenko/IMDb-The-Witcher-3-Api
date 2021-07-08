using System;
using System.Collections.Generic;
namespace SecondAPI.Models
{
    public class IMDbModelForFilms
    {
        public string query { get; set; }
        public List<Results> results { get; set; }
    }

    public class Results
    {
        public Image image { get; set; }
        public int runningTimeInMinutes { get; set; }
        public string title { get; set; }
        public string titleType { get; set; }
        public int year { get; set; }
    }

    public class Image
    {
        public string url { get; set; }
    }
}
