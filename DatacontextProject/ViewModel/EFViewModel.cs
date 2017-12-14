using DatacontextProject.Model;
using DatacontextProject.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DatacontextProject.ViewModel
{
    public class EFViewModel : ViewModelBase
    {
        public ObservableCollection<PersonModel> EF_Data { get; set; }
        
        public RelayCommand<EFViewModel> addNewPerson { get; set; }
        

        public EFViewModel()
        {
            refreshDataInDatagrid();
            addNewPerson = new RelayCommand<EFViewModel>(addNewPersonMethod);
        }

        private void addNewPersonMethod(EFViewModel obj)
        {
            var window = new addPersonToEFWindow();
            window.Visibility = System.Windows.Visibility.Visible;            
        }


        void refreshDataInDatagrid()
        {
            using (var context = new DC_DatabaseEntities())
            {
                var persons = context.PersonTables.ToList();
                EF_Data = new ObservableCollection<PersonModel>(persons.Select(x => new PersonModel { name = x.Name }));
            }
        }


    }
}
