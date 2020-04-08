using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.Menus;
using TPO_Lab1.Menus.Generators;
using TPO_Lab1.Utils;

namespace TPO_Lab1_Tests.MenusTests
{
    [TestClass]
    public class MenuGeneratorTests
    {
        [TestMethod]
        public void GenerateMainMenu_Returns5ItemsMenu()
        {
            var menu = MainMenuGenerator.GenerateMainMenu();
            Assert.AreEqual(5, menu._items.Count);
        }

        [TestMethod]
        public void GenerateTracksMenu_Returns4ItemsMenu()
        {
            var menu = MainMenuGenerator.GenerateTracksMenu();
            Assert.AreEqual(4, menu._items.Count);
        }
        [TestMethod]
        public void GeneratePlaylistsMenu_Returns4ItemsMenu()
        {
            var menu = MainMenuGenerator.GeneratePlaylistsMenu();
            Assert.AreEqual(4, menu._items.Count);
        }
        [TestMethod]
        public void GenerateAlbumsMenu_Returns3ItemsMenu()
        {
            var menu = MainMenuGenerator.GenerateAlbumsMenu();
            Assert.AreEqual(3, menu._items.Count);
        }
        [TestMethod]
        public void GenerateArtistsMenu_Returns3ItemsMenu()
        {
            var menu = MainMenuGenerator.GenerateArtistsMenu();
            Assert.AreEqual(3, menu._items.Count);
        }

        [TestMethod]
        public void GenerateArtist_ArtistIdString_Returns6ItemsMenu()
        {
            var menu = MainMenuGenerator.GenerateArtist("1VPmR4DJC1PlOtd0IADAO0");
            Assert.AreEqual(6, menu._items.Count);
        }

        [TestMethod]
        public void GenerateTracks_FullTrackList_ReturnsMenuWithIncrementedTracksAmount()
        {
            var topTracks = ArtistsUtils.GetArtistsTopTracks("1VPmR4DJC1PlOtd0IADAO0");
            var menu = MainMenuGenerator.GenerateTracks(topTracks);
            Assert.AreEqual(topTracks.Count + 1, menu._items.Count);
        }
        [TestMethod]
        public void GenerateTracks_ReturnsMenuWithIncrementedTracksAmount()
        {
            var recentlyPlayedTracks = TracksUtils.GetRecentlyPlayedTracks();
            var menu = MainMenuGenerator.GenerateTracks(recentlyPlayedTracks);
            Assert.AreEqual(recentlyPlayedTracks.Count + 1, menu._items.Count);
        }
        [TestMethod]
        public void GeneratePlaylists_SimplePlaylistList_ReturnsMenuWithIncrementedTracksAmount()
        {
            var savedPlaylists = PlaylistsUtils.GetSavedPlaylists();
            var menu = MainMenuGenerator.GeneratePlaylists(savedPlaylists);
            Assert.AreEqual(savedPlaylists.Count + 1, menu._items.Count);
        }
        [TestMethod]
        public void GenerateAlbums_SimpleAlbumList_ReturnsMenuWithIncrementedTracksAmount()
        {
            var newReleases = AlbumsUtils.GetNewAlbumReleases();
            var menu = MainMenuGenerator.GenerateAlbums(newReleases);
            Assert.AreEqual(newReleases.Count + 1, menu._items.Count);
        }
        [TestMethod]
        public void GenerateAlbums_FullAlbumList_ReturnsMenuWithIncrementedTracksAmount()
        {
            var savedAlbums = AlbumsUtils.GetSavedAlbums();
            var menu = MainMenuGenerator.GenerateAlbums(savedAlbums);
            Assert.AreEqual(savedAlbums.Count + 1, menu._items.Count);
        }
        [TestMethod]
        public void GenerateArtists_FullArtistsList_ReturnsMenuWithIncrementedTracksAmount()
        {
            var followedArtists = ArtistsUtils.GetFollowedArtists();
            var menu = MainMenuGenerator.GenerateArtists(followedArtists);
            Assert.AreEqual(followedArtists.Count + 1, menu._items.Count);
        }
    }
}