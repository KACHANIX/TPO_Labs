using System.Collections.Generic;
using System.Linq;
using SpotifyAPI.Web.Models;

namespace TPO_Lab1.Converters
{
    public class AlbumsConverter
    {
        public List<FullAlbum> ToList(Paging<SavedAlbum> albums)
        {
            return albums.Items.Select(x => x.Album).ToList();
        }

        public List<SimpleAlbum> ToList(Paging<SimpleAlbum> albums)
        {
            return albums.Items.Select(x => x).ToList();
        }
    }
}