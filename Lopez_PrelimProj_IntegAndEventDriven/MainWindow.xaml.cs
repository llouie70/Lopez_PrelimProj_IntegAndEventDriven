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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Lopez_PrelimProj_IntegAndEventDriven
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer _dt = null;
        string textBoxBinary = "";
        int number = 0;
        Random rnd = new Random();
        char[] textBox = null;
        int round = 0;
        int score = 0;
        int diff = -1;
        int defaulttimer = 0;
        int timer = 0;
        int reduction = 0;
        bool gameStart = false;
        int playtime = 0;
        string name = "";
        List<string> leaderboard = new List<string>();
        string[] names = new string[11];
        int[] timeTaken = new int[11];
        int[] scores = new int[11];
        Leaderboard leaderboardview = null;
        double percentage = 0;

        public MainWindow()
        {
            InitializeComponent();
            comboboxDifficulty.Items.Add("Easy");
            comboboxDifficulty.Items.Add("Normal");
            comboboxDifficulty.Items.Add("Hard");
            BinaryGame.Background = Brushes.LightGreen;
            textboxBinaryNumber.Background = Brushes.LightGreen;
            if (!File.Exists("leaderboard_easy.csv"))
            {
                using (StreamWriter sw = new StreamWriter("leaderboard_easy.csv"))
                {
                    sw.WriteLine("John,200,100");
                    sw.WriteLine("Jane,180,90");
                    sw.WriteLine("Jonas,160,80");
                    sw.WriteLine("Jan,140,70");
                    sw.WriteLine("Jim,120,60");
                    sw.WriteLine("Jimmy,100,50");
                    sw.WriteLine("Joanne,80,40");
                    sw.WriteLine("Janna,60,30");
                    sw.WriteLine("JJ,40,20");
                    sw.WriteLine("Joanne,20,10");
                }
            }
            if (!File.Exists("leaderboard_normal.csv"))
            {
                using (StreamWriter sw = new StreamWriter("leaderboard_normal.csv"))
                {
                    sw.WriteLine("John,200,200");
                    sw.WriteLine("Jane,180,180");
                    sw.WriteLine("Jonas,160,160");
                    sw.WriteLine("Jan,140,140");
                    sw.WriteLine("Jim,120,120");
                    sw.WriteLine("Jimmy,100,100");
                    sw.WriteLine("Joanne,80,80");
                    sw.WriteLine("Janna,60,60");
                    sw.WriteLine("JJ,40,40");
                    sw.WriteLine("Joanne,20,20");
                }
            }
            if (!File.Exists("leaderboard_hard.csv"))
            {
                using (StreamWriter sw = new StreamWriter("leaderboard_hard.csv"))
                {
                    sw.WriteLine("John,200,300");
                    sw.WriteLine("Jane,180,270");
                    sw.WriteLine("Jonas,160,240");
                    sw.WriteLine("Jan,140,210");
                    sw.WriteLine("Jim,120,180");
                    sw.WriteLine("Jimmy,100,150");
                    sw.WriteLine("Joanne,80,120");
                    sw.WriteLine("Janna,60,90");
                    sw.WriteLine("JJ,40,60");
                    sw.WriteLine("Joanne,20,30");
                }
            }
        }

        private void GenerateNumber()
        {
            timer = defaulttimer - reduction;
            labelTimer.Content = timer.ToString();
            textboxBinaryNumber.Text = "00000000";
            textBoxBinary = textboxBinaryNumber.Text;
            textBox = new char[textBoxBinary.Length];
            for (int i = 0; i < textBoxBinary.Length; i++)
                textBox[i] = textBoxBinary[i];
            if (diff == 0)
                number = rnd.Next(0, 85) + 1;
            if (diff == 1)
                number = rnd.Next(85, 170) + 1;
            if (diff == 2)
                number = rnd.Next(170, 255) + 1;
            labelRoundNumber.Content = (round + 1) + "";
            labelBinaryNumber.Content = number.ToString();
            labelScore.Content = score.ToString();
            BinaryGame.Background = Brushes.LightGreen;
            textboxBinaryNumber.Background = Brushes.LightGreen;
            _dt = new DispatcherTimer();
            _dt.Interval = new TimeSpan(0, 0, 0, 1, 0);
            _dt.Tick += _dt_Tick;
            _dt.Start();
        }

        private void _dt_Tick(object sender, EventArgs e)
        {
            int num = int.Parse(labelTimer.Content.ToString());
            num--;
            playtime++;
            percentage = (double)num / (double)timer;
            if (percentage > 0.75)
                BinaryGame.Background = Brushes.LightGreen;
            if (percentage < 0.75 && percentage > 0.5)
                BinaryGame.Background = Brushes.LightGoldenrodYellow;
            if (percentage < 0.5 && percentage > 0.25)
                BinaryGame.Background = Brushes.Orange;
            if (percentage < 0.25)
                BinaryGame.Background = Brushes.Red;
            textboxBinaryNumber.Background = BinaryGame.Background;
            labelTimer.Content = num.ToString();
            if (num <= 0)
            {
                MessageBox.Show("Game over! Your score is " + score + " with a play time of " + playtime + " seconds.");
                gameStart = false;
                _dt.Stop();
                names[10] = name;
                timeTaken[10] = playtime;
                scores[10] = score;
                SortLeaderboard();
                labelName.Visibility = Visibility.Visible;
                labelDifficulty.Visibility = Visibility.Visible;
                textboxName.Visibility = Visibility.Visible;
                comboboxDifficulty.Visibility = Visibility.Visible;
                buttonStartGame.Visibility = Visibility.Visible;
                buttonLeaderboard.Visibility = Visibility.Visible;
                diff = -1;
                textboxName.Text = "";
                comboboxDifficulty.SelectedItem = null;
            }
        }

        private void ChangeNumber(int x)
        {
            if (textBox == null)
                MessageBox.Show("Pick a difficulty first!");
            else
            {
                if (textBox[x] == '0')
                    textBox[x] = '1';
                else
                    textBox[x] = '0';
                textboxBinaryNumber.Text = "";
                for (int i = 0; i < textBox.Length; i++)
                    textboxBinaryNumber.Text += textBox[i];
            }
        }
        private void button128_Click(object sender, RoutedEventArgs e)
        {
            ChangeNumber(0);
        }

        private void button64_Click(object sender, RoutedEventArgs e)
        {
            ChangeNumber(1);
        }

        private void button32_Click(object sender, RoutedEventArgs e)
        {
            ChangeNumber(2);
        }

        private void button16_Click(object sender, RoutedEventArgs e)
        {
            ChangeNumber(3);
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            ChangeNumber(4);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ChangeNumber(5);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ChangeNumber(6);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ChangeNumber(7);
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            _dt.Stop();
            int query = 0;
            int value = 128;
            for (int x = 0; x < textBox.Length; x++)
            {
                query += int.Parse(textBox[x].ToString()) * value;
                value /= 2;
            }
            if (query == number)
            {
                MessageBox.Show("Correct!");
                score += (5 * (diff + 1));
                round++;
                if (round < 11)
                    reduction += (4 - diff);
                _dt = null;
                GenerateNumber();
            }
            else
            {
                MessageBox.Show("Wrong!");
                _dt.Start();
            }
        }

        private void buttonStartGame_Click(object sender, RoutedEventArgs e)
        {
            if (diff == -1 && gameStart == false)
            {
                name = textboxName.Text;
                round = 0;
                score = 0;
                playtime = 0;
                bool validname = true;
                if (comboboxDifficulty.SelectedItem == null)
                    MessageBox.Show("Pick a difficulty!");
                if (name == "")
                {
                    MessageBox.Show("Write your name!");
                    validname = false;
                }
                if (name != "")
                {
                    for (int x = 0; x < name.Length; x++)
                    {
                        if (name[x] == ',')
                        {
                            MessageBox.Show("Invalid name!");
                            validname = false;
                        }
                    }
                }
                if (comboboxDifficulty.SelectedItem != null && validname == true)
                {
                    labelName.Visibility = Visibility.Collapsed;
                    labelDifficulty.Visibility = Visibility.Collapsed;
                    textboxName.Visibility = Visibility.Collapsed;
                    comboboxDifficulty.Visibility = Visibility.Collapsed;
                    buttonStartGame.Visibility = Visibility.Collapsed;
                    buttonLeaderboard.Visibility = Visibility.Collapsed;
                    if (comboboxDifficulty.SelectedItem.ToString() == "Easy")
                    {
                        diff = 0;
                        defaulttimer = 60;
                        gameStart = true;
                        ReadLeaderboard("easy");
                    }
                    if (comboboxDifficulty.SelectedItem.ToString() == "Normal")
                    {
                        diff = 1;
                        defaulttimer = 45;
                        gameStart = true;
                        ReadLeaderboard("normal");
                    }
                    if (comboboxDifficulty.SelectedItem.ToString() == "Hard")
                    {
                        diff = 2;
                        defaulttimer = 30;
                        gameStart = true;
                        ReadLeaderboard("hard");
                    }
                    if (gameStart)
                        GenerateNumber();
                }
            }
        }

        private void ReadLeaderboard(string difficulty)
        {
            leaderboard.Clear();
            while (leaderboard.Count < 10)
            {
                string line = "";
                using (StreamReader sr = new StreamReader("leaderboard_" + difficulty + ".csv"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        leaderboard.Add(line);
                    }
                }
            }
            for (int x = 0; x < leaderboard.Count; x++)
            {
                string[] split = leaderboard[x].Split(',');
                names[x] = split[0];
                timeTaken[x] = int.Parse(split[1]);
                scores[x] = int.Parse(split[2]);
            }
        }

        private void SortLeaderboard()
        {
            string nameTemp = "";
            int timeTakenTemp = 0;
            int scoreTemp = 0;
            for (int x = 0; x < names.Length; x++)
            {
                for (int y = x + 1; y < names.Length; y++)
                {
                    if (scores[x] < scores[y])
                    {
                        nameTemp = names[x];
                        scoreTemp = scores[x];
                        timeTakenTemp = timeTaken[x];
                        names[x] = names[y];
                        scores[x] = scores[y];
                        timeTaken[x] = timeTaken[y];
                        names[y] = nameTemp;
                        scores[y] = scoreTemp;
                        timeTaken[y] = timeTakenTemp;
                    }
                    if (scores[x] == scores[y])
                    {
                        if (timeTaken[x] > timeTaken[y])
                        {
                            nameTemp = names[x];
                            scoreTemp = scores[x];
                            timeTakenTemp = timeTaken[x];
                            names[x] = names[y];
                            scores[x] = scores[y];
                            timeTaken[x] = timeTaken[y];
                            names[y] = nameTemp;
                            scores[y] = scoreTemp;
                            timeTaken[y] = timeTakenTemp;
                        }
                    }
                }
            }
            string[] listOfDifficulty = { "easy", "normal", "hard" };
            using (StreamWriter sw = new StreamWriter("leaderboard_" + listOfDifficulty[diff] + ".csv"))
            {
                for (int x = 0; x < 10; x++)
                    sw.WriteLine(names[x] + "," + timeTaken[x] + "," + scores[x]);
            }
        }

        private void buttonLeaderboard_Click(object sender, RoutedEventArgs e)
        {
            leaderboardview = new Leaderboard();
            leaderboardview.Show();
        }

        private void comboboxDifficulty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxDifficulty.SelectedItem.ToString() == "Easy")
                labelTimer.Content = "60";
            if (comboboxDifficulty.SelectedItem.ToString() == "Normal")
                labelTimer.Content = "45";
            if (comboboxDifficulty.SelectedItem.ToString() == "Hard")
                labelTimer.Content = "30";
        }
    }
}