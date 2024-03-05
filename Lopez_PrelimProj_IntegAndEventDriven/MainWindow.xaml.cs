using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lopez_PrelimProj_IntegAndEventDriven
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

        public MainWindow()
        {
            InitializeComponent();
            comboboxDifficulty.Items.Add("Easy");
            comboboxDifficulty.Items.Add("Normal");
            comboboxDifficulty.Items.Add("Hard");
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
            if(diff == 0)
                number = rnd.Next(0, 85) + 1;
            if(diff == 1)
                number = rnd.Next(86, 170) + 1;
            if(diff == 2)
                number = rnd.Next(171, 255) + 1;
            labelBinaryNumber.Content = number.ToString();
            labelScore.Content = score.ToString();
        }

        private void ChangeNumber(int x)
        {
            if (textBox[x] == '0')
                textBox[x] = '1';
            else
                textBox[x] = '0';
            textboxBinaryNumber.Text = "";
            for (int i = 0; i < textBox.Length; i++)
                textboxBinaryNumber.Text += textBox[i];
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
            int query = 0;
            int value = 128;
            for(int x = 0; x < textBox.Length; x++)
            {
                query += int.Parse(textBox[x].ToString()) * value;
                value /= 2;
            }
            if (query == number)
            {
                MessageBox.Show("Correct!");
                score += 5;
                round++;
                if(round < 11)
                    reduction += (4 - diff);
                GenerateNumber();
            }
            else
                MessageBox.Show("Wrong!");
        }

        private void buttonStartGame_Click(object sender, RoutedEventArgs e)
        {
            if(diff == -1 && gameStart == false)
            {
                if (comboboxDifficulty.SelectedItem.ToString() == "Easy")
                {
                    diff = 0;
                    defaulttimer = 60;
                    gameStart = true;
                }
                if (comboboxDifficulty.SelectedItem.ToString() == "Normal")
                {
                    diff = 1;
                    defaulttimer = 45;
                    gameStart = true;
                }
                if (comboboxDifficulty.SelectedItem.ToString() == "Hard")
                {
                    diff = 2;
                    defaulttimer = 30;
                    gameStart = true;
                }
                if (gameStart)
                    GenerateNumber();
            }
        }
    }
}