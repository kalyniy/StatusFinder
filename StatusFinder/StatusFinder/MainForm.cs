using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StatusFinder.Settings;
namespace StatusFinder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void btnClipboard_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string data = Clipboard.GetText();
                string regex = @"STEAM_\d:\d:\d{1,}";
                Regex ItemRegex = new Regex(regex, RegexOptions.Compiled);
                MatchCollection list = ItemRegex.Matches(data);
                foreach (Match match in list)
                {
                    string steamId = match.ToString();
                    long id = Helper.GetLongID(steamId);
                    string url = $"{BaseUrl}/v4/search/players?nickname={id}&offset=0&limit=20";
                    try
                    {
                        var request = await Http.GetAsyncFaceit(url);
                        Response r = JsonConvert.DeserializeObject<Response>(request);
                        
                        if (r.items.Length > 0)
                        {
                            foreach (Item item in r.items) // one steam account might have multiple faceit accounts.
                            {
                                List<Game> games = new List<Game>(item.games);
                                var game = games.Where(x => x.name.Equals("csgo")).First();
                                MessageBox.Show($"{item.nickname}, lvl {game.skill_level}");
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}
