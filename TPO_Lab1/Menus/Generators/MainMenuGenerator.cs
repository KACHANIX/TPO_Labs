using TPO_Lab1.MenuFunctions;

namespace TPO_Lab1.Menus.Generators
{
    public class MainMenuGenerator
    {
        public MainMenuFunctions MainMenuFunctions { get; set; }
        public ExitFunctions ExitFunctions { get; set; }

        public MainMenuGenerator(ExitFunctions exitFunctions, MainMenuFunctions mainMenuFunctions)
        {
            ExitFunctions = exitFunctions;
            MainMenuFunctions = mainMenuFunctions;
        }

        public DefaultMenu.DefaultMenu GenerateMainMenu()
        {
            var mainMenu = new DefaultMenu.DefaultMenu();
            mainMenu.AddItem("Albums", MainMenuFunctions.MainAlbums, "1");
            mainMenu.AddItem("Artists", MainMenuFunctions.MainArtists, "2");
            mainMenu.AddItem("Playlists", MainMenuFunctions.MainPlaylists, "3");
            mainMenu.AddItem("Tracks", MainMenuFunctions.MainTracks, "4");
            mainMenu.AddItem("Exit", ExitFunctions.Exit, "5");
            return mainMenu;
        }
    }
}