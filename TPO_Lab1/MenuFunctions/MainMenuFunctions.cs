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
            return true;
        }

        public static bool MainArtists()
        {
            return true;
        }

        public static bool MainAlbums()
        {
            return true;
        }
    }
}