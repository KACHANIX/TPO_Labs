using System.Collections.Generic;
using System.Linq;
using SpotifyAPI.Web.Models;
using TPO_Lab1.Converters;

namespace TPO_Lab1.Utils
{
    public class PlaylistsUtils
    {
        private readonly PlaylistsConverter _playlistsConverter;
        private readonly SpotifyApi _spotifyApi;

        public PlaylistsUtils(PlaylistsConverter playlistsConverter, SpotifyApi spotifyApi)
        {
            _playlistsConverter = playlistsConverter;
            _spotifyApi = spotifyApi;
        }

        public List<SimplePlaylist> GetSavedPlaylists()
        {
            var savedPlaylists =
                _playlistsConverter.ToList(_spotifyApi.Spotify.GetUserPlaylists(_spotifyApi.CurrentUserId));
            var filteredPlaylists = savedPlaylists.Select(playlist => playlist)
                .Where(playlist => playlist.Owner.Id != _spotifyApi.CurrentUserId).ToList();

            return filteredPlaylists;
        }

        public List<SimplePlaylist> GetCreatedPlaylists()
        {
            var createdPlaylists =
                _playlistsConverter.ToList(_spotifyApi.Spotify.GetUserPlaylists(_spotifyApi.CurrentUserId));
            var filteredPlaylists = createdPlaylists.Select(playlist => playlist)
                .Where(playlist => playlist.Owner.Id == _spotifyApi.CurrentUserId).ToList();

            return filteredPlaylists;
        }

        public List<SimplePlaylist> GetSpotifyFeaturedPlaylists()
        {
            var savedPlaylistsPaging = _spotifyApi.Spotify.GetFeaturedPlaylists().Playlists;
            var savedPlaylists = _playlistsConverter.ToList(savedPlaylistsPaging);

            return savedPlaylists;
        }

        public FullPlaylist GetParticularPlaylist(string playlistId)
        {
            var playlist = _spotifyApi.Spotify.GetPlaylist(playlistId);
            return playlist;
        }
    }
}