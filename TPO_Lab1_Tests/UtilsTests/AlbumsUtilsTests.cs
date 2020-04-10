using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.Converters;
using TPO_Lab1.Utils;

namespace TPO_Lab1_Tests.UtilsTests
{
    [TestClass]
    public class AlbumsUtilsTests
    {
        private readonly AlbumsUtils _albumsUtils;

        public AlbumsUtilsTests()
        {
            _albumsUtils = new AlbumsUtils(new AlbumsConverter(), GlobalTestInitializer.SpotifyApi);
        }
        [TestMethod]
        public void GetSavedAlbums_ReturnsList()
        {
            var savedAlbums = _albumsUtils.GetSavedAlbums();
            Assert.AreNotEqual(0, savedAlbums.Count);
        }
        [TestMethod]
        public void GetSavedAlbums_ReturnsCorrectList()
        {
            var savedAlbums = _albumsUtils.GetSavedAlbums();
            Assert.AreEqual(false, savedAlbums.Any(x=>x==null));
        }

        [TestMethod]
        public void GetNewAlbumReleases_ReturnsList()
        {
            var newAlbums = _albumsUtils.GetNewAlbumReleases();
            Assert.AreNotEqual(0, newAlbums.Count);
        }
        [TestMethod]
        public void GetNewAlbumReleases_ReturnsCorrectList()
        {
            var newAlbums = _albumsUtils.GetNewAlbumReleases();
            Assert.AreEqual(false, newAlbums.Any(x => x == null));
        }

        [TestMethod]
        public void GetParticularAlbum_ReturnsAlbum()
        {
            var album = _albumsUtils.GetParticularAlbum("3rqqwtJE89WoWvMyPTvbZc");
            Assert.AreEqual(false, album.HasError());
        } 
    }
}