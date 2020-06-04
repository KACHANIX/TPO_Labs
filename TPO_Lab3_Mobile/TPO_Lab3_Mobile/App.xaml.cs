using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TPO_Lab3_Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()) { BackgroundColor = Color.FromHex("B6B6B4") };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
