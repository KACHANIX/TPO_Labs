using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.Converters;

namespace TPO_Lab1_Tests.ConvertersTests
{
    [TestClass]
    public class TracksConverterTests
    {
        private readonly TracksConverter _tracksConverter;

        public TracksConverterTests()
        {
            _tracksConverter = new TracksConverter();
        }
        [TestMethod]
        public void ToList_SavedTracksPaging_ReturnsCorrectList()
        {
            var savedTracksPaging = GlobalTestInitializer.SpotifyApi.Spotify.GetSavedTracks();

            var savedTracks = _tracksConverter.ToList(savedTracksPaging);

            Assert.AreEqual(savedTracksPaging.Items.Count, savedTracks.Count);
        }


        [TestMethod]
        public void ToList_SimpleTracksPaging_ReturnsCorrectList()
        {
            var albumTracksPaging = GlobalTestInitializer.SpotifyApi.Spotify.GetAlbum("3rqqwtJE89WoWvMyPTvbZc").Tracks;

            var albumTracks = _tracksConverter.ToList(albumTracksPaging);

            Assert.AreEqual(albumTracksPaging.Items.Count, albumTracks.Count);
        }

        [TestMethod]
        public void ToList_FullTracksPaging_ReturnsCorrectList()
        {
            var topTracksPaging = GlobalTestInitializer.SpotifyApi.Spotify.GetUsersTopTracks();

            var topTracks = _tracksConverter.ToList(topTracksPaging);

            Assert.AreEqual(topTracksPaging.Items.Count, topTracks.Count);
        }

        [TestMethod]
        public void ToList_PlaylistTracksPaging_ReturnsCorrectList()
        {
            var playlistTracksPaging = GlobalTestInitializer.SpotifyApi.Spotify.GetPlaylist("0vvXsWCC9xrXsKd4FyS8kM").Tracks;

            var playlistTracks = _tracksConverter.ToList(playlistTracksPaging);

            Assert.AreEqual(playlistTracksPaging.Items.Count, playlistTracks.Count);
        }

        [TestMethod]
        public void ToList_PlayHistoryCursorPaging_ReturnsCorrectList()
        {
            var playHistory = GlobalTestInitializer.SpotifyApi.Spotify.GetUsersRecentlyPlayedTracks();

            var historyTracks = _tracksConverter.ToList(playHistory);

            Assert.AreEqual(playHistory.Items.Count, historyTracks.Count);
        }
    }
}