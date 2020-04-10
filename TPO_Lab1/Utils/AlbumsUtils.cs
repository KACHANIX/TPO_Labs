using System.Collections.Generic;
using SpotifyAPI.Web.Models;
using TPO_Lab1.Converters;

namespace TPO_Lab1.Utils
{
    public class AlbumsUtils
    {
        private readonly SpotifyApi _spotifyApi;
        private readonly AlbumsConverter _albumConverter;

        public AlbumsUtils(AlbumsConverter albumConverter, SpotifyApi spotifyApi)
        {
            _albumConverter = albumConverter;
            _spotifyApi = spotifyApi;
        }

        public List<FullAlbum> GetSavedAlbums()
        {
            var savedAlbums = _spotifyApi.Spotify.GetSavedAlbums();
            return _albumConverter.ToList(savedAlbums);
        }

        public List<SimpleAlbum> GetNewAlbumReleases()
        {
            var newAlbums = _spotifyApi.Spotify.GetNewAlbumReleases().Albums;
            return _albumConverter.ToList(newAlbums);
        }

        public FullAlbum GetParticularAlbum(string albumId)
        {
            return _spotifyApi.Spotify.GetAlbum(albumId);
        }
    }
}