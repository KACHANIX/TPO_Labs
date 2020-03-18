using SpotifyAPI.Web.Models;
using System.Collections.Generic;
using System.Linq;
using TPO_Lab1.Converters;

namespace TPO_Lab1.Functionality
{
    public static class PlaylistsFunctionality
    {
        public static List<SimplePlaylist> GetSavedPlaylists()
        {
            var savedPlaylists =
                PlaylistsConverter.ToList(SpotifyApi.Spotify.GetUserPlaylists(SpotifyApi.CurrentUserId));
            var filteredPlaylists = savedPlaylists.Select(playlist => playlist)
                .Where(playlist => playlist.Owner.Id != SpotifyApi.CurrentUserId).ToList();

            return filteredPlaylists;
        }

        public static List<SimplePlaylist> GetCreatedPlaylists()
        {
            var createdPlaylists =
                PlaylistsConverter.ToList(SpotifyApi.Spotify.GetUserPlaylists(SpotifyApi.CurrentUserId));
            var filteredPlaylists = createdPlaylists.Select(playlist => playlist)
                .Where(playlist => playlist.Owner.Id == SpotifyApi.CurrentUserId).ToList();

            return filteredPlaylists;
        }

        public static List<SimplePlaylist> GetSpotifyFeaturedPlaylists()
        {
            var savedPlaylistsPaging = SpotifyApi.Spotify.GetFeaturedPlaylists().Playlists;
            var savedPlaylists = PlaylistsConverter.ToList(savedPlaylistsPaging);

            return savedPlaylists;
        }

        public static FullPlaylist GetParticularPlaylist(string playlistId)
        {
            var playlist = SpotifyApi.Spotify.GetPlaylist(playlistId);
            return playlist;
        }
    }
}