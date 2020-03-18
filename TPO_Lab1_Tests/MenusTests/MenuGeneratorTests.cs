using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.Functionality;
using TPO_Lab1.Menus;

namespace TPO_Lab1_Tests.MenusTests
{
    [TestClass]
    public class MenuGeneratorTests
    {
        [TestMethod]
        public void GenerateMainMenu_Returns5ItemsMenu()
        {
            var menu = MenuGenerator.GenerateMainMenu();
            Assert.AreEqual(5, menu._items.Count);
        }

        [TestMethod]
        public void GenerateTracksMenu_Returns4ItemsMenu()
        {
            var menu = MenuGenerator.GenerateTracksMenu();
            Assert.AreEqual(4, menu._items.Count);
        }
        [TestMethod]
        public void GeneratePlaylistsMenu_Returns4ItemsMenu()
        {
            var menu = MenuGenerator.GeneratePlaylistsMenu();
            Assert.AreEqual(4, menu._items.Count);
        }
        [TestMethod]
        public void GenerateAlbumsMenu_Returns3ItemsMenu()
        {
            var menu = MenuGenerator.GenerateAlbumsMenu();
            Assert.AreEqual(3, menu._items.Count);
        }
        [TestMethod]
        public void GenerateArtistsMenu_Returns3ItemsMenu()
        {
            var menu = MenuGenerator.GenerateArtistsMenu();
            Assert.AreEqual(3, menu._items.Count);
        }

        [TestMethod]
        public void GenerateArtist_ArtistIdString_Returns6ItemsMenu()
        {
            var menu = MenuGenerator.GenerateArtist("1VPmR4DJC1PlOtd0IADAO0");
            Assert.AreEqual(6, menu._items.Count);
        }

        [TestMethod]
        public void GenerateTracks_FullTrackList_ReturnsMenuWithIncrementedTracksAmount()
        {
            var topTracks = ArtistsFunctionality.GetArtistsTopTracks("1VPmR4DJC1PlOtd0IADAO0");
            var menu = MenuGenerator.GenerateTracks(topTracks);
            Assert.AreEqual(topTracks.Count + 1, menu._items.Count);
        }
        [TestMethod]
        public void GenerateTracks_ReturnsMenuWithIncrementedTracksAmount()
        {
            var recentlyPlayedTracks = TracksFunctionality.GetRecentlyPlayedTracks();
            var menu = MenuGenerator.GenerateTracks(recentlyPlayedTracks);
            Assert.AreEqual(recentlyPlayedTracks.Count + 1, menu._items.Count);
        }
        [TestMethod]
        public void GeneratePlaylists_SimplePlaylistList_ReturnsMenuWithIncrementedTracksAmount()
        {
            var savedPlaylists = PlaylistsFunctionality.GetSavedPlaylists();
            var menu = MenuGenerator.GeneratePlaylists(savedPlaylists);
            Assert.AreEqual(savedPlaylists.Count + 1, menu._items.Count);
        }
        [TestMethod]
        public void GenerateAlbums_SimpleAlbumList_ReturnsMenuWithIncrementedTracksAmount()
        {
            var newReleases = AlbumsFunctionality.GetNewAlbumReleases();
            var menu = MenuGenerator.GenerateAlbums(newReleases);
            Assert.AreEqual(newReleases.Count + 1, menu._items.Count);
        }
        [TestMethod]
        public void GenerateAlbums_FullAlbumList_ReturnsMenuWithIncrementedTracksAmount()
        {
            var savedAlbums = AlbumsFunctionality.GetSavedAlbums();
            var menu = MenuGenerator.GenerateAlbums(savedAlbums);
            Assert.AreEqual(savedAlbums.Count + 1, menu._items.Count);
        }
        [TestMethod]
        public void GenerateArtists_FullArtistsList_ReturnsMenuWithIncrementedTracksAmount()
        {
            var followedArtists = ArtistsFunctionality.GetFollowedArtists();
            var menu = MenuGenerator.GenerateArtists(followedArtists);
            Assert.AreEqual(followedArtists.Count + 1, menu._items.Count);
        }
    }
}