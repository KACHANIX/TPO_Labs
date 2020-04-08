using System.Collections.Generic;
using SpotifyAPI.Web.Models;
using TPO_Lab1.Converters;

namespace TPO_Lab1.Utils
{
    public class AlbumsUtils
    {
        public SpotifyApi SpotifyApi { get; set; }
        public AlbumsConverter AlbumConverter { get; set; }
        public AlbumsUtils(AlbumsConverter albumConverter, SpotifyApi spotifyApi)
        {
            AlbumConverter = albumConverter;
            SpotifyApi = spotifyApi;
        }
        public List<FullAlbum> GetSavedAlbums()
        {
            var savedAlbums = SpotifyApi.Spotify.GetSavedAlbums();
            return AlbumConverter.ToList(savedAlbums);
        }

        public List<SimpleAlbum> GetNewAlbumReleases()
        {
            var newAlbums = SpotifyApi.Spotify.GetNewAlbumReleases().Albums;
            return AlbumConverter.ToList(newAlbums);
        }

        public FullAlbum GetParticularAlbum(string albumId)
        {
            return SpotifyApi.Spotify.GetAlbum(albumId);
        }
    }
}