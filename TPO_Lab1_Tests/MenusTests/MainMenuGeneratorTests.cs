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
    public class MainMenuGeneratorTests
    {
        private readonly MainMenuGenerator _mainMenuGenerator;

        public MainMenuGeneratorTests()
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
            var artistsUtils = new ArtistsUtils(new ArtistsConverter(), new AlbumsConverter(),
                GlobalTestInitializer.SpotifyApi);
            var artistsGenerator = new ArtistsGenerator(exitFunctions,
                new ArtistMenuFunctions(artistsUtils, GlobalTestInitializer.SpotifyApi, tracksGenerator,
                    albumsGenerator, exitFunctions));
            var tracksMenuFunctions = new TracksMenuFunctions(tracksUtils, tracksGenerator);
            var playlistsMenuFunctions =
                new PlaylistsMenuFunctions(playlistUtils, playlistMenuFunctions, exitFunctions);
            var artistsMenuFunctions = new ArtistsMenuFunctions(artistsUtils, artistsGenerator);
            var albumsMenuFunctions = new AlbumsMenuFunctions(albumUtils, albumsGenerator);

            var mainMenuFunctions = new MainMenuFunctions(tracksMenuFunctions, playlistsMenuFunctions,
                artistsMenuFunctions, albumsMenuFunctions, exitFunctions);

            _mainMenuGenerator = new MainMenuGenerator(exitFunctions, mainMenuFunctions);
        }

        [TestMethod]
        public void GenerateMainMenu_Returns5ItemsMenu()
        {
            var menu = _mainMenuGenerator.GenerateMainMenu();
            Assert.AreEqual(5, menu._items.Count);
        }
    }

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
            var tracksGenerator = new TracksGenerator(trackMenuFunctions, exitFunctions);
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
            Assert.AreEqual(newReleases.Count + 1, menu._items.Count);
        }

        [TestMethod]
        public void GenerateAlbums_FullAlbumList_ReturnsMenuWithIncrementedTracksAmount()
        {
            var savedAlbums = _albumsUtils.GetSavedAlbums();
            var menu = _albumsGenerator.GenerateAlbums(savedAlbums);
            Assert.AreEqual(savedAlbums.Count + 1, menu._items.Count);
        }
    }

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
            Assert.AreEqual(followedArtists.Count + 1, menu._items.Count);
        }
    }


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
            Assert.AreEqual(recentlyPlayedTracks.Count + 1, menu._items.Count);
        }

        [TestMethod]
        public void GenerateTracks_FullTrackList_ReturnsMenuWithIncrementedTracksAmount()
        {
            var topTracks = _artistsUtils.GetArtistsTopTracks("1VPmR4DJC1PlOtd0IADAO0");
            var menu = _tracksGenerator.GenerateTracks(topTracks);
            Assert.AreEqual(topTracks.Count + 1, menu._items.Count);
        }
    }






//
//     [TestMethod]
//     public void GenerateTracksMenu_Returns4ItemsMenu()
//     {
//         var menu = MainMenuGenerator.GenerateTracksMenu();
//         Assert.AreEqual(4, menu._items.Count);
//     }
//
//     [TestMethod]
//     public void GeneratePlaylistsMenu_Returns4ItemsMenu()
//     {
//         var menu = MainMenuGenerator.GeneratePlaylistsMenu();
//         Assert.AreEqual(4, menu._items.Count);
//     }
//
//    
//
//     [TestMethod]
//     public void GenerateArtistsMenu_Returns3ItemsMenu()
//     {
//         var menu = MainMenuGenerator.GenerateArtistsMenu();
//         Assert.AreEqual(3, menu._items.Count);
//     }
//
//     [TestMethod]
//     public void GenerateArtist_ArtistIdString_Returns6ItemsMenu()
//     {
//         var menu = MainMenuGenerator.GenerateArtist("1VPmR4DJC1PlOtd0IADAO0");
//         Assert.AreEqual(6, menu._items.Count);
//     }
//
//     
//
//
//     [TestMethod]
//     public void GeneratePlaylists_SimplePlaylistList_ReturnsMenuWithIncrementedTracksAmount()
//     {
//         var savedPlaylists = PlaylistsUtils.GetSavedPlaylists();
//         var menu = MainMenuGenerator.GeneratePlaylists(savedPlaylists);
//         Assert.AreEqual(savedPlaylists.Count + 1, menu._items.Count);
//     }
//
//    
//
//    
// }


}