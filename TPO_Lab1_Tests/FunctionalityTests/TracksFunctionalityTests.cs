using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TPO_Lab1.Utils;

namespace TPO_Lab1_Tests.FunctionalityTests
{
    [TestClass]
    public class TracksFunctionalityTests
    {
        [TestMethod]
        public void GetSavedTracks_ReturnsList()
        {
            var savedTracks = TracksUtils.GetSavedTracks();
            Assert.AreNotEqual(0, savedTracks.Count);
        }

        [TestMethod]
        public void GetSavedTracks_ReturnsCorrectList()
        {
            var savedTracks = TracksUtils.GetSavedTracks();
            Assert.AreEqual(false, savedTracks.Any(x => x == null));
        }

        [TestMethod]
        public void GetTopTracks_ReturnsList()
        {
            var topTracks = TracksUtils.GetTopTracks();
            Assert.AreNotEqual(0, topTracks.Count);
        }

        [TestMethod]
        public void GetTopTracks_ReturnsCorrectList()
        {
            var topTracks = TracksUtils.GetTopTracks();
            Assert.AreEqual(false, topTracks.Any(x => x == null));
        }

        [TestMethod]
        public void GetRecentlyPlayedTracks_ReturnsList()
        {
            var recentlyPlayedTracks = TracksUtils.GetRecentlyPlayedTracks();
            Assert.AreNotEqual(0, recentlyPlayedTracks.Count);
        }

        [TestMethod]
        public void GetRecentlyPlayedTracks_ReturnsCorrectList()
        {
            var recentlyPlayedTracks = TracksUtils.GetRecentlyPlayedTracks();
            Assert.AreEqual(false, recentlyPlayedTracks.Any(x => x == null));
        }

        [TestMethod]
        public void GetParticularTrack_ReturnsTrack()
        {
            var track = TracksUtils.GetParticularTrack("4j4qNDbGDfOxAicmW0gK02");
            Assert.AreEqual(false, track.HasError());
        }
    }
}