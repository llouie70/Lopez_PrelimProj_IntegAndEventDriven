using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lopez_PrelimProj_IntegAndEventDriven
{
    /// <summary>
    /// Interaction logic for Leaderboard.xaml
    /// </summary>
    public partial class Leaderboard : Window
    {
        public Leaderboard()
        {
            InitializeComponent();
            comboboxDifficulty.Items.Add("Easy");
            comboboxDifficulty.Items.Add("Normal");
            comboboxDifficulty.Items.Add("Hard");
        }

        private List<string> ReadLeaderboard(int num)
        {
            string[] difficulty = { "easy", "normal", "hard" };
            List<string> list = new List<string>();
            if (num > -1)
            {
                while (list.Count < 10)
                {
                    string line = "";
                    using (StreamReader sr = new StreamReader("leaderboard_" + difficulty[num] + ".csv"))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            list.Add(line);
                        }
                    }
                }
            }
            return list;
        }
        private void comboboxDifficulty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listboxNames.Items.Clear();
            List<string> list = new List<string>();
            list = ReadLeaderboard(comboboxDifficulty.SelectedIndex);
            string[] convert = new string[3];
            for (int x = 0; x < list.Count; x++)
            {
                convert = list[x].Split(',');
                listboxNames.Items.Add((listboxNames.Items.Count + 1) + ". " + convert[0] + " - " + convert[1] + " seconds - " + convert[2] + " points");
            }
        }
    }
}