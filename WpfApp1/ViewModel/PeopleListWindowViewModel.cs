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
    public class PeopleList : BaseViewModel
    {
        public RelayCommand SelectionChange { get; set; }
        public RelayCommand Minimize { get; set; }

        public PeopleListWindow PeopleLis { get; set; }


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


        public PeopleList()
        {
            SelectionChange = new RelayCommand((a) =>
            {
                Aplication aplication = new Aplication();

                MainWindowViewMode mainWindowViewMode = new MainWindowViewMode();

                Human human = new Human();

                human.Name = SelectedItem.Name;
                human.Surname = SelectedItem.Surname;
                human.Age = SelectedItem.Age;
                human.Speciality = SelectedItem.Speciality;

                MessageBox.Show($"{human}");
                mainWindowViewMode.IsChangedInformation(human);
            });

            Minimize = new RelayCommand((a) =>
            {
                PeopleLis.WindowState = WindowState.Minimized;
            });
        }

        ObservableCollection<Human> list = new ObservableCollection<Human>();

        public void Method(Human human, PeopleListWindow peopleListWindow)
        {
            list.Add(human);

            People = new ObservableCollection<Human>();
            People = list;

            peopleListWindow.PeopleListBox.DisplayMemberPath = nameof(Human.Name);
            peopleListWindow.PeopleListBox.Items.Add(human);
        }

    }
}
