using System.Collections.Generic;
using System.Linq;
using SpotifyAPI.Web.Models;

namespace TPO_Lab1.Converters
{
    public class PlaylistsConverter
    {
        public List<SimplePlaylist> ToList(Paging<SimplePlaylist> playlists)
        {
            return playlists.Items.Select(playlist => playlist).ToList();
        }
    }
}