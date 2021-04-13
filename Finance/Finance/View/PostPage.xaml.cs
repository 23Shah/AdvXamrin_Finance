using System;
using System.Collections.Generic;
using Finance.Model;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace Finance.View
{
    public partial class PostPage : ContentPage
    {
        public PostPage()
        {
            InitializeComponent();
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
        }

        public PostPage(Item item)
        {
            InitializeComponent();
            try
            {
                //throw (new Exception("Unable to load blog")); //for generating Error which will be available in appcenter
                Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
                webView.Source = item.ItemLink;
                var properties = new Dictionary<string, string>
                {
                    { "Blog_post ",$"{item.Title}"}
                };
                TrackEvent(properties);
            }
            catch (Exception ex)
            {
                var properties = new Dictionary<string, string>
                {
                    { "Blog_post ",$"{item.Title}"}
                };

                TrackError(ex, properties);
            }
           
        }

        private async void TrackEvent(Dictionary<string, string> properties)
        {
            if(await Analytics.IsEnabledAsync())
                Analytics.TrackEvent("Blog Post Opened", properties);

        }

        private async void TrackError(Exception ex, Dictionary<string, string> properties)
        {
            if (await Crashes.IsEnabledAsync())
                Crashes.TrackError(ex, properties);

        }
    }
}
