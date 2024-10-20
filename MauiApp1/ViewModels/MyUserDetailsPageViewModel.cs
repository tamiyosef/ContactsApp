using MauiApp1.models;
using MauiApp1.Services;
using System.Windows.Input;
using System.Diagnostics;

namespace MauiApp1.ViewModels
{
    public class MyUserDetailsPageViewModel : ViewModelBase
    {
        private User? _currentUser;
        private string _userName;
        private string _userEmail;
        private string _userPhone;
        private string _profilePicture;
   
        private APIService _apiService;

        public ICommand SaveCommand { get; } // פקודה לשמירת השינויים

        // מאפיינים לקישור ל-UI (XAML)
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public User? CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
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

        public string ProfilePicture
        {
            get => _profilePicture;
            set
            {
                _profilePicture = value;
                OnPropertyChanged(nameof(ProfilePicture));
            }
        }

        // קונסטרקטור שבו נטען את פרטי המשתמש מה-API
        public MyUserDetailsPageViewModel(APIService apiService)
        {
            _apiService = apiService;
            SaveCommand = new Command(OnSave); // קישור פקודת השמירה לפונקציה
            LoadUserDetails(); // קריאה לפונקציה לטעינת פרטי המשתמש הנוכחי
        }

        // פונקציה לטעינת פרטי המשתמש הנוכחי מהשרת
        private async void LoadUserDetails()
        {
            try
            {
                this.CurrentUser = await _apiService.GetCurrentUser();
                if (this.CurrentUser != null)
                {
                    UserName = this.CurrentUser.UserName;
                    UserEmail = this.CurrentUser.UserEmail;
                    UserPhone = this.CurrentUser.UserPhone;
                    ProfilePicture = this.CurrentUser.ProfilePicture;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading user details: {ex.Message}");
            }
        }

        // פונקציה לשמירת השינויים ועדכון המשתמש בשרת
        private async void OnSave()
        {
            try
            {
                User updatedUser = new User
                {
                    UserName = UserName,
                    UserEmail = UserEmail,
                    UserLastName = CurrentUser.UserLastName,
                    UserPassword = CurrentUser.UserPassword,
                    UserPhone = UserPhone,
                    ProfilePicture = ProfilePicture
                };

                bool isUpdated = await _apiService.UpdateUser(updatedUser);

                if (isUpdated)
                {
                    Debug.WriteLine("User updated successfully.");
                }
                else
                {
                    Debug.WriteLine("Failed to update user.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error updating user: {ex.Message}");
            }
        }
    }
}
