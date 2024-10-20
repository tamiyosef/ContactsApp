using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class UpdateUserPageView : ContentPage
{
	public UpdateUserPageView(UserDetailsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}