using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class ContactsPageView : ContentPage
{
	public ContactsPageView(ContactsPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel; // Set the ViewModel as the BindingContext
    }
}