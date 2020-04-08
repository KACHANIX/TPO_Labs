using System.Collections.Generic;
using System.Linq;
using SpotifyAPI.Web.Models;
using TPO_Lab1.Converters;

namespace TPO_Lab1.Utils
{
    public class PlaylistsUtils
    {
        public PlaylistsConverter PlaylistsConverter { get; set; }
        public SpotifyApi SpotifyApi { get; set; }

        public PlaylistsUtils(PlaylistsConverter playlistsConverter, SpotifyApi spotifyApi)
        {
            PlaylistsConverter = playlistsConverter;
            SpotifyApi = spotifyApi;
        }

        public List<SimplePlaylist> GetSavedPlaylists()
        {
            var savedPlaylists =
                PlaylistsConverter.ToList(SpotifyApi.Spotify.GetUserPlaylists(SpotifyApi.CurrentUserId));
            var filteredPlaylists = savedPlaylists.Select(playlist => playlist)
                .Where(playlist => playlist.Owner.Id != SpotifyApi.CurrentUserId).ToList();

            return filteredPlaylists;
        }

        public List<SimplePlaylist> GetCreatedPlaylists()
        {
            var createdPlaylists =
                PlaylistsConverter.ToList(SpotifyApi.Spotify.GetUserPlaylists(SpotifyApi.CurrentUserId));
            var filteredPlaylists = createdPlaylists.Select(playlist => playlist)
                .Where(playlist => playlist.Owner.Id == SpotifyApi.CurrentUserId).ToList();

            return filteredPlaylists;
        }

        public List<SimplePlaylist> GetSpotifyFeaturedPlaylists()
        {
            var savedPlaylistsPaging = SpotifyApi.Spotify.GetFeaturedPlaylists().Playlists;
            var savedPlaylists = PlaylistsConverter.ToList(savedPlaylistsPaging);

            return savedPlaylists;
        }

        public FullPlaylist GetParticularPlaylist(string playlistId)
        {
            var playlist = SpotifyApi.Spotify.GetPlaylist(playlistId);
            return playlist;
        }
    }
}