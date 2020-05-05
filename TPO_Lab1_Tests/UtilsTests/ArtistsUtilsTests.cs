using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.Converters;
using TPO_Lab1.Utils;

namespace TPO_Lab1_Tests.UtilsTests
{
    [TestClass]
    public class ArtistsUtilsTests
    {
        private readonly ArtistsUtils _artistsUtils;

        public ArtistsUtilsTests()
        {
            _artistsUtils = new ArtistsUtils(new ArtistsConverter(), new AlbumsConverter(), GlobalTestInitializer.SpotifyApi);
        }
        [TestMethod]
        public void GetFollowedArtists_ReturnsList()
        {
            var followedArtists = _artistsUtils.GetFollowedArtists();
            Assert.AreNotEqual(0, followedArtists.Count);
        }
        [TestMethod]
        public void GetFollowedArtists_ReturnsCorrectList()
        {
            var followedArtists = _artistsUtils.GetFollowedArtists();
            Assert.AreEqual(false, followedArtists.Any(x=>x==null));
        }

        [TestMethod]
        public void GetTopArtists_ReturnsList()
        {
            var topArtists = _artistsUtils.GetTopArtists();
            Assert.AreNotEqual(0, topArtists.Count);
        }
        [TestMethod = "name test"]
        public void GetTopArtists_ReturnsCorrectList()
        {
            var topArtists = _artistsUtils.GetTopArtists();
            Assert.AreEqual(false, topArtists.Any(x => x == null));
        }

        [TestMethod]
        public void GetParticularArtist_ReturnsArtist()
        {
            var artist = _artistsUtils.GetParticularArtist("1VPmR4DJC1PlOtd0IADAO0");
            Assert.AreEqual(false, artist.HasError());
        }

        [TestMethod]
        public void GetRelatedArtists_ReturnsList()
        {
            var relatedArtists = _artistsUtils.GetRelatedArtists("1VPmR4DJC1PlOtd0IADAO0");
            Assert.AreNotEqual(0, relatedArtists.Count);
        }
        [TestMethod]
        public void GetRelatedArtists_ReturnsCorrectList()
        {
            var relatedArtists = _artistsUtils.GetRelatedArtists("1VPmR4DJC1PlOtd0IADAO0");
            Assert.AreEqual(false, relatedArtists.Any(x=>x==null));
        }

        [TestMethod]
        public void GetArtistsTopTracks_ReturnsList()
        {
            var topTracks = _artistsUtils.GetArtistsTopTracks("1VPmR4DJC1PlOtd0IADAO0");
            Assert.AreNotEqual(0, topTracks.Count);
        }
        [TestMethod]
        public void GetArtistsTopTracks_ReturnsCorrectList()
        {
            var topTracks = _artistsUtils.GetArtistsTopTracks("1VPmR4DJC1PlOtd0IADAO0");
            Assert.AreEqual(false, topTracks.Any(x=>x==null));
        }

        [TestMethod]
        public void GetArtistsAlbums_ReturnsList()
        {
            var artistsAlbums = _artistsUtils.GetArtistsAlbums("1VPmR4DJC1PlOtd0IADAO0");
            Assert.AreNotEqual(0, artistsAlbums.Count);
        }
        [TestMethod]
        public void GetArtistsAlbums_ReturnsCorrectList()
        {
            var artistsAlbums = _artistsUtils.GetArtistsAlbums("1VPmR4DJC1PlOtd0IADAO0");
            Assert.AreEqual(false, artistsAlbums.Any(x=>x==null));
        }
    }
}