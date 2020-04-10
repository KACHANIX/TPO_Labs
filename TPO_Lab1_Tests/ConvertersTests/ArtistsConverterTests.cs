using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpotifyAPI.Web.Enums;
using TPO_Lab1.Converters;

namespace TPO_Lab1_Tests.ConvertersTests
{
    [TestClass]
    public class ArtistsConverterTests
    {
        private readonly ArtistsConverter _artistsConverter;

        public ArtistsConverterTests()
        {
            _artistsConverter = new ArtistsConverter();
        }

        [TestMethod]
        public void ToList_FullArtistPaging_ReturnsCorrectList()
        {
            var topArtistsPaging = GlobalTestInitializer.SpotifyApi.Spotify.GetUsersTopArtists();

            var topArtists = _artistsConverter.ToList(topArtistsPaging);

            Assert.AreEqual(topArtistsPaging.Items.Count, topArtists.Count);
        }

        [TestMethod]
        public void ToList_FullArtistCursorPaging_ReturnsCorrectList()
        {
            var followedArtistsPaging = GlobalTestInitializer.SpotifyApi.Spotify.GetFollowedArtists(FollowType.Artist).Artists;

            var followedArtists = _artistsConverter.ToList(followedArtistsPaging);

            Assert.AreEqual(followedArtistsPaging.Items.Count, followedArtists.Count);
        }
    }
}