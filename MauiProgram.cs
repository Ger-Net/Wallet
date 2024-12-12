using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Wallet22.MVVM.View;
using Wallet22.Services.UserServices;

namespace Wallet22
{
    public static class MauiProgram
    {
        
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            ServicesRegistration(builder);
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static void ServicesRegistration(MauiAppBuilder builder)
        {
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<OperationsPage>();
        }

    }
}
