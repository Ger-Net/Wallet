using NLog;
using NLog.Config;
using NLog.Targets;
using Wallet22.MVVM.View.Auth;

namespace Wallet22
{
    
    public partial class App : Application
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public App()
        {
            InitializeComponent();

            var config = new LoggingConfiguration();
            config.AddRuleForAllLevels(new FileTarget("file"));
            LogManager.Configuration = config;

            MainPage = new AppShell();
        }
    }
}
