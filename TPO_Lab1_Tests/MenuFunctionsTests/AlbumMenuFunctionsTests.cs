using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TPO_Lab1.Converters;
using TPO_Lab1.MenuFunctions;
using TPO_Lab1.MenuFunctions.Album;
using TPO_Lab1.MenuFunctions.Track;
using TPO_Lab1.Utils;

namespace TPO_Lab1_Tests.MenuFunctionsTests
{
    [TestClass]
    public class AlbumMenuFunctionsTests
    {
        private readonly AlbumMenuFunctions _albumMenuFunctions;

        public AlbumMenuFunctionsTests()
        {
            var albumUtils = new AlbumsUtils(new AlbumsConverter(), GlobalTestInitializer.SpotifyApi);
            var tracksUtils = new TracksUtils(new TracksConverter(), GlobalTestInitializer.SpotifyApi);
            var exitFunctions = new ExitFunctions();
            var trackMenuFunctions =
                new TrackMenuFunctions(tracksUtils, exitFunctions, GlobalTestInitializer.SpotifyApi);
            var tracksConverter = new TracksConverter();
            _albumMenuFunctions = new AlbumMenuFunctions(albumUtils, tracksConverter, exitFunctions, trackMenuFunctions,
                GlobalTestInitializer.SpotifyApi);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SaveSavedAlbum_ThrowsException()
        {
            _albumMenuFunctions.SaveAlbum("7c2Xfq7aQKzs0KdSI3K7Rc");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveUnsavedAlbum_ThrowsException()
        {
            _albumMenuFunctions.RemoveSavedAlbum("27XsTKRj3plTMzIOIZlUL3");
        }
    }
}