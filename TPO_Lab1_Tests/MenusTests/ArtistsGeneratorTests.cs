using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.Converters;
using TPO_Lab1.MenuFunctions;
using TPO_Lab1.MenuFunctions.Album;
using TPO_Lab1.MenuFunctions.Artist;
using TPO_Lab1.MenuFunctions.Playlist;
using TPO_Lab1.MenuFunctions.Track;
using TPO_Lab1.Menus.Generators;
using TPO_Lab1.Utils;

namespace TPO_Lab1_Tests.MenusTests
{
    [TestClass]
    public class ArtistsGeneratorTests
    {
        private readonly ArtistsGenerator _artistsGenerator;
        private readonly ArtistsUtils _artistsUtils;
        public ArtistsGeneratorTests()
        {
            var albumUtils = new AlbumsUtils(new AlbumsConverter(), GlobalTestInitializer.SpotifyApi);
            var tracksUtils = new TracksUtils(new TracksConverter(), GlobalTestInitializer.SpotifyApi);
            var exitFunctions = new ExitFunctions();
            var trackMenuFunctions =
                new TrackMenuFunctions(tracksUtils, exitFunctions, GlobalTestInitializer.SpotifyApi);
            var tracksConverter = new TracksConverter();
            var tracksGenerator = new TracksGenerator(trackMenuFunctions, exitFunctions);
            var albumsGenerator =
                new AlbumsGenerator(
                    new AlbumMenuFunctions(new AlbumsUtils(new AlbumsConverter(), GlobalTestInitializer.SpotifyApi),
                        tracksConverter, exitFunctions, trackMenuFunctions, GlobalTestInitializer.SpotifyApi),
                    exitFunctions);
            var playlistConverter = new PlaylistsConverter();
            var playlistUtils = new PlaylistsUtils(playlistConverter, GlobalTestInitializer.SpotifyApi);
            var playlistMenuFunctions = new PlaylistMenuFunctions(tracksConverter, playlistUtils, trackMenuFunctions,
                exitFunctions, GlobalTestInitializer.SpotifyApi);
            _artistsUtils = new ArtistsUtils(new ArtistsConverter(), new AlbumsConverter(),
                GlobalTestInitializer.SpotifyApi);
            _artistsGenerator = new ArtistsGenerator(exitFunctions,
                new ArtistMenuFunctions(_artistsUtils, GlobalTestInitializer.SpotifyApi, tracksGenerator,
                    albumsGenerator, exitFunctions));  
        }
        [TestMethod]
        public void GenerateArtists_FullArtistsList_ReturnsMenuWithIncrementedTracksAmount()
        {
            var followedArtists = _artistsUtils.GetFollowedArtists();
            var menu = _artistsGenerator.GenerateArtists(followedArtists);
            Assert.AreEqual(followedArtists.Count + 1, menu.items.Count);
        }
    }
}