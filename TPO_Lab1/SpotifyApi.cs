using SpotifyAPI.Web;

namespace TPO_Lab1
{
    public class SpotifyApi
    {
        public SpotifyWebAPI Spotify;
        public string CurrentUserId;

        public SpotifyApi(SpotifyWebAPI spotify, string currentUserId)
        {
            Spotify = spotify;
            CurrentUserId = currentUserId;
        }
    }
}
