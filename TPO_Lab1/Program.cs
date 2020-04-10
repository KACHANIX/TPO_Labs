using Autofac;
using System;
using TPO_Lab1.Converters;
using TPO_Lab1.MenuFunctions;
using TPO_Lab1.Menus.Generators;
using TPO_Lab1.Utils;

namespace TPO_Lab1
{
    class Program
    {
        private static IContainer _container;

        public static void Main(string[] args)
        {
            IO.WriteLine = Console.WriteLine;
            IO.Write = Console.Write;
            IO.ReadLine = Console.ReadLine;
            IO.ReadKey = Console.ReadKey;
            IO.Clear = Console.Clear;

            IO.WriteLine("\n\n\n\t\t\tHello, dear User!\n\n\n");

            var spotifyApi = new SpotifyApi {Spotify = Authorization.Authorize()};
            var privateProfile = spotifyApi.Spotify.GetPrivateProfile();
            spotifyApi.CurrentUserId = privateProfile.Id;

            string userName = privateProfile.DisplayName;
            int followersCount = privateProfile.Followers.Total;
            IO.WriteLine(
                $"\n\t\t\tCongratulations with authorization, {userName}\n\t\t\t\t Your followers count: {followersCount}");


            var builder = new ContainerBuilder();
            builder.RegisterConverters();
            builder.RegisterGenerators();
            builder.RegisterMenuFunctions();
            builder.RegisterUtils();
            builder.RegisterInstance(spotifyApi);
            _container = builder.Build();

            ShowMainMenu();
        }

        public static void ShowMainMenu()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var menuGenerator = scope.Resolve<MainMenuGenerator>();
                var mainMenu = menuGenerator.GenerateMainMenu();

                bool running = true;
                while (running)
                {
                    running = mainMenu.Display();
                }
            }
        }
    }
}