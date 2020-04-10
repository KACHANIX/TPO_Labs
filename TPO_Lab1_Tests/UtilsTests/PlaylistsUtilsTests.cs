using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.Converters;
using TPO_Lab1.Utils;

namespace TPO_Lab1_Tests.UtilsTests
{
    [TestClass]
    public class PlaylistsUtilsTests
    {
        private readonly PlaylistsUtils _playlistsUtils;

        public PlaylistsUtilsTests()
        {
            _playlistsUtils=new PlaylistsUtils(new PlaylistsConverter(), GlobalTestInitializer.SpotifyApi);
        }
        [TestMethod]
        public void GetSavedPlaylists_ReturnsList()
        {
            var savedPlaylists = _playlistsUtils.GetSavedPlaylists();
            Assert.AreNotEqual(0, savedPlaylists.Count);
        }
        [TestMethod]
        public void GetSavedPlaylists_ReturnsCorrectList()
        {
            var savedPlaylists = _playlistsUtils.GetSavedPlaylists();
            Assert.AreEqual(false, savedPlaylists.Any(x=>x==null));
        }
        [TestMethod]
        public void GetCreatedPlaylists_ReturnsList()
        {
            var createdPlaylists = _playlistsUtils.GetCreatedPlaylists();
            Assert.AreNotEqual(0, createdPlaylists.Count);
        }
        [TestMethod]
        public void GetCreatedPlaylists_ReturnsCorrectList()
        {
            var createdPlaylists = _playlistsUtils.GetCreatedPlaylists();
            Assert.AreEqual(false, createdPlaylists.Any(x=>x==null));
        }
        [TestMethod]
        public void GetSpotifyFeaturedPlaylists_ReturnsList()
        {

            var featuredPlaylists = _playlistsUtils.GetSpotifyFeaturedPlaylists();
            Assert.AreNotEqual(0, featuredPlaylists.Count);
        }
        [TestMethod]
        public void GetSpotifyFeaturedPlaylists_ReturnsCorrectList()
        {

            var featuredPlaylists = _playlistsUtils.GetSpotifyFeaturedPlaylists();
            Assert.AreEqual(false, featuredPlaylists.Any(x=>x==null));
        }
        [TestMethod]
        public void GetParticularPlaylists_ReturnsPlaylist()
        {

            var playlist = _playlistsUtils.GetParticularPlaylist("387bW3fRmQwvbKPxV2Jjm6");
            Assert.AreEqual(false, playlist.HasError());
        }
    }
}