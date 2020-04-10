using TPO_Lab1.MenuFunctions;

namespace TPO_Lab1.Menus.Generators
{
    public class MainMenuGenerator
    {
        private readonly MainMenuFunctions _mainMenuFunctions;
        private readonly ExitFunctions _exitFunctions;

        public MainMenuGenerator(ExitFunctions exitFunctions, MainMenuFunctions mainMenuFunctions)
        {
            _exitFunctions = exitFunctions;
            _mainMenuFunctions = mainMenuFunctions;
        }

        public DefaultMenu.DefaultMenu GenerateMainMenu()
        {
            var mainMenu = new DefaultMenu.DefaultMenu();
            mainMenu.AddItem("Albums", _mainMenuFunctions.MainAlbums, "1");
            mainMenu.AddItem("Artists", _mainMenuFunctions.MainArtists, "2");
            mainMenu.AddItem("Playlists", _mainMenuFunctions.MainPlaylists, "3");
            mainMenu.AddItem("Tracks", _mainMenuFunctions.MainTracks, "4");
            mainMenu.AddItem("Exit", _exitFunctions.Exit, "5");
            return mainMenu;
        }
    }
}