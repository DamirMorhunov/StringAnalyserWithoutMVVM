using Microsoft.Win32;
using System.IO;
using System.Windows.Input;

namespace StringAnalyserWithoutMVVM
{
    internal class ViewModel : ViewModelBase
    {
        private OpenFileDialog _ofd = new();
        private string _text = "";
        private string _statistic;
        private RelayCommand _analyse;
        private RelayCommand _add;
        public string Statistic { get => _statistic; set { _statistic = value; OnPropertyChanged(nameof(Statistic)); } }
        public string Text { get => _text; set { _text = value; OnPropertyChanged(nameof(Text)); } }
        private void Vowels(object o)
        {
            Statistic += "vowels: " + Model.VowelsAsync(Text);
        }
        private void Consonants(object o)
        {
            Statistic += "consonants: " + Model.ConsonantsAsync(Text);
        }
        private void Numbers(object o)
        {
            Statistic += "numbers: " + Model.NumbersAsync(Text);
        }
        private void Symbols(object o)
        {
            Statistic += "symbols: " + Model.SymbolsAsync(Text);
        }
        private void Analyse(object o)
        {
            Vowels(o);
            Consonants(o);
            Numbers(o);
            Symbols(o);
        }
        private void Add(object o)
        {
            _ofd.Filter = "txt files(*.txt)|*.txt";
            if (!_ofd.ShowDialog().HasValue) return;
            StreamReader sr = new StreamReader(_ofd.FileName);
            Text = sr.ReadToEnd();
        }
        public ViewModel()
        {
            _analyse = new RelayCommand(Analyse);
            _add = new RelayCommand(Add);
        }
        public ICommand AddCommand => _add;
        public ICommand AnalyseCommand => _analyse;

    }
}
