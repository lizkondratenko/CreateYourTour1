using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
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

using CreateYourTour.Model;

namespace CreateYourTour.View
{
    /// <summary>
    /// Логика взаимодействия для TourWindow.xaml
    /// </summary>
    public partial class TourWindow : System.Windows.Window
    { 
        public TourWindow()
        {
            InitializeComponent();

            tblTourIntro.Text = "Здравствуйте " + Ticket.FIO + "! Подберите себе лучший тур.";
        }
    }
}
