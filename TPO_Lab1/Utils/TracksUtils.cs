using System.Collections.Generic;
using SpotifyAPI.Web.Models;
using TPO_Lab1.Converters;

namespace TPO_Lab1.Utils
{
    public class TracksUtils
    {
        private readonly TracksConverter _tracksConverter;
        private readonly SpotifyApi _spotifyApi;

        public TracksUtils(TracksConverter tracksConverter, SpotifyApi spotifyApi)
        {
            _tracksConverter = tracksConverter;
            _spotifyApi = spotifyApi;
        }

        public List<FullTrack> GetSavedTracks()
        {
            var savedTracksPaging = _spotifyApi.Spotify.GetSavedTracks();
            var savedTracks = _tracksConverter.ToList(savedTracksPaging);
            return savedTracks;
        }

        public List<FullTrack> GetTopTracks()
        {
            var topTracksPaging = _spotifyApi.Spotify.GetUsersTopTracks();
            var topTracks = _tracksConverter.ToList(topTracksPaging);
            return topTracks;
        }

        public List<SimpleTrack> GetRecentlyPlayedTracks()
        {
            var playHistory = _spotifyApi.Spotify.GetUsersRecentlyPlayedTracks();

            var historyTracks = _tracksConverter.ToList(playHistory);
            return historyTracks;
        }

        public FullTrack GetParticularTrack(string trackId)
        {
            var track = _spotifyApi.Spotify.GetTrack(trackId);
            return track;
        }
    }
}