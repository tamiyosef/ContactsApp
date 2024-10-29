using MauiApp1.models;
using MauiApp1.ViewModels;
using System.Xml.Linq;

namespace MauiApp1.Views;

public partial class RegistrationPage : ContentPage
{
    public RegistrationPage(RegistrationPageViewModel vm)
    {
        InitializeComponent();
        //  קישור הדף לVIEW MODEL במקום למודל
        BindingContext = vm;
    }

}

