using System;
using TPO_Lab1.Menus;

namespace TPO_Lab1
{
    class Program
    { 
        public static void Main(string[] args)
        {

            IO.WriteLine = Console.WriteLine;
            IO.Write = Console.Write;
            IO.ReadLine = Console.ReadLine;
            IO.ReadKey = Console.ReadKey;
            IO.Clear = Console.Clear;

            IO.WriteLine("\n\n\n\t\t\tHello, dear User!\n\n\n");
            
            SpotifyApi.Spotify = Authorization.Authorize();
            var privateProfile = SpotifyApi.Spotify.GetPrivateProfile();
            SpotifyApi.CurrentUserId = privateProfile.Id;

            string userName = privateProfile.DisplayName;
            int followersCount = privateProfile.Followers.Total;

            IO.WriteLine(
                $"\n\t\t\tCongratulations with authorization, {userName}\n\t\t\t\t Your followers count: {followersCount}");
            var mainMenu = MenuGenerator.GenerateMainMenu();

            bool running = true;
            while (running)
            {
                running = mainMenu.Display();
            }
        }
    }
}