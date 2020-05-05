using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TPO_Lab1.Converters;
using TPO_Lab1.MenuFunctions;
using TPO_Lab1.MenuFunctions.Playlist;
using TPO_Lab1.MenuFunctions.Track;
using TPO_Lab1.Utils;

namespace TPO_Lab1_Tests.MenuFunctionsTests
{
    [TestClass]
    public class PlaylistMenuFunctionsTests
    {
        private readonly PlaylistMenuFunctions _playlistMenuFunctions;

        public PlaylistMenuFunctionsTests()
        {
            var tracksUtils = new TracksUtils(new TracksConverter(), GlobalTestInitializer.SpotifyApi);
            var exitFunctions = new ExitFunctions();
            var trackMenuFunctions =
                new TrackMenuFunctions(tracksUtils, exitFunctions, GlobalTestInitializer.SpotifyApi);
            var tracksConverter = new TracksConverter();
            var playlistConverter = new PlaylistsConverter();
            var playlistUtils = new PlaylistsUtils(playlistConverter, GlobalTestInitializer.SpotifyApi);

            _playlistMenuFunctions = new PlaylistMenuFunctions(tracksConverter, playlistUtils, trackMenuFunctions,
                exitFunctions, GlobalTestInitializer.SpotifyApi);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FollowFollowedPlaylist_ThrowsException()
        {
            _playlistMenuFunctions.FollowPlaylist("0vvXsWCC9xrXsKd4FyS8kM");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnfollowUnfollowedPlaylist_ThrowsException()
        {
            _playlistMenuFunctions.UnfollowPlaylist("37i9dQZF1DXdURFimg6Blm");
        }
    }
}