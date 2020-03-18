using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpotifyAPI.Web.Models;
using System.Collections.Generic;
using TPO_Lab1;
using TPO_Lab1.Converters;

namespace TPO_Lab1_Tests.ConvertersTests
{
    [TestClass]
    public class PlaylistsConverterTests
    {
        [TestMethod]
        public void ToList_SimplePlaylistsPaging_ReturnsCorrectList()
        {
            var savedPlaylistsPaging = SpotifyApi.Spotify.GetUserPlaylists(SpotifyApi.CurrentUserId);
            
            var savedPlaylists = PlaylistsConverter.ToList(savedPlaylistsPaging);

            Assert.AreEqual(savedPlaylistsPaging.Items.Count, savedPlaylists.Count);
        }
    }
}