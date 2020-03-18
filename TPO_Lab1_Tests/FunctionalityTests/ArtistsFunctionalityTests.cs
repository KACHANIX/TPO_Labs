using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.Functionality;

namespace TPO_Lab1_Tests.FunctionalityTests
{
    [TestClass]
    public class ArtistsFunctionalityTests
    {
        [TestMethod]
        public void GetFollowedArtists_ReturnsList()
        {
            var followedArtists = ArtistsFunctionality.GetFollowedArtists();
            Assert.AreNotEqual(0, followedArtists.Count);
        }

        [TestMethod]
        public void GetTopArtists_ReturnsList()
        {
            var followedArtists = ArtistsFunctionality.GetTopArtists();
            Assert.AreNotEqual(0, followedArtists.Count);
        }

        [TestMethod]
        public void GetParticularArtist_ReturnsArtist()
        {
            var artist = ArtistsFunctionality.GetParticularArtist("1VPmR4DJC1PlOtd0IADAO0");
            Assert.AreEqual(false, artist.HasError());
        }

        [TestMethod]
        public void GetRelatedArtists_ReturnsList()
        {
            var relatedArtists = ArtistsFunctionality.GetRelatedArtists("1VPmR4DJC1PlOtd0IADAO0");
            Assert.AreNotEqual(0, relatedArtists.Count);
        }

        [TestMethod]
        public void GetArtistsTopTracks_ReturnsList()
        {
            var topTracks = ArtistsFunctionality.GetArtistsTopTracks("1VPmR4DJC1PlOtd0IADAO0");
            Assert.AreNotEqual(0, topTracks.Count);
        }

        [TestMethod]
        public void GetArtistsAlbums_ReturnsList()
        {
            var artistsAlbums = ArtistsFunctionality.GetArtistsAlbums("1VPmR4DJC1PlOtd0IADAO0");
            Assert.AreNotEqual(0, artistsAlbums.Count);
        }
    }
}