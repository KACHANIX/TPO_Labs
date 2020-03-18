using System;
using TPO_Lab1.Menus;

namespace TPO_Lab1
{
    class Program
    {
        private const string ClientId = "c984c495a8b4421a94dedc40ba65944d";
        private const string ClientSecret = "48d62f6b57a74e60825410e02f08c029";

        public static void Main(string[] args)
        {
            Console.WriteLine("\n\n\n\t\t\tHello, dear User!\n\n\n");
            var spotify = Authorization.Authorize(ClientId, ClientSecret, "http://localhost:4002/");

            var privateProfile = spotify.GetPrivateProfile();
            SpotifyApi.Spotify = spotify;
            SpotifyApi.CurrentUserId = privateProfile.Id;

            string userName = privateProfile.DisplayName;
            int followersCount = privateProfile.Followers.Total;

            Console.WriteLine(
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