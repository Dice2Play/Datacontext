using DatacontextProject.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DatacontextProject.ViewModel
{
    public class AddPersonViewModel : ViewModelBase
    {
        public PersonModel person{ get; set; }

        private PersonViewModel _PersonViewModel;

        public ICommand addNewPersonCommand { get; set; }

        public PersonViewModel PersonViewModel
        {
            get { return _PersonViewModel; }
            set { _PersonViewModel = value; }
        }


        public AddPersonViewModel(PersonViewModel pvm)
        {
            this._PersonViewModel = pvm;
            person = new PersonModel();
            addNewPersonCommand = new RelayCommand(addNewPerson);
        }

        public void addNewPerson()
        {
            _PersonViewModel.persons.Add(person);
        }
    }
}
