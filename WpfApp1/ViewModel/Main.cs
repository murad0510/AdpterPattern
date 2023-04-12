using CinemaPlus.Commands;
using CinemaPlus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Helpers;
using WpfApp1.Models;
using WpfApp1.ViewModel.PeopleListWindowViewModel;

namespace WpfApp1.ViewModel.MainWindowViewModel
{

    public class Main : BaseViewModel
    {
        public RelayCommand MyJsonRelayCommand { get; set; }
        public RelayCommand MyXmlRelayCommand { get; set; }
        public RelayCommand Save { get; set; }
        public RelayCommand ShowPeopleList { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value; OnPropertyChanged(); }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged(); }
        }


        private string specilaity;

        public string Speciality
        {
            get { return specilaity; }
            set { specilaity = value; OnPropertyChanged(); }
        }


        public Main()
        {
            string tex = string.Empty;
            MyJsonRelayCommand = new RelayCommand((a) =>
            {
                tex = "j";
            });

            MyXmlRelayCommand = new RelayCommand((a) =>
            {
                tex = "X";
            });

            PeopleListWindow peopleListWindow = new PeopleListWindow();

            Save = new RelayCommand((a) =>
            {
                Human human = new Human();
                human.Name = Name;
                human.Surname = Surname;
                human.Age = Age;
                human.Speciality = Speciality;
                Aplication aplication = new Aplication();

                if (tex == "j")
                {
                    App.JsonPeople += $" {human.Name} ";
                }
                else
                {
                    App.XmlPeople += $" {human.Name} ";
                }

                aplication.Start(tex, human);

                PeopleMainVindow peopleMainVindow = new PeopleMainVindow();
                peopleMainVindow.Method(human, peopleListWindow);

                Name = String.Empty;
                Surname = String.Empty;
                Age = 0;
                Speciality = String.Empty;

                //peopleListWindow.PeopleListBox.DisplayMemberPath = nameof(Human.Name);
                //peopleListWindow.PeopleListBox.Items.Add(human);
            });

            ShowPeopleList = new RelayCommand((a) =>
            {
                peopleListWindow.ShowDialog();
            });

        }
    }
}
