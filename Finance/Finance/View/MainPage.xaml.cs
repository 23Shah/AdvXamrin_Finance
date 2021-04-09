using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Finance.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //for iphone 10 onwards for notch screen
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
        }
    }
}
