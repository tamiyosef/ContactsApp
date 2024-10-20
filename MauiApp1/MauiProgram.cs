using MauiApp1.Services;
using MauiApp1.ViewModels;
using MauiApp1.Views;
using Microsoft.Extensions.Logging;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialSymbolsOutlined_VariableFont.ttf", "MaterialSymbols");
                });

            // אובייקט מסוג סינגלטון יווצר בפעם הראשונה שמאתחלים אותו
            // בקונסטרקטור כלשהו( במקרה שלנו - עמוד הרשמה)
            // מופע זה ייקרא בכל בקשה לאורך כל הפרויקט
            builder.Services.AddSingleton<APIService>();

            // נרשום את השירותים שאנחנו מעוניים שהתכנית תנהל עבורנו
            // כלומר, כל התלויות בשירותים אלה יועברו אוטומטית לכל אובייקט חדש שיווצר
            // מייצר אובייקט חדש עבור כל הגדרת אובייקט זה
            builder.Services.AddTransient<RegistrationPageViewModel>();
            builder.Services.AddTransient<RegistrationPage>();

            // LoginPage ו- ViewModel עבורו
            builder.Services.AddTransient<LoginPageViewModel>();
            builder.Services.AddTransient<LoginView>();

            // LoginPage ו- ViewModel עבורו
            builder.Services.AddTransient<ContactsPageViewModel>();
            builder.Services.AddTransient<ContactsPageView>();

            builder.Services.AddTransient<UserDetailsPageViewModel>();
            builder.Services.AddTransient<UpdateUserPageView>();

            builder.Services.AddTransient<MyUserDetailsPageViewModel>();
            builder.Services.AddTransient<MyUserDetailsPageView>();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
