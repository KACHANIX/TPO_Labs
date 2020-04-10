using SpotifyAPI.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using TPO_Lab1.Menus.BasicModelMenu;
using TPO_Lab1.Menus.Generators;
using TPO_Lab1.Utils;

namespace TPO_Lab1.MenuFunctions.Artist
{
    public class ArtistMenuFunctions
    {
        private readonly ArtistsUtils _artistsUtils;
        private readonly SpotifyApi _spotifyApi;
        private readonly TracksGenerator _tracksGenerator;
        private readonly AlbumsGenerator _albumsGenerator;
        private readonly ExitFunctions _exitFunctions;

        public ArtistMenuFunctions(ArtistsUtils artistsUtils, SpotifyApi spotifyApi, TracksGenerator tracksGenerator,
            AlbumsGenerator albumsGenerator, ExitFunctions exitFunctions)
        {
            _artistsUtils = artistsUtils;
            _spotifyApi = spotifyApi;
            _tracksGenerator = tracksGenerator;
            _albumsGenerator = albumsGenerator;
            _exitFunctions = exitFunctions;
        }

        public bool GetArtist(string artistId)
        {
            var artist = _artistsUtils.GetParticularArtist(artistId);

            var artistMenu = new BasicModelMenu();
            artistMenu.AddItem($"Related Artists", GetRelatedArtists, "1", artistId);
            artistMenu.AddItem($"Artist's Top Tracks", GetArtistTopTracks, "2", artistId);
            artistMenu.AddItem($"Artist's Albums", GetArtistsAlbums, "3", artistId);
            artistMenu.AddItem($"Follow Artist", FollowArtist, "4", artistId);
            artistMenu.AddItem($"UnfollowArtist", UnfollowArtist, "5", artistId);
            artistMenu.AddItem($"Exit", _exitFunctions.Exit, "6", null);
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
            var relatedArtists = _artistsUtils.GetRelatedArtists(artistId);
            var artistsMenu = new BasicModelMenu();
            int i = 1;
            relatedArtists.ForEach(artist =>
                artistsMenu.AddItem(artist.Name, GetArtist, i++.ToString(), artist.Id));
            artistsMenu.AddItem("Exit", _exitFunctions.Exit, i.ToString(), null);
            bool running = true;
            while (running)
            {
                running = artistsMenu.Display();
            }

            return true;
        }

        public bool GetArtistTopTracks(string artistId)
        {
            var artistsTopTracks = _artistsUtils.GetArtistsTopTracks(artistId);
            var tracksMenu = _tracksGenerator.GenerateTracks(artistsTopTracks);
            bool running = true;
            while (running)
            {
                running = tracksMenu.Display();
            }

            return true;
        }

        public bool GetArtistsAlbums(string artistId)
        {
            var artistsAlbums = _artistsUtils.GetArtistsAlbums(artistId);
            var tracksMenu = _albumsGenerator.GenerateAlbums(artistsAlbums);
            bool running = true;
            while (running)
            {
                running = tracksMenu.Display();
            }

            return true;
        }

        public bool FollowArtist(string artistId)
        {
            bool isFollowed = _artistsUtils.GetFollowedArtists().Any(artist => artist.Id == artistId);
            if (isFollowed)
                throw new ArgumentException("Artist is already followed.");
            _spotifyApi.Spotify.Follow(FollowType.Artist, new List<string>() {artistId});
            return true;
        }

        public bool UnfollowArtist(string artistId)
        {
            bool isFollowed = _artistsUtils.GetFollowedArtists().Any(artist => artist.Id == artistId);
            if (!isFollowed)
                throw new ArgumentException("Artist isn't followed.");
            _spotifyApi.Spotify.Unfollow(FollowType.Artist, new List<string>() {artistId});
            return true;
        }
    }
}