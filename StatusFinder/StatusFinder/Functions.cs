using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusFinder
{
    public class Functions
    {
        public static string GetStringBetween(string source, string start, string end) // from ezzpify
        {
            int startIndex = source.IndexOf(start);
            if (startIndex != -1)
            {
                int endIndex = source.IndexOf(end, startIndex + 1);
                if (endIndex != -1)
                {
                    return source.Substring(startIndex + start.Length, endIndex - startIndex - start.Length);
                }
            }
            return string.Empty;
        }
    }
}
