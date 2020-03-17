using SpotifyAPI.Web.Models;
using System.Collections.Generic;
using TPO_Lab1.Mappers;

namespace TPO_Lab1.Functionality
{
    public static class TracksFunctionality
    {
        public static List<FullTrack> GetSavedTracks()
        {
            var savedTracksPaging = SpotifyApi.Spotify.GetSavedTracks();
            var savedTracks = TracksMapper.ToList(savedTracksPaging);
            return savedTracks;
        }

        public static List<FullTrack> GetTopTracks()
        {
            var topTracksPaging = SpotifyApi.Spotify.GetUsersTopTracks();
            var topTracks = TracksMapper.ToList(topTracksPaging);
            return topTracks;
        }

        public static List<SimpleTrack> GetRecentlyPlayedTracks()
        {
            var playHistory = SpotifyApi.Spotify.GetUsersRecentlyPlayedTracks();

            var topTracks = TracksMapper.ToList(playHistory);
            return topTracks;
        }

        public static FullTrack GetParticularTrack(string trackId)
        {
            var track = SpotifyApi.Spotify.GetTrack(trackId);
            return track;
        }
    }
}