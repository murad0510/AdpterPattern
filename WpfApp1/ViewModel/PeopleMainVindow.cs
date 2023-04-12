using CinemaPlus.Commands;
using CinemaPlus.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Helpers;
using WpfApp1.Models;
using WpfApp1.ViewModel.MainWindowViewModel;

namespace WpfApp1.ViewModel.PeopleListWindowViewModel
{
    public class PeopleMainVindow : BaseViewModel
    {
        public RelayCommand SelectionChange { get; set; }


        private Human selectedItem;

        public Human SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Human> people;

        public ObservableCollection<Human> People
        {
            get { return people; }
            set { people = value; OnPropertyChanged(); }
        }

        public PeopleMainVindow()
        {
            SelectionChange = new RelayCommand((a) =>
            {
                Aplication aplication = new Aplication();
                aplication.ReadMethod(SelectedItem.Name);

                Main main = new Main();
                main.Name = SelectedItem.Name;
                main.Surname = SelectedItem.Surname;
                main.Age = SelectedItem.Age;
                main.Speciality = SelectedItem.Speciality;
                MessageBox.Show($"{main.Surname} {main.Surname} {main.Age} {main.Speciality}");


            });
        }

    public void Method(Human human, PeopleListWindow peopleListWindow)
    {
        //People.Add(human);

        People = new ObservableCollection<Human>();
        People.Add(human);
        peopleListWindow.PeopleListBox.DisplayMemberPath = nameof(Human.Name);
        peopleListWindow.PeopleListBox.ItemsSource = People;
    }

}
}
