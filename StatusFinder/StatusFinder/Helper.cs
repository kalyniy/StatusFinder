using System;
using static StatusFinder.Settings;
namespace StatusFinder
{
    public class Helper
    {
        public static long GetLongID(string steamId)
        {
            long id = 0;
            string[] parts = steamId.Split(':');
            long y = Convert.ToInt64(parts[1]);
            long z = Convert.ToInt64(parts[2]);

            id = 76561197960265728 + (2 * z + y);
            return id;
        }
        public static string GetSteamID(Prefix prefix, long longId)
        {
            long reverse = longId - 76561197960265728;
            int y = 0;
            if (reverse % 2 == 1)
            {
                y = 1;
            }
            long z = reverse / 2;
            return $"{Settings.GetCurrentPrefix(prefix)}:{y}:{z}";
        }
        public static string GetProfileURL(string steamId)
        {
            long id = GetLongID(steamId);
            return $"https://steamcommunity.com/profiles/{id}";
        }
        public static string GetSteamProfile(string url)
        {
            try
            {
                string html = Http.Get(url);
                return html;
            }
            catch
            {
                return "";
            }
        }
        public static string GetSteamNickname(string html)
        {
            string tag = Functions.GetStringBetween(html, "<title>", "</title>");
            //<title>Steam Community :: skullzor</title>
            return tag.Replace("Steam Community :: ", "");


        }
    }
}