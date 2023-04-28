using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace StringAnalyserWithoutMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        OpenFileDialog _ofd = new();
        private void add_Click(object sender, RoutedEventArgs e)
        {
            _ofd.Filter = "txt files(*.txt)|*.txt";
                if (!_ofd.ShowDialog().HasValue) return;
                StreamReader sr = new StreamReader(_ofd.FileName);
                text.Text = sr.ReadToEnd();
        }

        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {
            int vowels = Regex.Matches(text.Text, @"[йуеаоэяиюeyuioa]", RegexOptions.IgnoreCase).Count;
            int consonants = Regex.Matches(text.Text, @"[zrtpqsdfghjklmwxcvbnцкнгшщзхфвпрлджчсмт]", RegexOptions.IgnoreCase).Count;
            int numbers = Regex.Matches(text.Text, @"[1234567890]", RegexOptions.IgnoreCase).Count;
            int symbols = Regex.Matches(text.Text, "[~`!@№#$%^&*()_+=\\-?:;,./|''{}\"[]", RegexOptions.IgnoreCase).Count;
            statistic.Text = "vowels: " + vowels.ToString() +
                "\tconsonants: " + consonants.ToString() + "\t\tnumbers: " + numbers.ToString() +
                "\tsymbols: " + symbols.ToString();
        }
    }
}
