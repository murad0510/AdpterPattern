using CinemaPlus.Commands;
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

    public class Main
    {
        public RelayCommand MyJsonRelayCommand { get; set; }
        public RelayCommand MyXmlRelayCommand { get; set; }
        public RelayCommand Save { get; set; }
        public RelayCommand ShowPeopleList { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Speciality { get; set; }

        public Human People { get; set; }

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
                    App.XmlPeople+= $" {human.Name} ";
                }

                aplication.Start(tex, human);

                People = human;

                peopleListWindow.PeopleListBox.DisplayMemberPath = nameof(Human.Name);
                peopleListWindow.PeopleListBox.Items.Add(human);
            });

            ShowPeopleList = new RelayCommand((a) =>
            {
                peopleListWindow.ShowDialog();
            });

        }
    }
}
