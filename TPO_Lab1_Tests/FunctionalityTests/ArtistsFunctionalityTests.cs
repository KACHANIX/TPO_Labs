﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.Utils;

namespace TPO_Lab1_Tests.FunctionalityTests
{
    [TestClass]
    public class ArtistsFunctionalityTests
    {
        [TestMethod]
        public void GetFollowedArtists_ReturnsList()
        {
            var followedArtists = ArtistsUtils.GetFollowedArtists();
            Assert.AreNotEqual(0, followedArtists.Count);
        }
        [TestMethod]
        public void GetFollowedArtists_ReturnsCorrectList()
        {
            var followedArtists = ArtistsUtils.GetFollowedArtists();
            Assert.AreEqual(false, followedArtists.Any(x=>x==null));
        }

        [TestMethod]
        public void GetTopArtists_ReturnsList()
        {
            var topArtists = ArtistsUtils.GetTopArtists();
            Assert.AreNotEqual(0, topArtists.Count);
        }
        [TestMethod]
        public void GetTopArtists_ReturnsCorrectList()
        {
            var topArtists = ArtistsUtils.GetTopArtists();
            Assert.AreEqual(false, topArtists.Any(x => x == null));
        }

        [TestMethod]
        public void GetParticularArtist_ReturnsArtist()
        {
            var artist = ArtistsUtils.GetParticularArtist("1VPmR4DJC1PlOtd0IADAO0");
            Assert.AreEqual(false, artist.HasError());
        }

        [TestMethod]
        public void GetRelatedArtists_ReturnsList()
        {
            var relatedArtists = ArtistsUtils.GetRelatedArtists("1VPmR4DJC1PlOtd0IADAO0");
            Assert.AreNotEqual(0, relatedArtists.Count);
        }
        [TestMethod]
        public void GetRelatedArtists_ReturnsCorrectList()
        {
            var relatedArtists = ArtistsUtils.GetRelatedArtists("1VPmR4DJC1PlOtd0IADAO0");
            Assert.AreEqual(false, relatedArtists.Any(x=>x==null));
        }

        [TestMethod]
        public void GetArtistsTopTracks_ReturnsList()
        {
            var topTracks = ArtistsUtils.GetArtistsTopTracks("1VPmR4DJC1PlOtd0IADAO0");
            Assert.AreNotEqual(0, topTracks.Count);
        }
        [TestMethod]
        public void GetArtistsTopTracks_ReturnsCorrectList()
        {
            var topTracks = ArtistsUtils.GetArtistsTopTracks("1VPmR4DJC1PlOtd0IADAO0");
            Assert.AreEqual(false, topTracks.Any(x=>x==null));
        }

        [TestMethod]
        public void GetArtistsAlbums_ReturnsList()
        {
            var artistsAlbums = ArtistsUtils.GetArtistsAlbums("1VPmR4DJC1PlOtd0IADAO0");
            Assert.AreNotEqual(0, artistsAlbums.Count);
        }
        [TestMethod]
        public void GetArtistsAlbums_ReturnsCorrectList()
        {
            var artistsAlbums = ArtistsUtils.GetArtistsAlbums("1VPmR4DJC1PlOtd0IADAO0");
            Assert.AreEqual(false, artistsAlbums.Any(x=>x==null));
        }
    }
}