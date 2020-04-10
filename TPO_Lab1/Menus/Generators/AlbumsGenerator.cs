using SpotifyAPI.Web.Models;
using System.Collections.Generic;
using TPO_Lab1.MenuFunctions;
using TPO_Lab1.MenuFunctions.Album;

namespace TPO_Lab1.Menus.Generators
{
    public class AlbumsGenerator
    {
        private readonly AlbumMenuFunctions _albumMenuFunctions;
        private readonly ExitFunctions _exitFunctions;

        public AlbumsGenerator(AlbumMenuFunctions albumMenuFunctions, ExitFunctions exitFunctions)
        {
            _albumMenuFunctions = albumMenuFunctions;
            _exitFunctions = exitFunctions;
        }

        public BasicModelMenu.BasicModelMenu GenerateAlbums(List<SimpleAlbum> albumList)
        {
            var albumsMenu = new BasicModelMenu.BasicModelMenu();
            int i = 1;
            albumList.ForEach(simpleAlbum => albumsMenu.AddItem(
                $"{simpleAlbum.Artists[0].Name} - {simpleAlbum.Name}",
                _albumMenuFunctions.GetAlbum, i++.ToString(), simpleAlbum.Id));
            albumsMenu.AddItem("Exit", _exitFunctions.Exit, i.ToString(), null);
            return albumsMenu;
        }

        public BasicModelMenu.BasicModelMenu GenerateAlbums(List<FullAlbum> albumList)
        {
            var albumsMenu = new BasicModelMenu.BasicModelMenu();
            int i = 1;
            albumList.ForEach(simpleAlbum => albumsMenu.AddItem(
                $"{simpleAlbum.Artists[0].Name} - {simpleAlbum.Name}",
                _albumMenuFunctions.GetAlbum, i++.ToString(), simpleAlbum.Id));
            albumsMenu.AddItem("Exit", _exitFunctions.Exit, i.ToString(), null);
            return albumsMenu;
        }
    }
}