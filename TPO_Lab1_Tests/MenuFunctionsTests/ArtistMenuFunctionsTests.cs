using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TPO_Lab1.Converters;
using TPO_Lab1.MenuFunctions;
using TPO_Lab1.MenuFunctions.Album;
using TPO_Lab1.MenuFunctions.Artist;
using TPO_Lab1.MenuFunctions.Track;
using TPO_Lab1.Menus.Generators;
using TPO_Lab1.Utils;

namespace TPO_Lab1_Tests.MenuFunctionsTests
{
    [TestClass]
    public class ArtistMenuFunctionsTests
    {
        private readonly ArtistMenuFunctions _artistMenuFunctions;

        public ArtistMenuFunctionsTests()
        {
            var exitFunctions = new ExitFunctions();
            var tracksConverter = new TracksConverter();
            var trackMenuFunctions = new TrackMenuFunctions(
                new TracksUtils(tracksConverter, GlobalTestInitializer.SpotifyApi),
                exitFunctions, GlobalTestInitializer.SpotifyApi);
            var tracksGenerator = new TracksGenerator(trackMenuFunctions, exitFunctions);
            var albumsGenerator =
                new AlbumsGenerator(
                    new AlbumMenuFunctions(new AlbumsUtils(new AlbumsConverter(), GlobalTestInitializer.SpotifyApi),
                        tracksConverter, exitFunctions, trackMenuFunctions, GlobalTestInitializer.SpotifyApi),
                    exitFunctions);
            _artistMenuFunctions =
                new ArtistMenuFunctions(
                    new ArtistsUtils(new ArtistsConverter(), new AlbumsConverter(), GlobalTestInitializer.SpotifyApi),
                    GlobalTestInitializer.SpotifyApi, tracksGenerator, albumsGenerator, exitFunctions);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FollowFollowedArtist_ThrowsException()
        {
            _artistMenuFunctions.FollowArtist("1LeVJ5GPeYDOVUjxx1y7Rp");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnfollowUnFollowedArtist_ThrowsException()
        {
            _artistMenuFunctions.UnfollowArtist("3jK9MiCrA42lLAdMGUZpwa");
        }
    }
}