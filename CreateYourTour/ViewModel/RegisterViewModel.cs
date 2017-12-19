using CreateYourTour.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CreateYourTour.ViewModel
{
    class RegisterViewModel : BindableBase
    {
        public RegisterViewModel()
        {
            RegisterCommand = new DelegateCommand<string[]>(str => {
                if (str != null)
                {
                    RegisterModel.Register_Click(str[0], str[1], str[2], str[3], str[4]);

                }
                else
                {
                    MessageBox.Show("Null!");
                }

            });
        }

        public DelegateCommand<string[]> RegisterCommand { get; }
          
    }
}
