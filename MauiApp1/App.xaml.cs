using MauiApp1.Views;

/*namespace MauiApp1
{
    public partial class App : Application
    {
        public App(RegistrationPage p)
        {
            InitializeComponent();

            MainPage = p;
        }
    }
}*/

namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();  // השתמש ב-Shell לניווט
                                                     
            // מנווט לדף ההתחברות כאשר האפליקציה מתחילה
            Shell.Current.GoToAsync("//LoginView");

        }
    }
}