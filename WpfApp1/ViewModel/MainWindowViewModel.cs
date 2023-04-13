using CinemaPlus.Commands;
using CinemaPlus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Helpers;
using WpfApp1.Models;
using WpfApp1.ViewModel.PeopleListWindowViewModel;

namespace WpfApp1.ViewModel.MainWindowViewModel
{
    public class MainWindowViewMode : BaseViewModel
    {
        public RelayCommand MyJsonRelayCommand { get; set; }
        public RelayCommand MyXmlRelayCommand { get; set; }
        public RelayCommand Save { get; set; }
        public RelayCommand ShowPeopleList { get; set; }

        public Human Human { get; set; }

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

        PeopleListWindow peopleListWindow = new PeopleListWindow();
        public MainWindowViewMode()
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


            Save = new RelayCommand((a) =>
            {
                Human human = new Human();
                human.Name = Name;
                human.Surname = Surname;
                human.Age = Age;
                human.Speciality = Speciality;
                Aplication aplication = new Aplication();

                bool JsonAndXml = false;

                if (tex == "j")
                {
                    App.JsonPeople += $" {human.Name} ";
                    JsonAndXml = true;
                }
                else if (tex == "X")
                {
                    App.XmlPeople += $" {human.Name} ";
                    JsonAndXml = true;
                }
                else
                {
                    MessageBox.Show("Json or Xml");
                    JsonAndXml = false;
                }

                aplication.Start(tex, human);


                if (JsonAndXml)
                {
                    Name = String.Empty;
                    Surname = String.Empty;
                    Age = 0;
                    Speciality = String.Empty;

                    //PeopleList peopleMainVindow = new PeopleList();
                    //peopleMainVindow.Method(human, peopleListWindow);

                    peopleListWindow.PeopleListBox.DisplayMemberPath = nameof(Human.Name);
                    peopleListWindow.PeopleListBox.Items.Add(human);
                }
            });

            ShowPeopleList = new RelayCommand((a) =>
            {
                peopleListWindow.Show();
            });
        }

        public PeopleListWindow MinizeButton()
        {
            return peopleListWindow;
        }

        public void IsChangedInformation(Human human)
        {
            Name = human.Name;
            Surname = human.Surname;
            Age = human.Age;
            Speciality = human.Speciality;
        }
    }
}
