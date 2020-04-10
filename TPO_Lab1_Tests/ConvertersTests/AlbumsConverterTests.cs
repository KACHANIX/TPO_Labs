using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.Converters;

namespace TPO_Lab1_Tests.ConvertersTests
{
    [TestClass]
    public class AlbumsConverterTests
    {
        private readonly AlbumsConverter _albumsConverter;
        public AlbumsConverterTests()
        {
            _albumsConverter = new AlbumsConverter(); 
        }

        [TestMethod]
        public void ToList_SavedAlbumsPaging_ReturnsCorrectList()
        {

            var savedAlbumsPaging = GlobalTestInitializer.SpotifyApi.Spotify.GetSavedAlbums();

            var savedAlbums = _albumsConverter.ToList(savedAlbumsPaging);

            Assert.AreEqual(savedAlbumsPaging.Items.Count, savedAlbums.Count);
        }

        [TestMethod]
        public void ToList_SimpleAlbumsPaging_ReturnsCorrectList()
        {
            var newAlbumsPaging = GlobalTestInitializer.SpotifyApi.Spotify.GetNewAlbumReleases().Albums;

            var newAlbums = _albumsConverter.ToList(newAlbumsPaging);

            Assert.AreEqual(newAlbumsPaging.Items.Count, newAlbums.Count);
        }
    }
}