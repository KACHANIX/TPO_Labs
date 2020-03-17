using TPO_Lab1.Menus;

namespace TPO_Lab1.MenuFunctions
{
    public static class MainMenuFunctions
    {
        public static bool MainTracks()
        {
            var tracksMenu = MenuGenerator.GenerateTracksMenu();

            bool running = true;
            while (running)
            {
                running = tracksMenu.Display();
            }

            return true;
        }

        public static bool MainPlaylists()
        {
            var playlistsMenu = MenuGenerator.GeneratePlaylistsMenu();
            bool running = true;
            while (running)
            {
                running = playlistsMenu.Display();
            }

            return true;
        }

        public static bool MainArtists()
        {
            return true;
        }

        public static bool MainAlbums()
        {
            var albumsMenu = MenuGenerator.GenerateAlbumsMenu();
            bool running = true;
            while (running)
            {
                running = albumsMenu.Display();
            }

            return true;
        }
    }
}