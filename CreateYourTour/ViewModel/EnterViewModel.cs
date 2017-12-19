using CreateYourTour.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CreateYourTour.ViewModel
{
    class EnterViewModel : BindableBase
    {
        public DelegateCommand<string[]> LoginCommand { get; }
        public DelegateCommand<int?> BackCommand { get; }
        public EnterViewModel()
        {
            LoginCommand = new DelegateCommand<string[]>(str => {
                if (str != null)
                {
                    EnterModel.EnterLogin(str[0], str[1]);
                }
                else
                {
                    MessageBox.Show("Null!");
                }
            });

            BackCommand = new DelegateCommand<int?>(i => {
                MainModel.Close_Enter_Window();
            });
        }

        

    }
}
