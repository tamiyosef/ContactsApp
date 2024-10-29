using MauiApp1.models;
using System.Collections.Generic;
using System.Windows.Input;

namespace MauiApp1.ViewModels
{
    public class UserDetailsPageViewModel : ViewModelBase, IQueryAttributable
    {
        private string _userName;
        private string _userEmail;
        private string _userPhone;
        private string _userPassword;
        private string _profilepicture;

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string UserEmail
        {
            get => _userEmail;
            set
            {
                _userEmail = value;
                OnPropertyChanged(nameof(UserEmail));
            }
        }

        public string UserPhone
        {
            get => _userPhone;
            set
            {
                _userPhone = value;
                OnPropertyChanged(nameof(UserPhone));
            }
        }

        public string UserPassword
        {
            get => _userPassword;
            set
            {
                _userPassword = value;
                OnPropertyChanged(nameof(UserPassword));
            }
        }

        public string ProfilePicture
        {
            get => _profilepicture;
            set
            {
                _profilepicture = value;
                OnPropertyChanged(nameof(ProfilePicture));
            }
        }

        public ICommand SaveCommand { get; }

        public UserDetailsPageViewModel()
        {
            
        }

        // קבלת פרטי המשתמש שהועברו דרך הניווט
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("User"))
            {
                var user = query["User"] as User;
                if (user != null)
                {
                    UserName = user.UserName;
                    UserEmail = user.UserEmail;
                    UserPhone = user.UserPhone;
                    UserPassword = user.UserPassword;
                    ProfilePicture = user.ProfilePicture; // קבלת תמונת הפרופיל
                }
            }
        }

        private void OnSave()
        {
            // לוגיקה לשמירת השינויים
            Console.WriteLine($"שמירה: שם משתמש = {UserName}, אימייל = {UserEmail}, טלפון = {UserPhone}, תמונה = {ProfilePicture}");
        }
    }
}
