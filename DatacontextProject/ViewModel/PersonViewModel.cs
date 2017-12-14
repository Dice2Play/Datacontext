using DatacontextProject.Model;
using DatacontextProject.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DatacontextProject.ViewModel
{
    public class PersonViewModel : ViewModelBase
    {
        public ObservableCollection<PersonModel> persons { get; set; }

        public ICommand addNewPersonCommand{ get; set; }
            
        public PersonViewModel()
        {
            // Create a list with persons
            persons = new ObservableCollection<PersonModel>();
            persons.Add(new PersonModel { name = "Klaas" });
            persons.Add(new PersonModel { name = "Piet" });
            persons.Add(new PersonModel { name = "Job" });

            addNewPersonCommand = new RelayCommand(addNewPerson);
        }

        private void addNewPerson()
        {
            var window = new AddPerson();
            window.Visibility = System.Windows.Visibility.Visible;
        }
    }
}

