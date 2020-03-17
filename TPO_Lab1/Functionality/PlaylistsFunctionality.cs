using SpotifyAPI.Web.Models;
using System.Collections.Generic;
using System.Linq;
using TPO_Lab1.Mappers;

namespace TPO_Lab1.Functionality
{
    public static class PlaylistsFunctionality
    {
        public static List<SimplePlaylist> GetSavedPlaylists()
        {
            var savedPlaylists =
                PlaylistsMapper.ToList(SpotifyApi.Spotify.GetUserPlaylists(SpotifyApi.CurrentUserId));
            var filteredPlaylists = savedPlaylists.Select(playlist => playlist)
                .Where(playlist => playlist.Owner.Id != SpotifyApi.CurrentUserId).ToList();

            return filteredPlaylists;
        }

        public static List<SimplePlaylist> CreatedPlaylists()
        {
            var createdPlaylists =
                PlaylistsMapper.ToList(SpotifyApi.Spotify.GetUserPlaylists(SpotifyApi.CurrentUserId));
            var filteredPlaylists = createdPlaylists.Select(playlist => playlist)
                .Where(playlist => playlist.Owner.Id == SpotifyApi.CurrentUserId).ToList();

            return filteredPlaylists;
        }

        public static List<SimplePlaylist> SpotifyFeaturedPlaylists()
        {
            var savedPlaylistsPaging = SpotifyApi.Spotify.GetFeaturedPlaylists().Playlists;
            var savedPlaylists = PlaylistsMapper.ToList(savedPlaylistsPaging);

            return savedPlaylists;
        }

        public static FullPlaylist GetParticularPlaylist(string playlistId)
        {
            var playlist = SpotifyApi.Spotify.GetPlaylist(playlistId);
            return playlist;
        }
    }
}