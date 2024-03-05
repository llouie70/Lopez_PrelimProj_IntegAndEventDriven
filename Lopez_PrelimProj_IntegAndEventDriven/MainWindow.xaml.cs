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
        int score = 0;

        public MainWindow()
        {
            InitializeComponent();
            GenerateNumber();
        }

        private void GenerateNumber()
        {
            textboxBinaryNumber.Text = "00000000";
            textBoxBinary = textboxBinaryNumber.Text;
            textBox = new char[textBoxBinary.Length];
            for (int i = 0; i < textBoxBinary.Length; i++)
                textBox[i] = textBoxBinary[i];
            number = rnd.Next(0, 255) + 1;
            labelBinaryNumber.Content = number.ToString();
            labelScore.Content = score.ToString();
        }
        private void button128_Click(object sender, RoutedEventArgs e)
        {
            if (textBox[0] == '0')
                textBox[0] = '1';
            else
                textBox[0] = '0';
            textboxBinaryNumber.Text = "";
            for (int i = 0; i < textBox.Length; i++)
                textboxBinaryNumber.Text += textBox[i];
        }

        private void button64_Click(object sender, RoutedEventArgs e)
        {
            if (textBox[1] == '0')
                textBox[1] = '1';
            else
                textBox[1] = '0';
            textboxBinaryNumber.Text = "";
            for (int i = 0; i < textBox.Length; i++)
                textboxBinaryNumber.Text += textBox[i];
        }

        private void button32_Click(object sender, RoutedEventArgs e)
        {
            if (textBox[2] == '0')
                textBox[2] = '1';
            else
                textBox[2] = '0';
            textboxBinaryNumber.Text = "";
            for (int i = 0; i < textBox.Length; i++)
                textboxBinaryNumber.Text += textBox[i];
        }

        private void button16_Click(object sender, RoutedEventArgs e)
        {
            if (textBox[3] == '0')
                textBox[3] = '1';
            else
                textBox[3] = '0';
            textboxBinaryNumber.Text = "";
            for (int i = 0; i < textBox.Length; i++)
                textboxBinaryNumber.Text += textBox[i];
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            if (textBox[4] == '0')
                textBox[4] = '1';
            else
                textBox[4] = '0';
            textboxBinaryNumber.Text = "";
            for (int i = 0; i < textBox.Length; i++)
                textboxBinaryNumber.Text += textBox[i];
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (textBox[5] == '0')
                textBox[5] = '1';
            else
                textBox[5] = '0';
            textboxBinaryNumber.Text = "";
            for (int i = 0; i < textBox.Length; i++)
                textboxBinaryNumber.Text += textBox[i];
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (textBox[6] == '0')
                textBox[6] = '1';
            else
                textBox[6] = '0';
            textboxBinaryNumber.Text = "";
            for (int i = 0; i < textBox.Length; i++)
                textboxBinaryNumber.Text += textBox[i];
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox[7] == '0')
                textBox[7] = '1';
            else
                textBox[7] = '0';
            textboxBinaryNumber.Text = "";
            for (int i = 0; i < textBox.Length; i++)
                textboxBinaryNumber.Text += textBox[i];
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
                GenerateNumber();
            }
            else
                MessageBox.Show("Wrong!");
        }
    }
}
