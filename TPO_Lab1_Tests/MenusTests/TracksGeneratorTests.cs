using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.Converters;
using TPO_Lab1.MenuFunctions;
using TPO_Lab1.MenuFunctions.Track;
using TPO_Lab1.Menus.Generators;
using TPO_Lab1.Utils;

namespace TPO_Lab1_Tests.MenusTests
{
    [TestClass]
    public class TracksGeneratorTests
    {
        private readonly TracksGenerator _tracksGenerator;
        private readonly TracksUtils _tracksUtils;
        private readonly ArtistsUtils _artistsUtils;
        public TracksGeneratorTests()
        { 
            _tracksUtils = new TracksUtils(new TracksConverter(), GlobalTestInitializer.SpotifyApi);
            var exitFunctions = new ExitFunctions();
            var trackMenuFunctions =
                new TrackMenuFunctions(_tracksUtils, exitFunctions, GlobalTestInitializer.SpotifyApi); 
            _tracksGenerator = new TracksGenerator(trackMenuFunctions, exitFunctions); 
            _artistsUtils = new ArtistsUtils(new ArtistsConverter(), new AlbumsConverter(),
                GlobalTestInitializer.SpotifyApi);
        } 

        [TestMethod]
        public void GenerateTracks_ReturnsMenuWithIncrementedTracksAmount()
        {
            var recentlyPlayedTracks = _tracksUtils.GetRecentlyPlayedTracks();
            var menu = _tracksGenerator.GenerateTracks(recentlyPlayedTracks);
            Assert.AreEqual(recentlyPlayedTracks.Count + 1, menu.items.Count);
        }

        [TestMethod]
        public void GenerateTracks_FullTrackList_ReturnsMenuWithIncrementedTracksAmount()
        {
            var topTracks = _artistsUtils.GetArtistsTopTracks("1VPmR4DJC1PlOtd0IADAO0");
            var menu = _tracksGenerator.GenerateTracks(topTracks);
            Assert.AreEqual(topTracks.Count + 1, menu.items.Count);
        }
    }
}