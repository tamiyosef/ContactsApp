using System;
using MauiApp1.models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.Services;

using System.Windows.Input;
using System.Diagnostics;

namespace MauiApp1.ViewModels
{
    public class LoginPageViewModel : ViewModelBase

    {
        private string? useremail;
        private string? password;
        private APIService api_service;


        public LoginPageViewModel(APIService api_service)
        {

            LoginCommand = new Command(login);
            this.api_service = api_service;
        }


        public string? UserEmail
        {
            get { return useremail; }

            set { useremail = value; }
        }

        public string? Password
        {
            get { return password; }

            set { password = value; }
        }

        public ICommand LoginCommand
        {
            get; private set;
        }

        public async void login()
        { 
            LoginInfo loginInfo = new LoginInfo();
            loginInfo.Email = UserEmail;
            loginInfo.Password = Password;
            User? user = await this.api_service.Login(loginInfo);
            if (user != null)
            {
                await Shell.Current.GoToAsync("///ContactsPageView");
            }
            else
            {
                Debug.WriteLine("Login failed");
            }

                

            
        }


    }
} 



