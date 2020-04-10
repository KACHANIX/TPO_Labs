using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.Converters;
using TPO_Lab1.Utils;

namespace TPO_Lab1_Tests.UtilsTests
{
    [TestClass]
    public class TracksUtilsTests
    {
        private readonly TracksUtils _tracksUtils;

        public TracksUtilsTests()
        {
            _tracksUtils=new TracksUtils(new TracksConverter(), GlobalTestInitializer.SpotifyApi);
        }
        [TestMethod]
        public void GetSavedTracks_ReturnsList()
        {
            var savedTracks = _tracksUtils.GetSavedTracks();
            Assert.AreNotEqual(0, savedTracks.Count);
        }

        [TestMethod]
        public void GetSavedTracks_ReturnsCorrectList()
        {
            var savedTracks = _tracksUtils.GetSavedTracks();
            Assert.AreEqual(false, savedTracks.Any(x => x == null));
        }

        [TestMethod]
        public void GetTopTracks_ReturnsList()
        {
            var topTracks = _tracksUtils.GetTopTracks();
            Assert.AreNotEqual(0, topTracks.Count);
        }

        [TestMethod]
        public void GetTopTracks_ReturnsCorrectList()
        {
            var topTracks = _tracksUtils.GetTopTracks();
            Assert.AreEqual(false, topTracks.Any(x => x == null));
        }

        [TestMethod]
        public void GetRecentlyPlayedTracks_ReturnsList()
        {
            var recentlyPlayedTracks = _tracksUtils.GetRecentlyPlayedTracks();
            Assert.AreNotEqual(0, recentlyPlayedTracks.Count);
        }

        [TestMethod]
        public void GetRecentlyPlayedTracks_ReturnsCorrectList()
        {
            var recentlyPlayedTracks = _tracksUtils.GetRecentlyPlayedTracks();
            Assert.AreEqual(false, recentlyPlayedTracks.Any(x => x == null));
        }

        [TestMethod]
        public void GetParticularTrack_ReturnsTrack()
        {
            var track = _tracksUtils.GetParticularTrack("4j4qNDbGDfOxAicmW0gK02");
            Assert.AreEqual(false, track.HasError());
        }
    }
}