using CreateYourTour.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateYourTour.ViewModel
{
    class MainViewModel : BindableBase
    {
        public DelegateCommand<string> EnterCommand { get; }
        public DelegateCommand<string> RegisterCommand { get; }

        public MainViewModel()
        {
            EnterCommand = new DelegateCommand<string>(str => {
                MainModel.Enter_Click();
            });
            RegisterCommand = new DelegateCommand<string>(str => {
                MainModel.Register_Click();
            });
        }        
    }
}
