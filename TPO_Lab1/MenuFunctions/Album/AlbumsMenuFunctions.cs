using TPO_Lab1.Menus.Generators;
using TPO_Lab1.Utils;

namespace TPO_Lab1.MenuFunctions.Album
{
    public class AlbumsMenuFunctions
    {
        private readonly AlbumsUtils _albumsUtils;
        private readonly AlbumsGenerator _albumsGenerator;

        public AlbumsMenuFunctions(AlbumsUtils albumsUtils, AlbumsGenerator albumsGenerator)
        {
            _albumsUtils = albumsUtils;
            _albumsGenerator = albumsGenerator;
        }

        public bool SavedAlbums()
        {
            var savedAlbums = _albumsUtils.GetSavedAlbums();
            var albumsMenu = _albumsGenerator.GenerateAlbums(savedAlbums);
            bool running = true;
            while (running)
            {
                running = albumsMenu.Display();
            }

            return true;
        }

        public bool NewAlbumReleases()
        {
            var newAlbums = _albumsUtils.GetNewAlbumReleases();
            var albumsMenu = _albumsGenerator.GenerateAlbums(newAlbums);
            bool running = true;
            while (running)
            {
                running = albumsMenu.Display();
            }

            return true;
        }
    }
}