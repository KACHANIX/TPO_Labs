using SpotifyAPI.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace TPO_Lab1.Mappers
{
    public static class TracksMapper
    {
        public static List<FullTrack> ToList(Paging<SavedTrack> savedTracks)
        {
            return savedTracks.Items.Select(savedTracksItem => savedTracksItem.Track).ToList();
        }

        public static List<SimpleTrack> ToList(Paging<SimpleTrack> savedTracks)
        {
            return savedTracks.Items.Select(savedTracksItem => savedTracksItem).ToList();
        }

        public static List<FullTrack> ToList(Paging<FullTrack> savedTracks)
        {
            return savedTracks.Items.Select(savedTracksItem => savedTracksItem).ToList();
        }

        public static List<SimpleTrack> ToList(CursorPaging<PlayHistory> history)
        {
            return history.Items.Select(playHistory => playHistory.Track).ToList();
        }
    }
}