using CreateYourTour.View;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CreateYourTour.Model
{
    static class EnterModel
    {
        public static TourWindow tourWindow = new TourWindow();
        private static bool tourWindowWasShowed = false;
        public static void Tour_Click()
        {
            if (!tourWindowWasShowed)
            {
                tourWindowWasShowed = true;
                tourWindow.ShowDialog();
            }
            else
            {
                tourWindow = new TourWindow();
                tourWindow.ShowDialog();
            }
        }
        public static void Close_Tour_Window()
        {
            tourWindow.Close();
        }
        private static string whatIsEmpty(string login, string password)
        {
            if (login != "")
            {
                if (password != "")
                {
                    return null;
                }
                else return "Пароль";
            }
            else return "Логин";

        }

        private static bool CheckLogPass(string login, string password, ref string userName, ref string birthday)
        {
            string path = Directory.GetCurrentDirectory();
            string databaseName = @"" + path + "\\Persons.db";
            SQLiteConnection dbConnection = new SQLiteConnection(string.Format("Data Source={0}; Version=3", databaseName));
            dbConnection.Open();
            string sql = string.Format("SELECT Password FROM Persons WHERE Login=\"{0}\"", login);
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            string s = "";
            foreach (DbDataRecord record in reader)
            {
                s = record["Password"].ToString();
            }

            sql = string.Format("SELECT Name FROM Persons WHERE Login=\"{0}\" AND Password=\"{1}\"", login, password);
            command = new SQLiteCommand(sql, dbConnection);
            reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                userName = record["Name"].ToString();
            }

            sql = string.Format("SELECT Birthday FROM Persons WHERE Login=\"{0}\" AND Password=\"{1}\"", login, password);
            command = new SQLiteCommand(sql, dbConnection);
            reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                birthday = record["Birthday"].ToString();
            }

            dbConnection.Close();
    
            return s.Equals(password) ? true : false;
        }

        public static void EnterLogin(string login, string password)
        {
            switch (whatIsEmpty(login, password))
            {
                case ("Пароль"):
                    MessageBox.Show("Пожалуйста заполните поле " + whatIsEmpty(login, password));
                    break;
                case ("Логин"):
                    MessageBox.Show("Пожалуйста заполните поле " + whatIsEmpty(login, password));
                    break;
                case (null):
                    string userName = "";
                    string birthday = "";
                    if (CheckLogPass(login, password, ref userName, ref birthday))
                    {
                        MessageBox.Show("Connect");
                        Ticket.FIO = userName;
                        Ticket.DATE = birthday;
                        Tour_Click();
                        MainModel.Close_Enter_Window();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или Пароль!");
                    }
                    break;
            }
        }
    }
}
