using CinemaPlus.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.ViewModel.MainWindowViewModel
{

    public class Main
    {
        public RelayCommand MyJsonRelayCommand { get; set; }
        public RelayCommand MyXmlRelayCommand { get; set; }
        public String Text { get; set; }

        public Main()
        {
            MyJsonRelayCommand = new RelayCommand((a) =>
            {
                MessageBox.Show($"{Text}");

            });

            MyXmlRelayCommand = new RelayCommand((a) =>
            {
                MessageBox.Show("Xml");
            });
        }
    }
}
