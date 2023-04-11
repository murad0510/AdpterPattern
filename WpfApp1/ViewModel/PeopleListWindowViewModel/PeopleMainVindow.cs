using CinemaPlus.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Helpers;
using WpfApp1.Models;

namespace WpfApp1.ViewModel.PeopleListWindowViewModel
{
    public class PeopleMainVindow
    {
        public RelayCommand SelectionChange { get; set; }
        public Human SelectedItem { get; set; }

        public PeopleMainVindow()
        {

            SelectionChange = new RelayCommand((a) =>
            {
                Aplication aplication = new Aplication();
                aplication.ReadMethod(SelectedItem.Name);
                //MessageBox.Show($"{SelectedItem.Name}");
            });
        }
    }
}
