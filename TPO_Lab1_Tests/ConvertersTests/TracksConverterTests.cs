using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpotifyAPI.Web.Models;
using TPO_Lab1;
using TPO_Lab1.Converters;
using TPO_Lab1.Functionality;

namespace TPO_Lab1_Tests.ConvertersTests
{
    [TestClass]
    public class TracksConverterTests
    {
        [TestMethod]
        public void ToList_SavedTracksPaging_ReturnsCorrectList()
        {
            var savedTracksPaging = SpotifyApi.Spotify.GetSavedTracks();

            var savedTracks = TracksConverter.ToList(savedTracksPaging);

            Assert.AreEqual(savedTracksPaging.Items.Count, savedTracks.Count);
        }


        [TestMethod]
        public void ToList_SimpleTracksPaging_ReturnsCorrectList()
        {
            var albumTracksPaging = AlbumsFunctionality.GetParticularAlbum("3rqqwtJE89WoWvMyPTvbZc").Tracks;

            var albumTracks = TracksConverter.ToList(albumTracksPaging);

            Assert.AreEqual(albumTracksPaging.Items.Count, albumTracks.Count);
        }

        [TestMethod]
        public void ToList_FullTracksPaging_ReturnsCorrectList()
        {
            var topTracksPaging = SpotifyApi.Spotify.GetUsersTopTracks();

            var topTracks = TracksConverter.ToList(topTracksPaging);

            Assert.AreEqual(topTracksPaging.Items.Count, topTracks.Count);
        }

        [TestMethod]
        public void ToList_PlaylistTracksPaging_ReturnsCorrectList()
        {
            var playlistTracksPaging = PlaylistsFunctionality.GetParticularPlaylist("0vvXsWCC9xrXsKd4FyS8kM").Tracks;

            var playlistTracks = TracksConverter.ToList(playlistTracksPaging);

            Assert.AreEqual(playlistTracksPaging.Items.Count, playlistTracks.Count);
        }

        [TestMethod]
        public void ToList_PlayHistoryCursorPaging_ReturnsCorrectList()
        {
            var playHistory = SpotifyApi.Spotify.GetUsersRecentlyPlayedTracks();

            var historyTracks = TracksConverter.ToList(playHistory);

            Assert.AreEqual(playHistory.Items.Count, historyTracks.Count);
        }
    }
}