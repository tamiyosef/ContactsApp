using MauiApp1.ViewModels;
namespace MauiApp1.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginPageViewModel viewModel)
	{

		InitializeComponent();
        // הגדר את ה-ViewModel כ-BindingContext של העמוד
        BindingContext = viewModel; // נשתמש ב-Dependency Injection עבור ה-ViewMode
    }
}