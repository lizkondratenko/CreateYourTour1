using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace CreateYourTour.Model
{
    class Account
    {
        private string name;
        private string date;
        private string pasportData;
        private string login;
        private string password;

        public Account(string name, string date, string pasportData, string login, string password)
        {
            this.name = name;
            this.date = date;
            this.pasportData = pasportData;
            this.login = login;
            this.password = password;
        }


        public override string ToString()
        {
            return this.name + " " + this.date + " " + this.pasportData + " " + this.login + " " + this.password;
        }

        private string CreateSQLInquiry(string tableName, string type)
        {
            if (type == "insert")
            {
                return string.Format("{5} into {6} (Name, Birthday, Pasport, Login, Password) values (\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\")", this.name, this.date, this.pasportData, this.login, this.password, type, tableName);
            }
            else
            {
                return null;
            }
           
        }

        public void AddToDataBase()
        {
            string path = Directory.GetCurrentDirectory();
            string databaseName = @"" + path + "\\Persons.db";
            SQLiteConnection dbConnection = new SQLiteConnection(string.Format("Data Source={0}; Version=3", databaseName));
            dbConnection.Open();
            string sql = this.CreateSQLInquiry("Persons", "insert");
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            dbConnection.Close();
        }
    }
}
