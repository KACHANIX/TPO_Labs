using System;
using System.Collections.Generic;
using System.Text;
using SpotifyAPI.Web.Models;
using TPO_Lab1.MenuFunctions;
using TPO_Lab1.MenuFunctions.Album;

namespace TPO_Lab1.Menus.Generators
{
    public class AlbumsGenerator
    {
        public AlbumMenuFunctions AlbumMenuFunctions { get; set; }
        public ExitFunctions ExitFunctions { get; set; }

        public AlbumsGenerator(AlbumMenuFunctions albumMenuFunctions, ExitFunctions exitFunctions)
        {
            AlbumMenuFunctions = albumMenuFunctions;
            ExitFunctions = exitFunctions;
        } 

        public BasicModelMenu.BasicModelMenu GenerateAlbums(List<SimpleAlbum> albumList)
        {
            var albumsMenu = new BasicModelMenu.BasicModelMenu();
            int i = 1;
            albumList.ForEach(simpleAlbum => albumsMenu.AddItem(
                $"{simpleAlbum.Artists[0].Name} - {simpleAlbum.Name}",
                AlbumMenuFunctions.GetAlbum, i++.ToString(), simpleAlbum.Id));
            albumsMenu.AddItem("Exit", ExitFunctions.Exit, i.ToString(), null);
            return albumsMenu;
        }

        public BasicModelMenu.BasicModelMenu GenerateAlbums(List<FullAlbum> albumList)
        {
            var albumsMenu = new BasicModelMenu.BasicModelMenu();
            int i = 1;
            albumList.ForEach(simpleAlbum => albumsMenu.AddItem(
                $"{simpleAlbum.Artists[0].Name} - {simpleAlbum.Name}",
                AlbumMenuFunctions.GetAlbum, i++.ToString(), simpleAlbum.Id));
            albumsMenu.AddItem("Exit", ExitFunctions.Exit, i.ToString(), null);
            return albumsMenu;
        }
    }
}
