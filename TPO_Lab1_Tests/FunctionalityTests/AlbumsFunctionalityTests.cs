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
        public void GetNewAlbumReleases_ReturnsList()
        {
            var newAlbums = AlbumsFunctionality.GetNewAlbumReleases();
            Assert.AreNotEqual(0, newAlbums.Count);
        }

        [TestMethod]
        public void GetParticularAlbum_ReturnsAlbum()
        {
            var album = AlbumsFunctionality.GetParticularAlbum("3rqqwtJE89WoWvMyPTvbZc");
            Assert.AreEqual(false, album.HasError());
        }
    }
}