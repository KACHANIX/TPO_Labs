using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.Functionality;

namespace TPO_Lab1_Tests.FunctionalityTests
{
    [TestClass]
    public class TracksFunctionalityTests
    {
        [TestMethod]
        public void GetSavedTracks_ReturnsList()
        {
            var savedTracks = TracksFunctionality.GetSavedTracks();
            Assert.AreNotEqual(0, savedTracks.Count);
        }
        [TestMethod]
        public void GetTopTracks_ReturnsList()
        {
            var topTracks = TracksFunctionality.GetTopTracks();
            Assert.AreNotEqual(0, topTracks.Count);
        }
        [TestMethod]
        public void GetRecentlyPlayedTracks_ReturnsList()
        {
            var recentlyPlayedTracks = TracksFunctionality.GetRecentlyPlayedTracks();
            Assert.AreNotEqual(0, recentlyPlayedTracks.Count);
        }
        [TestMethod]
        public void GetParticularTrack_ReturnsTrack()
        {
            var track = TracksFunctionality.GetParticularTrack("4j4qNDbGDfOxAicmW0gK02");
            Assert.AreEqual(false, track.HasError());
        }

    }
}