namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int counter = 0;
        string[] images = { "cheece_cake.jpg","chocolate_cake.jpg", "cold_cheese_cake.jpg" };
        

        public MainPage()
        {
            InitializeComponent();
            
            down_click.IsEnabled = false;   
        }

        private void Upp_click_Clicked(object sender, EventArgs e)
        {
            
            counter++;
            presented_picture.Source = images[counter];
            down_click.IsEnabled = true;
            if (counter == images.Length-1)
            { Upp_click.IsEnabled = false; }
            
        }

        private void down_click_Clicked(object sender, EventArgs e)
        {
    
            counter--;
            presented_picture.Source = images[counter];
            Upp_click.IsEnabled = true;

            if (counter == 0)
            { down_click.IsEnabled = false; }
        }
       
    }

}
