using TPO_Lab1.Functionality;
using TPO_Lab1.Menus;

namespace TPO_Lab1.MenuFunctions.Playlist
{
    public static class PlaylistsMenuFunctions
    {
        public static bool SavedPlaylists()
        { 
            var savedPlaylists = PlaylistsFunctionality.GetSavedPlaylists();
            var playlistsMenu = MenuGenerator.GeneratePlaylists(savedPlaylists);
            bool running = true;
            while (running)
            {
                running = playlistsMenu.Display();
            }
            return true;
        }
        public static bool CreatedPlaylists()
        { 
            var createdPlaylists = PlaylistsFunctionality.CreatedPlaylists();
            var playlistsMenu = MenuGenerator.GeneratePlaylists(createdPlaylists);
            bool running = true;
            while (running)
            {
                running = playlistsMenu.Display();
            }
            return true;
        }
        public static bool SpotifyFeaturedPlaylists()
        {
            var featuredPlaylists = PlaylistsFunctionality.SpotifyFeaturedPlaylists();
            var playlistsMenu = MenuGenerator.GeneratePlaylists(featuredPlaylists);
            bool running = true;
            while (running)
            {
                running = playlistsMenu.Display();
            }
            return true;
        }
    }
}
