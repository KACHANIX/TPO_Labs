using System.Collections.Generic;
using System.Linq;
using SpotifyAPI.Web.Models;

namespace TPO_Lab1.Converters
{
    public static class PlaylistsConverter
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