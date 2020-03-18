using System;
using System.Collections.Generic;
using System.Linq;
using SpotifyAPI.Web.Enums;
using TPO_Lab1.Functionality;
using TPO_Lab1.Menus;

namespace TPO_Lab1.MenuFunctions.Artist
{
    public static class ArtistMenuFunctions
    {
        public static bool GetArtist(string artistId)
        {
            var artist = ArtistsFunctionality.GetParticularArtist(artistId);

            var artistMenu = MenuGenerator.GenerateArtist(artistId);
            bool running = true;
            while (running)
            {
                IO.WriteLine(
                    $"Artist: {artist.Name}\nFollowers: {artist.Followers.Total}\nPopularity: {artist.Popularity}");
                running = artistMenu.Display();
            }

            return true;
        }

        public static bool GetRelatedArtists(string artistId)
        {
            var relatedArtists = ArtistsFunctionality.GetRelatedArtists(artistId);
            var artistsMenu = MenuGenerator.GenerateArtists(relatedArtists);
            bool running = true;
            while (running)
            {
                running = artistsMenu.Display();
            }

            return true;
        }

        public static bool GetArtistTopTracks(string artistId)
        {
            var artistsTopTracks = ArtistsFunctionality.GetArtistsTopTracks(artistId);
            var tracksMenu = MenuGenerator.GenerateTracks(artistsTopTracks);
            bool running = true;
            while (running)
            {
                running = tracksMenu.Display();
            }

            return true;
        }

        public static bool GetArtistsAlbums(string artistId)
        {
            var artistsAlbums = ArtistsFunctionality.GetArtistsAlbums(artistId);
            var tracksMenu = MenuGenerator.GenerateAlbums(artistsAlbums);
            bool running = true;
            while (running)
            {
                running = tracksMenu.Display();
            }

            return true;
        }

        public static bool FollowArtist(string artistId)
        {
            bool isFollowed = ArtistsFunctionality.GetFollowedArtists().Any(artist => artist.Id==artistId);
            if (isFollowed)
                throw new ArgumentException("Artist is already followed.");
            SpotifyApi.Spotify.Follow(FollowType.Artist, new List<string>() {artistId});
            return true;
        }

        public static bool UnfollowArtist(string artistId)
        {

            bool isFollowed = ArtistsFunctionality.GetFollowedArtists().Any(artist => artist.Id == artistId);
            if (!isFollowed)
                throw new ArgumentException("Artist isn't followed.");
            SpotifyApi.Spotify.Unfollow(FollowType.Artist, new List<string>() { artistId });
            return true;
        }
    }
}