using SpotifyAPI.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace TPO_Lab1.Mappers
{
    class PlaylistsMapper
    {
        public static List<SimplePlaylist> ToList(Paging<SimplePlaylist> playlists)
        {
            return playlists.Items.Select(playlist => playlist).ToList();
        }

        public static List<FullTrack> ToList(Paging<PlaylistTrack> playlists)
        {
            return playlists.Items.Select(playlist => playlist.Track).ToList();
        }
    }
}