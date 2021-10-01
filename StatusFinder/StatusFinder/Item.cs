using System;
namespace StatusFinder
{
    public class Response
    {
        public Item[] items { get; set; }

        public int start { get; set; }
        public int end { get; set; }

    }
    public class Item
    {
        public string player_id { get; set; }
        public string nickname { get; set; }
        public string status { get; set; }
        public Game[] games { get; set; }
        public string country { get; set; }
        public bool verified { get; set; }
        public string avatar { get; set; }
    }
    public class Game
    {
        public string name { get; set; }
        public string skill_level { get; set; }
    }
}