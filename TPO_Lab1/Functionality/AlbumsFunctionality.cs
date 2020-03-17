using SpotifyAPI.Web.Models;
using System.Collections.Generic;
using TPO_Lab1.Mappers;

namespace TPO_Lab1.Functionality
{
    public static class AlbumsFunctionality
    {
        public static List<FullAlbum> GetSavedAlbums()
        {
            var savedAlbums = SpotifyApi.Spotify.GetSavedAlbums();
            return AlbumsMapper.ToList(savedAlbums);
        }

        public static List<SimpleAlbum> GetNewAlbumReleases()
        {
            var newAlbums = SpotifyApi.Spotify.GetNewAlbumReleases().Albums;
            return AlbumsMapper.ToList(newAlbums);
        }

        public static FullAlbum GetParticularAlbum(string albumId)
        {
            return SpotifyApi.Spotify.GetAlbum(albumId);
        }
    }
}