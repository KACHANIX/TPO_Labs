using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System.Collections.Generic;
using TPO_Lab1.Converters;

namespace TPO_Lab1.Functionality
{
    public static class ArtistsFunctionality
    {
        public static List<FullArtist> GetFollowedArtists()
        {
            var followedArtistsPaging = SpotifyApi.Spotify.GetFollowedArtists(FollowType.Artist).Artists;
            return ArtistsConverter.ToList(followedArtistsPaging);
        }

        public static List<FullArtist> GetTopArtists()
        {
            var topArtistsPaging = SpotifyApi.Spotify.GetUsersTopArtists();
            return ArtistsConverter.ToList(topArtistsPaging);
        }

        public static FullArtist GetParticularArtist(string artistId)
        {
            var artist = SpotifyApi.Spotify.GetArtist(artistId);
            return artist;
        }

        public static List<FullArtist> GetRelatedArtists(string artistId)
        {
            var relatedArtists = SpotifyApi.Spotify.GetRelatedArtists(artistId);
            return relatedArtists.Artists;
        }

        public static List<FullTrack> GetArtistsTopTracks(string artistId)
        {
            var tracks = SpotifyApi.Spotify.GetArtistsTopTracks(artistId, "US");
            return tracks.Tracks;
        }

        public static List<SimpleAlbum> GetArtistsAlbums(string artistId)
        {
            var albums = SpotifyApi.Spotify.GetArtistsAlbums(artistId);
            return AlbumsConverter.ToList(albums);
        }
    }
}