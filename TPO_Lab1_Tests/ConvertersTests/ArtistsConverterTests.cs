using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using TPO_Lab1;
using TPO_Lab1.Converters;

namespace TPO_Lab1_Tests.ConvertersTests
{
    [TestClass]
    public class ArtistsConverterTests
    {
        [TestMethod]
        public void ToList_FullArtistPaging_ReturnsCorrectList()
        {
            var topArtistsPaging = SpotifyApi.Spotify.GetUsersTopArtists();

            var topArtists = ArtistsConverter.ToList(topArtistsPaging);

            Assert.AreEqual(topArtistsPaging.Items.Count, topArtists.Count);
        }

        [TestMethod]
        public void ToList_FullArtistCursorPaging_ReturnsCorrectList()
        {
            var followedArtistsPaging = SpotifyApi.Spotify.GetFollowedArtists(FollowType.Artist).Artists;

            var followedArtists = ArtistsConverter.ToList(followedArtistsPaging);

            Assert.AreEqual(followedArtistsPaging.Items.Count, followedArtists.Count);
        }
    }
}