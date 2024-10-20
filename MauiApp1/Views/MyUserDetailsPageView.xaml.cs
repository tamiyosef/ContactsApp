using MauiApp1.ViewModels;
namespace MauiApp1.Views;

public partial class MyUserDetailsPageView : ContentPage
{
	public MyUserDetailsPageView(MyUserDetailsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

	}
}