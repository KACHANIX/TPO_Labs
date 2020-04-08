using TPO_Lab1.Menus;
using TPO_Lab1.Menus.Generators;
using TPO_Lab1.Utils;

namespace TPO_Lab1.MenuFunctions.Album
{
    public class AlbumsMenuFunctions
    {
        public AlbumsUtils AlbumsUtils { get; set; }
        public AlbumsGenerator AlbumsGenerator { get; set; }

        public AlbumsMenuFunctions(AlbumsUtils albumsUtils, AlbumsGenerator albumsGenerator)
        {
            AlbumsUtils = albumsUtils;
            AlbumsGenerator = albumsGenerator;
        }

        public bool SavedAlbums()
        {
            var savedAlbums = AlbumsUtils.GetSavedAlbums();
            var albumsMenu = AlbumsGenerator.GenerateAlbums(savedAlbums);
            bool running = true;
            while (running)
            {
                running = albumsMenu.Display();
            }

            return true;
        }

        public bool NewAlbumReleases()
        {
            var newAlbums = AlbumsUtils.GetNewAlbumReleases();
            var albumsMenu = AlbumsGenerator.GenerateAlbums(newAlbums);
            bool running = true;
            while (running)
            {
                running = albumsMenu.Display();
            }

            return true;
        }
    }
}