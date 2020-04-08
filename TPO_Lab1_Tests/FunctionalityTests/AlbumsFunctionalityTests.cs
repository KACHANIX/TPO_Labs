using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.Utils;

namespace TPO_Lab1_Tests.FunctionalityTests
{
    [TestClass]
    public class AlbumsFunctionalityTests
    {
        [TestMethod]
        public void GetSavedAlbums_ReturnsList()
        {
            var savedAlbums = AlbumsUtils.GetSavedAlbums();
            Assert.AreNotEqual(0, savedAlbums.Count);
        }
        [TestMethod]
        public void GetSavedAlbums_ReturnsCorrectList()
        {
            var savedAlbums = AlbumsUtils.GetSavedAlbums();
            Assert.AreEqual(false, savedAlbums.Any(x=>x==null));
        }

        [TestMethod]
        public void GetNewAlbumReleases_ReturnsList()
        {
            var newAlbums = AlbumsUtils.GetNewAlbumReleases();
            Assert.AreNotEqual(0, newAlbums.Count);
        }
        [TestMethod]
        public void GetNewAlbumReleases_ReturnsCorrectList()
        {
            var newAlbums = AlbumsUtils.GetNewAlbumReleases();
            Assert.AreEqual(false, newAlbums.Any(x => x == null));
        }

        [TestMethod]
        public void GetParticularAlbum_ReturnsAlbum()
        {
            var album = AlbumsUtils.GetParticularAlbum("3rqqwtJE89WoWvMyPTvbZc");
            Assert.AreEqual(false, album.HasError());
        } 
    }
}