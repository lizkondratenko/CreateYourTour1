using CreateYourTour.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CreateYourTour.Model
{
    static class TourModel
    {
        private static string CreateSQLInquiry(string type)
        {
            return string.Format("SELECT {0} FROM Tours", type);
        }
        
        //Для заполнения стран
        public static List<string> AddItemsToComboBox(string type)
        {
            List<string> listOfItems = new List<string>();

            string path = Directory.GetCurrentDirectory();
            string databaseName = @"" + path + "\\Persons.db";
            SQLiteConnection dbConnection = new SQLiteConnection(string.Format("Data Source={0}; Version=3", databaseName));
            dbConnection.Open();

            string sql = CreateSQLInquiry(type);
            
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                if (!listOfItems.Contains(record[type].ToString()))
                {
                    listOfItems.Add(record[type].ToString());
                }
            }
            dbConnection.Close();
            return listOfItems;
        }

        //Для заполнения городов
        public static List<string> AddItemsToComboBox(string type, string selectedCountry)
        {
            List<string> listOfItems = new List<string>();

            string path = Directory.GetCurrentDirectory();
            string databaseName = @"" + path + "\\Persons.db";
            SQLiteConnection dbConnection = new SQLiteConnection(string.Format("Data Source={0}; Version=3", databaseName));
            dbConnection.Open();

            string sql = CreateSQLInquiry(type) + string.Format(" WHERE Country = \"{0}\"",  selectedCountry); ;

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                if (!listOfItems.Contains(record[type].ToString()))
                {
                    listOfItems.Add(record[type].ToString());
                }
            }
            dbConnection.Close();
            return listOfItems;
        }

        //Для заполнения отелей
        public static List<string> AddItemsToComboBox(string type, string selectedCountry, string selectedCity)
        {
            List<string> listOfItems = new List<string>();

            string path = Directory.GetCurrentDirectory();
            string databaseName = @"" + path + "\\Persons.db";
            SQLiteConnection dbConnection = new SQLiteConnection(string.Format("Data Source={0}; Version=3", databaseName));
            dbConnection.Open();

            string sql = CreateSQLInquiry(type) + string.Format(" WHERE Country = \"{0}\" AND City = \"{1}\"", selectedCountry, selectedCity); ;

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                if (!listOfItems.Contains(record[type].ToString()))
                {
                    listOfItems.Add(record[type].ToString());
                }
            }
            dbConnection.Close();
            return listOfItems;
        }

        //Для заполнения количества людей
        public static int AddItemsToComboBox(string type, string selectedCountry, string selectedCity, string selectedHotel)
        {
            int AmountOfPeople = 0;

            string path = Directory.GetCurrentDirectory();
            string databaseName = @"" + path + "\\Persons.db";
            SQLiteConnection dbConnection = new SQLiteConnection(string.Format("Data Source={0}; Version=3", databaseName));
            dbConnection.Open();

            string sql = CreateSQLInquiry(type) + string.Format(" WHERE Country = \"{0}\" AND City = \"{1}\" AND Hotel = \"{2}\"", selectedCountry, selectedCity, selectedHotel);

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                AmountOfPeople = Convert.ToInt32(record[type].ToString());
            }
            dbConnection.Close();
            return AmountOfPeople;
        }

        //Для заполнения даты отъезда и приезда
        public static DateTime AddItemsToDatePicker(string type, string selectedCountry, string selectedCity, string selectedHotel)
        {
            DateTime date = new DateTime();

            string path = Directory.GetCurrentDirectory();
            string databaseName = @"" + path + "\\Persons.db";
            SQLiteConnection dbConnection = new SQLiteConnection(string.Format("Data Source={0}; Version=3", databaseName));
            dbConnection.Open();

            string sql = CreateSQLInquiry(type) + string.Format(" WHERE Country = \"{0}\" AND City = \"{1}\" AND Hotel = \"{2}\"", selectedCountry, selectedCity, selectedHotel);

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                switch (type)
                {
                    case "DateFrom":
                        date = DateTime.Parse(record[type].ToString());
                        break;
                    case "DateTo":
                        date = DateTime.Parse(record[type].ToString());
                        break;
                }
            }
            dbConnection.Close();
            return date;
        }

        private static bool IsAllFieldsNotNull(string Country, string City, string Hotel, string DateFrom, string DateTo, int AmountOfPeople)
        {
            if ((Country != "") && (City != "") && (Hotel != "") && (AmountOfPeople != 0) && (DateFrom != "") && (DateTo != ""))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static void CreatePersonalTicket(string Country, string City, string Hotel, string DateFrom, string DateTo, int AmountOfPeople)
        {
            if (IsAllFieldsNotNull(Country, City, Hotel, DateFrom, DateTo, AmountOfPeople))
            {
                Ticket ticket = new Ticket(Country, City, Hotel, DateFrom, DateTo, AmountOfPeople);
                ticket.CreateTicketToWordFile();
            }
            else
            {
                MessageBox.Show("Вы заполнили не все поля!");
            }


        }
    }
}