using TPO_Lab1.MenuFunctions;

namespace TPO_Lab1.Menu
{
    public static class MenuGenerator
    {
        public static Menu GenerateMainMenu(SpotifyApi api)
        {
            var mainMenu = new Menu();
            mainMenu.AddItem("Songs", MainMenuFunctions.MainSongs, "1");
            mainMenu.AddItem("Songs", MainMenuFunctions.MainArtists, "2");
            return mainMenu;
        }
    }
}
