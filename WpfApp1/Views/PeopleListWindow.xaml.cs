using CinemaPlus.Commands;
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
using System.Windows.Shapes;
using WpfApp1.Models;
using WpfApp1.ViewModel.MainWindowViewModel;
using WpfApp1.ViewModel.PeopleListWindowViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for PeopleListWindow.xaml
    /// </summary>
    public partial class PeopleListWindow : Window
    {
        public PeopleListWindow()
        {
            InitializeComponent();
            PeopleMainVindow peopleMainVindow = new PeopleMainVindow();
            this.DataContext = peopleMainVindow;
        }
    }
}
