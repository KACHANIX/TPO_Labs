using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.Converters;
using TPO_Lab1.MenuFunctions;
using TPO_Lab1.MenuFunctions.Album;
using TPO_Lab1.MenuFunctions.Track;
using TPO_Lab1.Menus.Generators;
using TPO_Lab1.Utils;

namespace TPO_Lab1_Tests.MenusTests
{
    [TestClass]
    public class AlbumsGeneratorTests
    {
        private readonly AlbumsGenerator _albumsGenerator;
        private readonly AlbumsUtils _albumsUtils;
        public AlbumsGeneratorTests()
        {
            _albumsUtils = new AlbumsUtils(new AlbumsConverter(), GlobalTestInitializer.SpotifyApi);
            var tracksUtils = new TracksUtils(new TracksConverter(), GlobalTestInitializer.SpotifyApi);
            var exitFunctions = new ExitFunctions();
            var trackMenuFunctions =
                new TrackMenuFunctions(tracksUtils, exitFunctions, GlobalTestInitializer.SpotifyApi);
            var tracksConverter = new TracksConverter(); 
            var albumMenuFunctions = new AlbumMenuFunctions(
                new AlbumsUtils(new AlbumsConverter(), GlobalTestInitializer.SpotifyApi),
                tracksConverter, exitFunctions, trackMenuFunctions, GlobalTestInitializer.SpotifyApi);
            _albumsGenerator = new AlbumsGenerator(albumMenuFunctions, exitFunctions);
        }
        [TestMethod]
        public void GenerateAlbums_SimpleAlbumList_ReturnsMenuWithIncrementedTracksAmount()
        {
            var newReleases = _albumsUtils.GetNewAlbumReleases();
            var menu = _albumsGenerator.GenerateAlbums(newReleases);
            Assert.AreEqual(newReleases.Count + 1, menu.items.Count);
        }

        [TestMethod]
        public void GenerateAlbums_FullAlbumList_ReturnsMenuWithIncrementedTracksAmount()
        {
            var savedAlbums = _albumsUtils.GetSavedAlbums();
            var menu = _albumsGenerator.GenerateAlbums(savedAlbums);
            Assert.AreEqual(savedAlbums.Count + 1, menu.items.Count);
        }
    }
}