using DatacontextProject.Model;
using DatacontextProject.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DatacontextProject.ViewModel
{
    public class AddPersonToEFViewModel : ViewModelBase
    {
        #region Intellisense property names
        private const string _nameProperty = "_name";
        #endregion

        private String _name;

        public String name
        {
            get { return _name; }
            set {
                _name = value;
                RaisePropertyChanged(_nameProperty);
                //_voegPersoonToeButtonMethod.RaiseCanExecuteChanged();
            }
        }

        private EFViewModel _efViewModel;

        private RelayCommand<addPersonToEFWindow> _voegPersoonToeButtonMethod;

        public RelayCommand<addPersonToEFWindow> voegPersoonToeButtonMethod
        {
            get { return _voegPersoonToeButtonMethod; }
        }


        public AddPersonToEFViewModel(EFViewModel efViewModelParam)
        {
            this._efViewModel = efViewModelParam;
            //_voegPersoonToeButtonMethod = new RelayCommand<addPersonToEFWindow>(AddPerson, (x) => name != null);
            _voegPersoonToeButtonMethod = new RelayCommand<addPersonToEFWindow>(AddPerson);
        }

        private void AddPerson(addPersonToEFWindow obj) 
        {
            try
            {

                using (var context = new DC_DatabaseEntities())
                {
                    context.PersonTables.Add(new PersonTable { Name = this.name });
                    context.SaveChanges();
                }


                _efViewModel.EF_Data.Add(new PersonModel { name = this.name });
                obj.Hide();
            }

            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
