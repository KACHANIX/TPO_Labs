using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.MenuFunctions.Playlist;

namespace TPO_Lab1_Tests.MenuFunctionsTests
{
    [TestClass]
    public class PlaylistMenuFunctionsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FollowFollowedPlaylist_ThrowsException()
        {
            PlaylistMenuFunctions.FollowPlaylist("0vvXsWCC9xrXsKd4FyS8kM");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnfollowUnfollowedPlaylist_ThrowsException()
        {
            PlaylistMenuFunctions.UnfollowPlaylist("37i9dQZF1DXdURFimg6Blm");
        }
    }
}