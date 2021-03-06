﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
}