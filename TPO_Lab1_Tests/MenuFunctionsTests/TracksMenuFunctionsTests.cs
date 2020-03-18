using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.MenuFunctions.Track;

namespace TPO_Lab1_Tests.MenuFunctionsTests
{
    [TestClass]
    public class TracksMenuFunctionsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FollowFollowedPlaylist_ThrowsException()
        {
            TrackMenuFunctions.SaveTrack("3DPFmwFtV5ElQaTniLOdgk");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnfollowUnfollowedPlaylist_ThrowsException()
        {
            TrackMenuFunctions.RemoveSavedTrack("3LiLe6IClT2z8WTr7G1LER");
        }
    }
}