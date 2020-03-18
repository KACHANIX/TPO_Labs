using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.MenuFunctions.Artist;

namespace TPO_Lab1_Tests.MenuFunctionsTests
{
    [TestClass]
    public class ArtistMenuFunctionsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FollowFollowedArtist_ThrowsException()
        {
            ArtistMenuFunctions.FollowArtist("1LeVJ5GPeYDOVUjxx1y7Rp");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnfollowUnfollowedArtist_ThrowsException()
        {
            ArtistMenuFunctions.UnfollowArtist("3jK9MiCrA42lLAdMGUZpwa");
        }
    }
}
