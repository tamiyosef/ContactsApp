using System.ComponentModel;

namespace MauiApp1.models;

public class ObservableObject : INotifyPropertyChanged

{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}