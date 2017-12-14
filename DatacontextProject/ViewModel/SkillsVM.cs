using DatacontextProject.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DatacontextProject.ViewModel
{
    public class SkillsVM : ViewModelBase
    {
        public const string SkillPropertyName = "skill";

        private RelayCommand<string> _sendNudes;

        public RelayCommand<string> sendNudes
        {
            get { return _sendNudes; }
            set { _sendNudes = value; }
        }

        private double _skill;

        public double skill
        {
            get { return _skill; }
            set {
                _skill = value;
                this.RaisePropertyChanged(SkillPropertyName);
                _sendNudes.RaiseCanExecuteChanged();
            }
        }

        public SkillsVM()
        {
            _sendNudes = new RelayCommand<String>(sendNudesMethod, x =>  skill > 10.0 );
        }

        private void sendNudesMethod(string parameter)
        {
            MessageBox.Show($"Them nudes bro.. {parameter}");
        }
    }
}
