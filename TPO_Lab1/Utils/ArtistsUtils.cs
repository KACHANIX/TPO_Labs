using System.Collections.Generic;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using TPO_Lab1.Converters;

namespace TPO_Lab1.Utils
{
    public class ArtistsUtils
    {
        private readonly ArtistsConverter _artistsConverter;
        private readonly AlbumsConverter _albumsConverter;
        private readonly SpotifyApi _spotifyApi;

        public ArtistsUtils(ArtistsConverter artistsConverter, AlbumsConverter albumsConverter, SpotifyApi spotifyApi)
        {
            _artistsConverter = artistsConverter;
            _albumsConverter = albumsConverter;
            _spotifyApi = spotifyApi;
        }

        public List<FullArtist> GetFollowedArtists()
        {
            var followedArtistsPaging = _spotifyApi.Spotify.GetFollowedArtists(FollowType.Artist).Artists;
            return _artistsConverter.ToList(followedArtistsPaging);
        }

        public List<FullArtist> GetTopArtists()
        {
            var topArtistsPaging = _spotifyApi.Spotify.GetUsersTopArtists();
            return _artistsConverter.ToList(topArtistsPaging);
        }

        public FullArtist GetParticularArtist(string artistId)
        {
            var artist = _spotifyApi.Spotify.GetArtist(artistId);
            return artist;
        }

        public List<FullArtist> GetRelatedArtists(string artistId)
        {
            var relatedArtists = _spotifyApi.Spotify.GetRelatedArtists(artistId);
            return relatedArtists.Artists;
        }

        public List<FullTrack> GetArtistsTopTracks(string artistId)
        {
            var tracks = _spotifyApi.Spotify.GetArtistsTopTracks(artistId, "US");
            return tracks.Tracks;
        }

        public List<SimpleAlbum> GetArtistsAlbums(string artistId)
        {
            var albums = _spotifyApi.Spotify.GetArtistsAlbums(artistId);
            return _albumsConverter.ToList(albums);
        }
    }
}