using TPO_Lab1.Functionality;
using TPO_Lab1.Menus;

namespace TPO_Lab1.MenuFunctions.Album
{
    public static class AlbumsMenuFunctions
    {
        public static bool SavedAlbums()
        {
            var savedAlbums = AlbumsFunctionality.GetSavedAlbums();
            var albumsMenu = MenuGenerator.GenerateAlbums(savedAlbums);
            bool running = true;
            while (running)
            {
                running = albumsMenu.Display();
            }

            return true;
        }

        public static bool NewAlbumReleases()
        {
            var newAlbums = AlbumsFunctionality.GetNewAlbumReleases();
            var albumsMenu = MenuGenerator.GenerateAlbums(newAlbums);
            bool running = true;
            while (running)
            {
                running = albumsMenu.Display();
            }

            return true;
        }
    }
}