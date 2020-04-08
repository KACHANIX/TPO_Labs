using System.Collections.Generic;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using TPO_Lab1.Converters;

namespace TPO_Lab1.Utils
{
    public class ArtistsUtils
    {
        public ArtistsConverter ArtistsConverter { get; set; }
        public AlbumsConverter AlbumsConverter { get; set; }
        public SpotifyApi SpotifyApi { get; set; }

        public ArtistsUtils(ArtistsConverter artistsConverter, AlbumsConverter albumsConverter, SpotifyApi spotifyApi)
        {
            ArtistsConverter = artistsConverter;
            AlbumsConverter = albumsConverter;
            SpotifyApi = spotifyApi;
        }

        public List<FullArtist> GetFollowedArtists()
        {
            var followedArtistsPaging = SpotifyApi.Spotify.GetFollowedArtists(FollowType.Artist).Artists;
            return ArtistsConverter.ToList(followedArtistsPaging);
        }

        public List<FullArtist> GetTopArtists()
        {
            var topArtistsPaging = SpotifyApi.Spotify.GetUsersTopArtists();
            return ArtistsConverter.ToList(topArtistsPaging);
        }

        public FullArtist GetParticularArtist(string artistId)
        {
            var artist = SpotifyApi.Spotify.GetArtist(artistId);
            return artist;
        }

        public List<FullArtist> GetRelatedArtists(string artistId)
        {
            var relatedArtists = SpotifyApi.Spotify.GetRelatedArtists(artistId);
            return relatedArtists.Artists;
        }

        public List<FullTrack> GetArtistsTopTracks(string artistId)
        {
            var tracks = SpotifyApi.Spotify.GetArtistsTopTracks(artistId, "US");
            return tracks.Tracks;
        }

        public List<SimpleAlbum> GetArtistsAlbums(string artistId)
        {
            var albums = SpotifyApi.Spotify.GetArtistsAlbums(artistId);
            return AlbumsConverter.ToList(albums);
        }
    }
}