using System.Collections.Generic;
using System.Linq;
using SpotifyAPI.Web.Models;

namespace TPO_Lab1.Converters
{
    public static class TracksConverter
    {
        public static List<FullTrack> ToList(Paging<SavedTrack> tracks)
        {
            return tracks.Items.Select(savedTracksItem => savedTracksItem.Track).ToList();
        }

        public static List<SimpleTrack> ToList(Paging<SimpleTrack> tracks)
        {
            return tracks.Items.Select(savedTracksItem => savedTracksItem).ToList();
        }

        public static List<FullTrack> ToList(Paging<FullTrack> tracks)
        {
            return tracks.Items.Select(savedTracksItem => savedTracksItem).ToList();
        }

        public static List<SimpleTrack> ToList(CursorPaging<PlayHistory> history)
        {
            return history.Items.Select(playHistory => playHistory.Track).ToList();
        }

        public static List<FullTrack> ToList(Paging<PlaylistTrack> playlists)
        {
            return playlists.Items.Select(playlist => playlist.Track).ToList();
        }
    }
}