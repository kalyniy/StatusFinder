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

namespace StatusFinder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnClipboard_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string data = Clipboard.GetText();
                string regex = @"STEAM_\d:\d:\d{1,}";
                Regex ItemRegex = new Regex(regex, RegexOptions.Compiled);
                foreach (Match match in ItemRegex.Matches(data))
                {
                    string steamId = match.ToString(); // STEAM_0:Y:Z
                    Player player = new Player(steamId);
                    string html = Http.Get(player.steamUrl);
                    string nickname = Helper.GetSteamNickname(html);
                    player.nickname = nickname;
                    Debug.WriteLine(player.nickname);
                }
            }
        }
    }
}
