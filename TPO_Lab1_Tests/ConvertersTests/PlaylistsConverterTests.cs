using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.Converters;

namespace TPO_Lab1_Tests.ConvertersTests
{
    [TestClass]
    public class PlaylistsConverterTests
    {
        private readonly PlaylistsConverter _playlistsConverter;

        public PlaylistsConverterTests()
        {
            _playlistsConverter = new PlaylistsConverter();
        }

        [TestMethod]
        public void ToList_SimplePlaylistsPaging_ReturnsCorrectList()
        {
            var savedPlaylistsPaging = GlobalTestInitializer.SpotifyApi.Spotify.GetUserPlaylists(GlobalTestInitializer.SpotifyApi.CurrentUserId);
            
            var savedPlaylists = _playlistsConverter.ToList(savedPlaylistsPaging);

            Assert.AreEqual(savedPlaylistsPaging.Items.Count, savedPlaylists.Count);
        }
    }
}