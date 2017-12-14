/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:DatacontextProject"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace DatacontextProject.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        private PersonViewModel _PersonView;

        public PersonViewModel PersonView
        {
            get
            {
                if(_PersonView == null)
                { _PersonView = new PersonViewModel(); }

                return _PersonView;
            }
        }

        private AddPersonViewModel _AddPersonView;

        public AddPersonViewModel AddPersonView
        {
            get { return new AddPersonViewModel(_PersonView); }
        }

        private SkillsVM _skillsView;

        public SkillsVM skillsView
        {
            get {
                    if(_skillsView == null)
                    {
                        _skillsView = new SkillsVM();
                    }

                return _skillsView;
            }
        }

        private EFViewModel _EF_VIEW;

        public EFViewModel EF_VIEW
        {
            get
            {
                if(_EF_VIEW == null) { _EF_VIEW = new EFViewModel(); }

                return _EF_VIEW;
            }
        }

        private AddPersonToEFViewModel _AddPersonToEFViewModel;

        public AddPersonToEFViewModel AddPersonToEFViewModel
        {
            get
            {     
                return new AddPersonToEFViewModel(_EF_VIEW);
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}