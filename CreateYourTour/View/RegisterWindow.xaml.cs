using CreateYourTour.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CreateYourTour.View
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        
        private void DateRegister_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = new DateTime();
            date = (DateTime)DateRegister.SelectedDate;
            Console.WriteLine(date.ToString("dd.MM.yyyy"));
            tbBirthday.Text = date.ToString("dd.MM.yyyy");
        }
    }
}
