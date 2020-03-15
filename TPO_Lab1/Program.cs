using SpotifyAPI.Web;
using System;
using System.Threading.Tasks;

namespace TPO_Lab1
{
    class Program
    {
        private const string ClientId = "c984c495a8b4421a94dedc40ba65944d";
        private const string ClientSecret = "48d62f6b57a74e60825410e02f08c029";
        private static SpotifyWebAPI _spotify; 

        static async Task Main(string[] args)
        {
            Console.WriteLine("\n\n\n\t\t\tHello, dear User!\n\n\n");

            _spotify = Authorization.Authorize(ClientId, ClientSecret, "http://localhost:4002/");

            string userId = _spotify.GetPrivateProfile().Id;
            string userName = _spotify.GetPrivateProfile().DisplayName;
            int followersCount = _spotify.GetPrivateProfile().Followers.Total;
            Console.WriteLine($"\n\t\t\tCongratulations with authorization, {userName}\n\t\t\t\t Your followers count: {followersCount}");

            // var a = _spotify.Getarttop()();


            var mainMenu = new Menu.Menu();

            // bool while

            // while 

        } 
    }
}