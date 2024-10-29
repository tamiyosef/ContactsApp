using MauiApp1.models;
using System.Collections.ObjectModel;
using MauiApp1.Services;
using System.Diagnostics;
using System.Windows.Input;
using MauiApp1.Views;

namespace MauiApp1.ViewModels
{
    public class ContactsPageViewModel : ViewModelBase
    {
        private APIService api_service;
        private ObservableCollection<User> contacts;
        public ICommand DeleteCommand { get; }
        public ICommand UpdateCommand { get; } // פקודת העדכון החדשה


        public ObservableCollection<User> Contacts
        {
            get { return contacts; }
            set
            {
                contacts = value;
                OnPropertyChanged(); // Notify UI of changes
            }
        }

        public ContactsPageViewModel(APIService api_service)
        {
            this.api_service = api_service;
            Contacts = new ObservableCollection<User>();

            // Start loading users asynchronously
            LoadUsersAsync();

            DeleteCommand = new Command<User>(OnDeleteContact);
            UpdateCommand = new Command<User>(OnUpdateContact);
        }

        // This method loads users asynchronously and updates the ObservableCollection
        private async Task LoadUsersAsync()
        {
            var userList = await api_service.GetAllUsers();
            if (userList != null)
            {
                Contacts.Clear(); // נקה את הרשימה הקיימת לפני ההוספה

                foreach (var user in userList)
                {
                    Contacts.Add(user); // הוסף משתמשים לרשימה
                }
            }
        }
        // פעולה שמוחקת את המשתמש מהאוסף
        private async void OnDeleteContact(User user)
        {
            bool success = await api_service.DeleteUserByEmail(user.UserEmail);

            // מחיקה גם מהאוסף המקומי (Contacts)
            Contacts.Remove(user);

            // עדכון ה-UI באמצעות OnPropertyChanged
            OnPropertyChanged(nameof(Contacts)); 
            if (success)
            {
                Debug.WriteLine("User deleted successfully.");
            }
            else
            {
                Debug.WriteLine("Failed to delete user.");
            }
/*            if (user != null)
            {
                Contacts.Remove(user); // הסר את המשתמש מהאוסף
               // להוסיף פקודה שתמחק מהשרת ולא מהרשימה הסטטית!!
            }*/
        }


        // פעולה שמעדכנת את פרטי המשתמש
        private async void OnUpdateContact(User user)
        {
            if (user != null)
            {
                Debug.WriteLine("UPDATE");
                await Shell.Current.GoToAsync($"///{nameof(UpdateUserPageView)}", true, new Dictionary<string, object>
                {
                   { "User", user }
                });


            }
        }
    }
}
