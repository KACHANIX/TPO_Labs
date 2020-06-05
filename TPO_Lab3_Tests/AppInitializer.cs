using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TPO_Lab3_Tests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.InstalledApp("com.companyname.tpo_lab3_mobile").StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}