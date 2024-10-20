using MauiApp1.models;
using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;



namespace MauiApp1.ViewModels
{
    public class RegistrationPageViewModel:ViewModelBase
    {

        private string? username;
        private string? userlastname;
        private string? password;
        private DateTime bdate;
        private int age;
        private DateTime today;
        private string? user_error;
        private string? email;
        private string? userphone;   
        private string? password_error;
        private string? age_error;
        // יצירת אובייקט ממחלקת השירותים,
        // שיכלול את כל הפונקציות של המחלקה, עליו נפעיל את כל הבקשות לשרת
        private APIService api_service;
        public RegistrationPageViewModel(APIService api_service)
        {
            // אתחול תאריך הלידה לתאריך הנוכחי
            BDate = DateTime.Now;
            today = DateTime.Now; // אתחול התאריך של היום

            RegistrationCommand = new Command(Register);
            // המחלקה זקוקה לשירות api_service
            // היא תקבל אותו בזכות ההרשמה בBUILDER 
            // שביצענו במחלקת PROGRAM
            // למעשה כל מחלקה שתצטרך את השירות הנ"ל תקבל את אותו אובייקט מוגדר שיצרנו בקובץ פרוגרם (=סינגלטון
            this.api_service = api_service;
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }   
        }
        public string? UserPhone
        {
            get
            {
                return userphone;
            }
            set
            {
                userphone = value;
                OnPropertyChanged(nameof(UserPhone));
            }
        }
        public string UserLastName
        {
            get
            {
                return userlastname;
            }
            set
            {
                userlastname = value;
                OnPropertyChanged(nameof(UserLastName));
            }
        }

        public string UserName
        {
            get { return username; }
            set
            {
                username = value;
                User_Error = ""; // איפוס שגיאת שם המשתמש
                OnPropertyChanged(nameof(UserName));
                // בדיקת תקינות שם המשתמש

                if (!string.IsNullOrEmpty(UserName))

                {
                    if (char.IsDigit(UserName[0]))
                    {
                        User_Error = "!!שם המשתמש לא יכול להתחיל בספרה!!";
                        OnPropertyChanged(nameof(UserName));
                    }
                    else if (UserName.Contains(" "))
                    {
                        User_Error = "!!שם המשתמש לא יכול להכיל רווחים!!";
                        OnPropertyChanged(nameof(UserName));
                    }
                }
            }

        }

        public string? User_Error
        {
            get { return user_error; }
            set
            {
                user_error = value;
                OnPropertyChanged(nameof(User_Error));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        public string? Password
        {
            get { return password; }
            set
            {
                password = value;
                Password_Error = "";
                OnPropertyChanged(nameof(Password));
                if (password != null)
                {
                    bool IsPasswordOk = IsValidPassword(password);
                    if (!IsPasswordOk)
                    {
                        Password_Error = "!!סיסמה חייבת להכיל לפחות אות גדולה אחת ומספר!!";
                    }
                }
            }
        }

        private bool IsValidPassword(string password)
        {
            bool hasUpperCase = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUpperCase = true;
                }
                if (char.IsDigit(c))
                {
                    hasDigit = true;
                }

                if (hasUpperCase && hasDigit)
                {
                    break; // אם מצאנו כבר גם אות גדולה וגם ספרה, אפשר לעצור את הלולאה
                }
            }
            return hasUpperCase && hasDigit;

        }

        public string Password_Error
        {
            get { return password_error; }
            set
            {
                password_error = value;
                OnPropertyChanged(nameof(Password_Error));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        public DateTime Today
        {
            get { return today; }
        }
        public DateTime BDate
        {
            get { return bdate; }
            set
            {
                bdate = value;
                today = DateTime.Now;
                calculateAge();
                OnPropertyChanged("BDate");
                OnPropertyChanged("Age");
            }
        }

        public void calculateAge()
        {
            this.Age = this.Today.Year - this.BDate.Year;
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged(nameof(Age));
                Age_Error = "";
                if (Age < 18)
                {
                    Age_Error = "!!הרשמה מעל גיל 18 בלבד!!";
                }

            }
        }

        public string? Age_Error
        {
            get { return age_error; }
            set
            {
                age_error = value;
                OnPropertyChanged(nameof(Age_Error));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        public bool CanRegister
        {
            get
            {
                if (string.IsNullOrEmpty(User_Error) && string.IsNullOrEmpty(Password_Error) && string.IsNullOrEmpty(Age_Error))
                {
                    if (UserName != null && username != "")
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }

            }
        }
        public ICommand RegistrationCommand
        {
            get; private set;
        }
      
        public async void Register()
        {

            Console.WriteLine("Register Work");
            User user = new User
            {
            Age = Age,
            BDate = BDate,
            UserName = UserName,
            UserPhone = UserPhone,
            UserLastName = UserLastName,
            UserEmail = email,
            ProfilePicture = "anonimuspic.jpg",
            UserPassword = password,
            };
            bool didSucceed = await this.api_service.Register(user);
            await Shell.Current.GoToAsync("///LoginView");

        }
    }
}
