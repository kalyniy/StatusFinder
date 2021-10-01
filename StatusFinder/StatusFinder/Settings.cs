using System;
namespace StatusFinder
{
    public class Settings
    {
        public enum Prefix
        {
            Default,
            CSGO,
            ESEA,
        }
        public static Prefix prefix = Prefix.Default;
        public static string BaseUrl = "https://open.faceit.com/data";
        public static string ApiKey = "";
        public static string GetCurrentPrefix(Prefix prefix)
        {
            string retval = "";
            switch (prefix)
            {
                case Prefix.Default:
                    retval = "STEAM_0:";
                    break;
                case Prefix.CSGO:
                    retval = "STEAM_1:";
                    break;
                case Prefix.ESEA:
                    retval = "1:";
                    break;
                default:
                    retval = "STEAM_0:";
                    break;

            }
            return retval;
        }
    }
}