using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpotifyAPI.Web.Models;
using TPO_Lab1;
using TPO_Lab1.Converters;
using Authorization = TPO_Lab1.Authorization;

namespace TPO_Lab1_Tests.ConvertersTests
{
    [TestClass]
    public class AlbumsConverterTests
    {
        [TestMethod]
        public void ToList_SavedAlbumsPaging_ReturnsCorrectList()
        {
            var savedAlbumsPaging = SpotifyApi.Spotify.GetSavedAlbums();

            var savedAlbums = AlbumsConverter.ToList(savedAlbumsPaging);

            Assert.AreEqual(savedAlbumsPaging.Items.Count, savedAlbums.Count);
        }

        [TestMethod]
        public void ToList_SimpleAlbumsPaging_ReturnsCorrectList()
        {
            var newAlbumsPaging = SpotifyApi.Spotify.GetNewAlbumReleases().Albums;

            var newAlbums = AlbumsConverter.ToList(newAlbumsPaging);

            Assert.AreEqual(newAlbumsPaging.Items.Count, newAlbums.Count);
        }
    }
}