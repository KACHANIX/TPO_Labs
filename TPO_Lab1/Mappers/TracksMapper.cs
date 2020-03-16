using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpotifyAPI.Web.Models;

namespace TPO_Lab1.Mappers
{
    public static class TracksMapper
    {
        public static List<FullTrack> ToFullTracks(Paging<SavedTrack> savedTracks)
        {
            return savedTracks.Items.Select(savedTracksItem => savedTracksItem.Track).ToList();
        }

        public static List<FullTrack> ToFullTracks(Paging<FullTrack> savedTracks)
        {
            return savedTracks.Items.Select(savedTracksItem => savedTracksItem).ToList();
        }

        public static List<SimpleTrack> ToSimpleTracks(CursorPaging<PlayHistory> history)
        {
            return history.Items.Select(playHistory => playHistory.Track).ToList();
        }
    }
}