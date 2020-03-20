using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.Functionality;

namespace TPO_Lab1_Tests.FunctionalityTests
{
    [TestClass]
    public class AlbumsFunctionalityTests
    {
        [TestMethod]
        public void GetSavedAlbums_ReturnsList()
        {
            var savedAlbums = AlbumsFunctionality.GetSavedAlbums();
            Assert.AreNotEqual(0, savedAlbums.Count);
        }
        [TestMethod]
        public void GetSavedAlbums_ReturnsCorrectList()
        {
            var savedAlbums = AlbumsFunctionality.GetSavedAlbums();
            Assert.AreEqual(false, savedAlbums.Any(x=>x==null));
        }

        [TestMethod]
        public void GetNewAlbumReleases_ReturnsList()
        {
            var newAlbums = AlbumsFunctionality.GetNewAlbumReleases();
            Assert.AreNotEqual(0, newAlbums.Count);
        }
        [TestMethod]
        public void GetNewAlbumReleases_ReturnsCorrectList()
        {
            var newAlbums = AlbumsFunctionality.GetNewAlbumReleases();
            Assert.AreEqual(false, newAlbums.Any(x => x == null));
        }

        [TestMethod]
        public void GetParticularAlbum_ReturnsAlbum()
        {
            var album = AlbumsFunctionality.GetParticularAlbum("3rqqwtJE89WoWvMyPTvbZc");
            Assert.AreEqual(false, album.HasError());
        } 
    }
}