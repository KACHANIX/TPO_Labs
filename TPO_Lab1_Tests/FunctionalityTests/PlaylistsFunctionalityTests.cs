using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.Functionality;

namespace TPO_Lab1_Tests.FunctionalityTests
{
    [TestClass]
    public class PlaylistsFunctionalityTests
    {
        [TestMethod]
        public void GetSavedPlaylists_ReturnsList()
        {
            var savedPlaylists = PlaylistsFunctionality.GetSavedPlaylists();
            Assert.AreNotEqual(0, savedPlaylists.Count);
        }
        [TestMethod]
        public void GetSavedPlaylists_ReturnsCorrectList()
        {
            var savedPlaylists = PlaylistsFunctionality.GetSavedPlaylists();
            Assert.AreEqual(false, savedPlaylists.Any(x=>x==null));
        }
        [TestMethod]
        public void GetCreatedPlaylists_ReturnsList()
        {
            var createdPlaylists = PlaylistsFunctionality.GetCreatedPlaylists();
            Assert.AreNotEqual(0, createdPlaylists.Count);
        }
        [TestMethod]
        public void GetCreatedPlaylists_ReturnsCorrectList()
        {
            var createdPlaylists = PlaylistsFunctionality.GetCreatedPlaylists();
            Assert.AreEqual(false, createdPlaylists.Any(x=>x==null));
        }
        [TestMethod]
        public void GetSpotifyFeaturedPlaylists_ReturnsList()
        {

            var featuredPlaylists = PlaylistsFunctionality.GetSpotifyFeaturedPlaylists();
            Assert.AreNotEqual(0, featuredPlaylists.Count);
        }
        [TestMethod]
        public void GetSpotifyFeaturedPlaylists_ReturnsCorrectList()
        {

            var featuredPlaylists = PlaylistsFunctionality.GetSpotifyFeaturedPlaylists();
            Assert.AreEqual(false, featuredPlaylists.Any(x=>x==null));
        }
        [TestMethod]
        public void GetParticularPlaylists_ReturnsPlaylist()
        {

            var playlist = PlaylistsFunctionality.GetParticularPlaylist("387bW3fRmQwvbKPxV2Jjm6");
            Assert.AreEqual(false, playlist.HasError());
        }
    }
}