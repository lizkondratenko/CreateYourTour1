using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CreateYourTour.Model
{
    static class RegisterModel
    {
        private static string whatIsEmpty(string FIO, string Birthday, string Pasport, string Login, string Password)
        {
            if (FIO != "")
            {
                if (Birthday != "")
                {
                    if (Pasport != "")
                    {
                        if (Login != "")
                        {
                            if (Password != "")
                            {
                                return null;
                            }
                            else return "Пароль";
                        }
                        else return "Логин";
                    }
                    else return "Паспортные данные";
                }
                else return "Дата рождения";
            }
            else return "ФИО";
        }

        private static string IsDataOk(string Pasport, string Login, string Password)
        {
            if (Pasport.Length >= 10)
            {
                if (Login.Length >= 6)
                {
                    if (Password.Length >= 6)
                    {
                        return null;
                    }
                    else return "Пароль";
                }
                else return "Логин";
            }
            else return "Паспортные данные";
        }

        public static void Register_Click(string FIO, string Birthday, string Pasport, string Login, string Password)
        {
            switch (whatIsEmpty(FIO, Birthday, Pasport,  Login,  Password))
            {
                case ("Пароль"):
                    MessageBox.Show("Пожалуйста заполните поле Пароль");
                    break;
                case ("Логин"):
                    MessageBox.Show("Пожалуйста заполните поле Логин");
                    break;
                case ("Паспортные данные"):
                    MessageBox.Show("Пожалуйста заполните поле Паспортные данные");
                    break;
                case ("Дата рождения"):
                    MessageBox.Show("Пожалуйста заполните поле Дата рождения");
                    break;
                case ("ФИО"):
                    MessageBox.Show("Пожалуйста заполните поле ФИО");
                    break;
                case (null):
                    switch (IsDataOk(Pasport, Login, Password))
                    {
                        case ("Паспортные данные"):
                            MessageBox.Show("Поле Паспортные данные должно содержать не менее 10 символов!");
                            break;
                        case ("Логин"):
                            MessageBox.Show("Поле Логин должно содержать не менее 6 символов!");
                            break;
                        case ("Пароль"):
                            MessageBox.Show("Поле Пароль должно содержать не менее 6 символов!");
                            break;
                        case (null):
                            Account account = new Account(FIO, Birthday, Pasport, Login, Password);
                            MainModel.Close_Register_Window();
                            account.AddToDataBase();
                            break;
                    }
                    break;
            }
        }
    }
}
