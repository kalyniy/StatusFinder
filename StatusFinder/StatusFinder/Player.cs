using System;
namespace StatusFinder
{
    public class Player
    {
        public string nickname { get; set; }
        public string steamId { get; set; }
        public long longId { get; set; }
        public string steamUrl { get; set; }
        public string faceitUrl { get; set; }
        public string eseaUrl { get; set; }
        public Player()
        {
        }
        public Player(string steamId)
        {
            this.steamId = steamId;
            this.longId = Helper.GetLongID(steamId);
            this.steamUrl = Helper.GetProfileURL(steamId);
            try
            {
                string html = Helper.GetSteamProfile($"https://steamcommunity.com/profiles/{longId.ToString()}");
                this.nickname = Helper.GetSteamNickname(html);
                this.faceitUrl = GetFaceit(longId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public static string GetFaceit(long longId)
        {
            return "";
        }
        public static string GetEsea()
        {
            return "";
        }
    }
}