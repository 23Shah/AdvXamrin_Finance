using Finance.View;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Finance
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override async void OnStart()
        {
            string androidAppSecret = "6ac0e0f2-579c-41c6-9ec8-7b4474ebcaab";
            string iOSAppSecret = "0b687c29-7a3e-429a-aec4-92ecd96edd57";

            AppCenter.Start($"android={androidAppSecret};ios={iOSAppSecret};", typeof(Crashes),typeof(Analytics));

            //evaluate application crash
            bool didAppCrashed = await Crashes.HasCrashedInLastSessionAsync();
            if(didAppCrashed)
            {
                var crashReport = await Crashes.GetLastSessionCrashReportAsync();
            }

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
