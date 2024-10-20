

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.models
{
    public class User : ObservableObject
    {
        private string? username;
        private string? lastName;
        private string? userphone;
        private string? email;
        private string? password;
        private DateTime bdate;
        private int? age;
        private DateTime today;
        private string? profilepicture;

        public User()
        {
            this.today = DateTime.Now;
            this.bdate = today;
            
        }

    
        public string UserLastName
        {
            get { return this.lastName; }
            set { lastName = value; OnPropertyChanged("name"); }
        }

        public string ProfilePicture
        {
            get { return profilepicture; }
            set { profilepicture = value; OnPropertyChanged(nameof(ProfilePicture)); }
        }
     
        public string UserName
        {
            get { return username; }    
            set { username = value; OnPropertyChanged(nameof(UserName)); } //שם משתמש
        }

        public string UserEmail
        {
            get { return email; }
            set { email = value; OnPropertyChanged("email"); } //אימייל
        }

        public string? UserPhone
        {
            get { return userphone; }
            set { userphone = value; OnPropertyChanged(nameof(UserPhone)); } //מספר טלפון
        }

        public string UserPassword
        {
            get { return password; }
            set { password = value; OnPropertyChanged("password"); } //סיסמא
        }

        public DateTime BDate
        {
            get { return bdate; }
            set
            {
                bdate = value;
                calculateAge();
                OnPropertyChanged("BDate");
                OnPropertyChanged("Age");
            }
        }
        public int? Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged(nameof(Age)); }
        }
        public DateTime Today
        { 
            get { return today; }
        }

        public void calculateAge()
        {
            this.Age = this.Today.Year - this.BDate.Year;
        }
    }
}
