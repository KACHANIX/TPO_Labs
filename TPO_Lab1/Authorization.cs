using System;
using System.Collections.Generic;
using System.Text;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;

namespace TPO_Lab1
{
    public static class Authorization
    {
        public static SpotifyWebAPI Authorize(string clientId, string clientSecret, string redirectAndServerUri)
        {
            SpotifyWebAPI api = new SpotifyWebAPI();
            AuthorizationCodeAuth auth = new AuthorizationCodeAuth(
                clientId,
                clientSecret,
                redirectAndServerUri,
                redirectAndServerUri,
                Scope.PlaylistReadPrivate | Scope.PlaylistReadCollaborative | Scope.PlaylistReadPrivate |
                Scope.PlaylistModifyPrivate | Scope.UserReadRecentlyPlayed | Scope.UserTopRead | Scope.UserFollowRead |
                Scope.UserFollowModify | Scope.UserLibraryRead | Scope.UserLibraryModify
            );
            auth.AuthReceived += async (sender, payload) =>
            {
                auth.Stop();
                Token token = await auth.ExchangeCode(payload.Code);
                api = new SpotifyWebAPI()
                {
                    TokenType = token.TokenType,
                    AccessToken = token.AccessToken
                };

                Console.Write("Authorization completed\nType any key to continue: ");
            };
            auth.Start(); // Starts an internal HTTP Server
            auth.OpenBrowser();

            Console.ReadKey();
            Console.Clear();
            return api;
        }
    }
}