using SpotifyAPI.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace TPO_Lab1.Mappers
{
    public static class AlbumsMapper
    {
        public static List<FullAlbum> ToList(Paging<SavedAlbum> savedAlbums)
        {
            return savedAlbums.Items.Select(x => x.Album).ToList();
        }

        public static List<SimpleAlbum> ToList(Paging<SimpleAlbum> savedAlbums)
        {
            return savedAlbums.Items.Select(x => x).ToList();
        }
    }
}