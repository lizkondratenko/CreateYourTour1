using CreateYourTour.Model;
using CreateYourTour.View;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CreateYourTour.ViewModel
{
    

    class TourViewModel : BindableBase
    {
        public DelegateCommand<string[]> CreateTourCommand { get; }
        public static IList<string> AvailableCounties { get; private set; }
        public static IList<string> AvailableCities { get; private set; }
        public static IList<string> AvailableHotels { get; private set; }
        public static IList<string> AvailableAmountOfPeople { get; private set; }


        private string selectedCountry;
        public string SelectedCountry
        {
            get { return selectedCountry; }
            set
            {
                selectedCountry = value;
                EnterModel.tourWindow.cbHotel.Items.Clear();
                EnterModel.tourWindow.cbHotel.IsEnabled = false;

                EnterModel.tourWindow.cbAmountOfPeople.Items.Clear();
                EnterModel.tourWindow.cbAmountOfPeople.IsEnabled = false;

                EnterModel.tourWindow.cbCity.Items.Clear();
                EnterModel.tourWindow.cbCity.IsEnabled = true;

                EnterModel.tourWindow.DateFrom.Text = "";
                EnterModel.tourWindow.DateTo.Text = "";
                EnterModel.tourWindow.DateTo.IsEnabled = false;
                EnterModel.tourWindow.DateTo.IsEnabled = false;

                foreach (string s in TourModel.AddItemsToComboBox("City", selectedCountry))
                {
                    EnterModel.tourWindow.cbCity.Items.Add(s);
                }
            }
        }

        private string selectedCity;
        public string SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;

                EnterModel.tourWindow.cbAmountOfPeople.Items.Clear();
                EnterModel.tourWindow.cbAmountOfPeople.IsEnabled = false;

                EnterModel.tourWindow.cbHotel.Items.Clear();
                EnterModel.tourWindow.cbHotel.IsEnabled = true;

                EnterModel.tourWindow.DateFrom.Text = "";
                EnterModel.tourWindow.DateTo.Text = "";
                EnterModel.tourWindow.DateFrom.IsEnabled = false;
                EnterModel.tourWindow.DateTo.IsEnabled = false;

                foreach (string s in TourModel.AddItemsToComboBox("Hotel", selectedCountry, selectedCity))
                {
                    EnterModel.tourWindow.cbHotel.Items.Add(s);
                }
            }
        }

        private string selectedHotel;
        public string SelectedHotel
        {
            get { return selectedHotel; }
            set
            {
                selectedHotel = value;
                EnterModel.tourWindow.cbAmountOfPeople.Items.Clear();
                EnterModel.tourWindow.cbAmountOfPeople.IsEnabled = true;
                EnterModel.tourWindow.DateFrom.IsEnabled = true;
                for (int i = 1; i <= Convert.ToInt32(TourModel.AddItemsToComboBox("AmountOfPeople", selectedCountry, selectedCity, selectedHotel)); i++)
                {
                    EnterModel.tourWindow.cbAmountOfPeople.Items.Add(i);
                }
                EnterModel.tourWindow.DateFrom.DisplayDateStart = TourModel.AddItemsToDatePicker("DateFrom", selectedCountry, selectedCity, selectedHotel);
                EnterModel.tourWindow.DateFrom.DisplayDateEnd = TourModel.AddItemsToDatePicker("DateTo", selectedCountry, selectedCity, selectedHotel);
                EnterModel.tourWindow.DateTo.DisplayDateEnd = TourModel.AddItemsToDatePicker("DateTo", selectedCountry, selectedCity, selectedHotel);
            }
        }

        private DateTime selectedDateFrom;
        public DateTime SelectedDateFrom
        {
            get { return selectedDateFrom; }
            set
            {
                selectedDateFrom = value;
                EnterModel.tourWindow.DateTo.Text = "";
                EnterModel.tourWindow.DateTo.IsEnabled = true;

                EnterModel.tourWindow.DateTo.DisplayDateStart = selectedDateFrom;
            }
        }

        private DateTime selectedDateTo;
        public DateTime SelectedDateTo
        {
            get { return selectedDateTo; }
            set { selectedDateTo = value; }
        }

       
        public TourViewModel()
        {
            CreateTourCommand = new DelegateCommand<string[]>(str =>
            {
                if ((str[0] != "") && (str[1] != "") && (str[2] != "") && (str[3] != "") && (str[4] != "") && (str[5] != ""))
                {
                    TourModel.CreatePersonalTicket(str[0], str[1], str[2], str[3] , str[4], Convert.ToInt32(str[5]));
                    EnterModel.Close_Tour_Window();
                }
                else
                {
                    MessageBox.Show("Вы заполнили не все поля!");
                }
            });

            AvailableCounties = TourModel.AddItemsToComboBox("Country");



        }

    }
}
