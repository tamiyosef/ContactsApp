
using System.Diagnostics.Metrics;
using System.Reflection;

namespace MauiApp1;

public partial class DinamicPage : ContentPage

{
    VerticalStackLayout MainLayout;
    int counter = 0;
    private Image PresentedImage;
    private Button up_btn;
    private Button down_btn;

    public DinamicPage()
    {
        InitializeComponent();
        BuildUi();

    }
    string[] images = { "cheece_cake.jpg", "chocolate_cake.jpg", "cold_cheese_cake.jpg"};

    private void BuildUi()
    {
        // יצירת מבנה דף חדש //
        MainLayout = new VerticalStackLayout();
        MainLayout.BackgroundColor = Colors.Beige;
        this.Content = MainLayout;
        // יצירת כותרת לדף //
        AddTitlePage();
        Add_up_button();
        Add_image();
        Add_down_button();

    }

    private void Add_image()
    {
        PresentedImage = new Image
        {
            Source = images[counter],
            WidthRequest = 300, //  הגדרת רוחב התמונה
            HeightRequest = 300 //  הגדרת גובה התמונה
        };
        MainLayout.Children.Add(PresentedImage);
    }

    private void UpdateImage()
    {
            PresentedImage.Source = images[counter];
    }
    private void Add_down_button()
        {
            down_btn = new Button
            {
                FontFamily = "MaterialSymbols",
                Text = "arrow_downward",
            };
        down_btn.IsEnabled = false;
        down_btn.Clicked += OndownButtonClicked;
        MainLayout.Children.Add(down_btn);
        }

        private void OndownButtonClicked(object sender, EventArgs e)
        {
            counter--;
            up_btn.IsEnabled = true;
            if (counter == 0) 
            { down_btn.IsEnabled = false; }
            UpdateImage();
        }

        private void Add_up_button()
        {
            up_btn = new Button
            {
                FontFamily = "MaterialSymbols",
                Text = "arrow_upward"
            };
            up_btn.Clicked += Btn_Clicked; 
            MainLayout.Children.Add(up_btn);
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
           counter++;
           if (counter == images.Length - 1)
             {
              up_btn.IsEnabled = false;
             }
           down_btn.IsEnabled= true;
           UpdateImage();
        }

        private void AddTitlePage()
        {
            Label title = new Label()
            {
                Text = "זוהי הכותרת",
            };
            // הוספת הכותרת למבנה הדף //
            MainLayout.Children.Add(title);

        }


    }
