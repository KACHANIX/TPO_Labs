using SpotifyAPI.Web.Models;
using System.Collections.Generic;
using TPO_Lab1.Converters;

namespace TPO_Lab1.Functionality
{
    public static class AlbumsFunctionality
    {
        public static List<FullAlbum> GetSavedAlbums()
        {
            var savedAlbums = SpotifyApi.Spotify.GetSavedAlbums();
            return AlbumsConverter.ToList(savedAlbums);
        }

        public static List<SimpleAlbum> GetNewAlbumReleases()
        {
            var newAlbums = SpotifyApi.Spotify.GetNewAlbumReleases().Albums;
            return AlbumsConverter.ToList(newAlbums);
        }

        public static FullAlbum GetParticularAlbum(string albumId)
        {
            return SpotifyApi.Spotify.GetAlbum(albumId);
        }
    }
}