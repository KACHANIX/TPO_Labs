using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System.Threading;

namespace TPO_Lab1
{
    public static class Authorization
    {
        private const string ClientId = "c984c495a8b4421a94dedc40ba65944d";
        private const string ClientSecret = "48d62f6b57a74e60825410e02f08c029";
        private const string RedirectAndServerUri = "http://localhost:4002/";
        private static bool _authReceived;

        public static SpotifyWebAPI Authorize()
        {
            SpotifyWebAPI api = new SpotifyWebAPI();
            AuthorizationCodeAuth auth = new AuthorizationCodeAuth(
                ClientId,
                ClientSecret,
                RedirectAndServerUri,
                RedirectAndServerUri,
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

                IO.Write("Authorization completed\nType any key to continue: ");
                _authReceived = true;
            };
            auth.Start(); // Starts an internal HTTP Server
            auth.OpenBrowser();
            while (!_authReceived)
            {
                Thread.Sleep(500);
            }

            IO.ReadKey();
            IO.Clear();
            return api;
        }
    }
}