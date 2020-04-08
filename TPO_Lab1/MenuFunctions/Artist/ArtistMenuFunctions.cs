using System;
using System.Collections.Generic;
using System.Linq;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using TPO_Lab1.Menus;
using TPO_Lab1.Menus.BasicModelMenu;
using TPO_Lab1.Menus.Generators;
using TPO_Lab1.Utils;

namespace TPO_Lab1.MenuFunctions.Artist
{
    public class ArtistMenuFunctions
    {
        public ArtistsUtils ArtistsUtils { get; set; }
        public SpotifyApi SpotifyApi { get; set; }
        public TracksGenerator TracksGenerator { get; set; }
        public AlbumsGenerator AlbumsGenerator { get; set; }
        public ExitFunctions ExitFunctions { get; set; }

        public ArtistMenuFunctions(ArtistsUtils artistsUtils, SpotifyApi spotifyApi, TracksGenerator tracksGenerator,
            AlbumsGenerator albumsGenerator, ExitFunctions exitFunctions)
        {
            ArtistsUtils = artistsUtils;
            SpotifyApi = spotifyApi;
            TracksGenerator = tracksGenerator;
            AlbumsGenerator = albumsGenerator;
            ExitFunctions = exitFunctions;
        }

        public bool GetArtist(string artistId)
        {
            var artist = ArtistsUtils.GetParticularArtist(artistId);

            var artistMenu = new BasicModelMenu();
            artistMenu.AddItem($"Related Artists", GetRelatedArtists, "1", artistId);
            artistMenu.AddItem($"Artist's Top Tracks", GetArtistTopTracks, "2", artistId);
            artistMenu.AddItem($"Artist's Albums", GetArtistsAlbums, "3", artistId);
            artistMenu.AddItem($"Follow Artist", FollowArtist, "4", artistId);
            artistMenu.AddItem($"UnfollowArtist", UnfollowArtist, "5", artistId);
            artistMenu.AddItem($"Exit", ExitFunctions.Exit, "6", null);
            bool running = true;
            while (running)
            {
                IO.WriteLine(
                    $"Artist: {artist.Name}\nFollowers: {artist.Followers.Total}\nPopularity: {artist.Popularity}");
                running = artistMenu.Display();
            }

            return true;
        }

        public bool GetRelatedArtists(string artistId)
        {
            var relatedArtists = ArtistsUtils.GetRelatedArtists(artistId);
            var artistsMenu = new BasicModelMenu();
            int i = 1;
            relatedArtists.ForEach(artist =>
                artistsMenu.AddItem(artist.Name, GetArtist, i++.ToString(), artist.Id));
            artistsMenu.AddItem("Exit", ExitFunctions.Exit, i.ToString(), null);
            bool running = true;
            while (running)
            {
                running = artistsMenu.Display();
            }

            return true;
        }

        public bool GetArtistTopTracks(string artistId)
        {
            var artistsTopTracks = ArtistsUtils.GetArtistsTopTracks(artistId);
            var tracksMenu = TracksGenerator.GenerateTracks(artistsTopTracks);
            bool running = true;
            while (running)
            {
                running = tracksMenu.Display();
            }

            return true;
        }

        public bool GetArtistsAlbums(string artistId)
        {
            var artistsAlbums = ArtistsUtils.GetArtistsAlbums(artistId);
            var tracksMenu = AlbumsGenerator.GenerateAlbums(artistsAlbums);
            bool running = true;
            while (running)
            {
                running = tracksMenu.Display();
            }

            return true;
        }

        public bool FollowArtist(string artistId)
        {
            bool isFollowed = ArtistsUtils.GetFollowedArtists().Any(artist => artist.Id == artistId);
            if (isFollowed)
                throw new ArgumentException("Artist is already followed.");
            SpotifyApi.Spotify.Follow(FollowType.Artist, new List<string>() {artistId});
            return true;
        }

        public bool UnfollowArtist(string artistId)
        {
            bool isFollowed = ArtistsUtils.GetFollowedArtists().Any(artist => artist.Id == artistId);
            if (!isFollowed)
                throw new ArgumentException("Artist isn't followed.");
            SpotifyApi.Spotify.Unfollow(FollowType.Artist, new List<string>() {artistId});
            return true;
        }
    }
}