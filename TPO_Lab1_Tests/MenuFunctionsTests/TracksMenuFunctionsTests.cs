using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TPO_Lab1.Converters;
using TPO_Lab1.MenuFunctions;
using TPO_Lab1.MenuFunctions.Track;
using TPO_Lab1.Utils;

namespace TPO_Lab1_Tests.MenuFunctionsTests
{
    [TestClass]
    public class TracksMenuFunctionsTests
    {
        private readonly TrackMenuFunctions _trackMenuFunctions;

        public TracksMenuFunctionsTests()
        {
            var tracksUtils = new TracksUtils(new TracksConverter(), GlobalTestInitializer.SpotifyApi);
            var exitFunctions = new ExitFunctions();
            _trackMenuFunctions =
                new TrackMenuFunctions(tracksUtils, exitFunctions, GlobalTestInitializer.SpotifyApi);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FollowFollowedPlaylist_ThrowsException()
        {
            _trackMenuFunctions.SaveTrack("3DPFmwFtV5ElQaTniLOdgk");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnfollowUnfollowedPlaylist_ThrowsException()
        {
            _trackMenuFunctions.RemoveSavedTrack("3LiLe6IClT2z8WTr7G1LER");
        }
    }
}