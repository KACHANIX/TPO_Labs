using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace TPO_Lab2_Tests
{
    [TestFixture()]
    public class Class1
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private const string MainPageUrl = "http://localhost:3000";
        private const string SongsPageUrl = MainPageUrl + "/songs";
        private const string PlaylistsPageUrl = MainPageUrl + "/playlists";
        private const string ArtistsPageUrl = MainPageUrl + "/artists";
        private const string AlbumsPageUrl = MainPageUrl + "/albums";

        private const string ParticularPlaylistPageUrl = PlaylistsPageUrl + "/playlist";
        private const string ParticularArtistPageUrl = ArtistsPageUrl + "/artist";
        private const string ParticularAlbumPageUrl = AlbumsPageUrl + "/album";


        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver("C:\\chromedriver");
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [Test, Description("Check if main page loads correctly.")]
        public void MainPage_LoadsCorrectly()
        {
            _driver.Url = MainPageUrl;

            _wait.Until(drv => drv.FindElement(By.Id("welcome-msg")));

            var welcomeMessage = _driver.FindElement(By.Id("welcome-msg")).Text;
            Console.WriteLine(welcomeMessage);
            bool isWelcomeMessageCorrect =
                welcomeMessage.Contains($"Welcome, SERIOGA.{Environment.NewLine}Your followers:");
            Assert.AreEqual(true, isWelcomeMessageCorrect);
        }

        [Test]
        public void MainPage_HasFourLinks()
        {
            _driver.Url = MainPageUrl;
            var links = _driver.FindElements(By.TagName("a")).Count;
            Assert.AreEqual(4, links);
        }

        [Test]
        public void MainPage_PlaylistsLink_LeadsToPlaylistsPage()
        {
            _driver.Url = MainPageUrl;
            var links = _driver.FindElements(By.TagName("a"));
            IWebElement playlistsLinkElement = null;
            foreach (var link in links)
            {
                if (link.Text == "Playlists")
                {
                    playlistsLinkElement = link;
                    break;
                }
            }

            playlistsLinkElement.Click();
            Assert.AreEqual(PlaylistsPageUrl, _driver.Url);
        }

        [Test]
        public void MainPage_ArtistsLink_LeadsToArtistsPage()
        {
            _driver.Url = MainPageUrl;
            var links = _driver.FindElements(By.TagName("a"));
            IWebElement artistsLinkElement = null;
            foreach (var link in links)
            {
                if (link.Text == "Artists")
                {
                    artistsLinkElement = link;
                    break;
                }
            }

            artistsLinkElement.Click();
            Assert.AreEqual(ArtistsPageUrl, _driver.Url);
        }

        [Test]
        public void MainPage_AlbumsLink_LeadsToAlbumsPage()
        {
            _driver.Url = MainPageUrl;
            var links = _driver.FindElements(By.TagName("a"));
            IWebElement albumsLinkElement = null;
            foreach (var link in links)
            {
                if (link.Text == "Albums")
                {
                    albumsLinkElement = link;
                    break;
                }
            }

            albumsLinkElement.Click();
            Assert.AreEqual(AlbumsPageUrl, _driver.Url);
        }

        [Test]
        public void MainPage_SongsLink_LeadsToSongsPage()
        {
            _driver.Url = MainPageUrl;
            var links = _driver.FindElements(By.TagName("a"));
            IWebElement songsLinkElement = null;
            foreach (var link in links)
            {
                if (link.Text == "Songs")
                {
                    songsLinkElement = link;
                    break;
                }
            }

            songsLinkElement.Click();
            Assert.AreEqual(SongsPageUrl, _driver.Url);
        }


        [Test]
        public void SongsPage_SavedSongs_ShowsSongs()
        {
            _driver.Url = SongsPageUrl;
            var savedSongsBtn = _driver.FindElements(By.TagName("b"))[0];
            savedSongsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("songs")));

            var savedSongsCount = _driver.FindElements(By.ClassName("song")).Count;
            Assert.AreNotEqual(0, savedSongsCount);
        }

        [Test]
        public void SongsPage_MostPlayedSongs_ShowsSongs()
        {
            _driver.Url = SongsPageUrl;
            var mostPlayedSongsBtn = _driver.FindElements(By.TagName("b"))[1];
            mostPlayedSongsBtn.Click();
            // Wait.Until(drv => drv.FindElement(By.Id("songs")));

            var mostPlayedSongsCount = _driver.FindElements(By.ClassName("song")).Count;
            Assert.AreEqual(0, mostPlayedSongsCount);
        }

        [Test]
        public void SongsPage_RecentSongs_ShowsSongs()
        {
            _driver.Url = SongsPageUrl;
            var recentSongsBtn = _driver.FindElements(By.TagName("b"))[2];
            recentSongsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("songs")));

            var recentSongsCount = _driver.FindElements(By.ClassName("song")).Count;
            Assert.AreNotEqual(0, recentSongsCount);
        }

        [Test]
        public void SongsPage_SaveSong_ShowsAlert()
        {
            _driver.Url = SongsPageUrl;
            var recentSongsBtn = _driver.FindElements(By.TagName("b"))[2];
            recentSongsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("songs")));

            var saveButton = _driver
                .FindElement(By.Id("songList"))
                .FindElements(By.ClassName("track-buttons"))[0]
                .FindElements(By.TagName("button"))[0];
            saveButton.Click();
            var alertWindow = _driver.SwitchTo().Alert();
            Assert.AreEqual("Song saved!", alertWindow.Text);
            alertWindow.Accept();
        }

        [Test]
        public void SongsPage_UnsaveSong_ShowsAlert()
        {
            _driver.Url = SongsPageUrl;
            var recentSongsBtn = _driver.FindElements(By.TagName("b"))[2];
            recentSongsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("songs")));

            var unsaveButton = _driver
                .FindElements(By.ClassName("track-buttons"))[0]
                .FindElements(By.TagName("button"))[1];
            unsaveButton.Click();
            var alertWindow = _driver.SwitchTo().Alert();
            Assert.AreEqual("Song unsaved!", alertWindow.Text);
            alertWindow.Accept();
        }


        /// Playlists 
        [Test]
        public void PlaylistsPage_SavedPlaylists_ShowsPlaylists()
        {
            _driver.Url = PlaylistsPageUrl;
            var savedPlaylistsBtn = _driver.FindElements(By.TagName("b"))[0];
            savedPlaylistsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("playlists")));

            var playlistsCount = _driver.FindElements(By.ClassName("playlist-list-element")).Count;
            Assert.AreNotEqual(0, playlistsCount);
        }

        [Test]
        public void PlaylistsPage_CreatedPlaylists_ShowsPlaylists()
        {
            _driver.Url = PlaylistsPageUrl;
            var createdPlaylistsBtn = _driver.FindElements(By.TagName("b"))[1];
            createdPlaylistsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("playlists")));

            var playlistsCount = _driver.FindElements(By.ClassName("playlist-list-element")).Count;
            Assert.AreNotEqual(0, playlistsCount);
        }

        [Test]
        public void PlaylistsPage_FeaturedPlaylists_ShowsPlaylists()
        {
            _driver.Url = PlaylistsPageUrl;
            var featuredPlaylistsBtn = _driver.FindElements(By.TagName("b"))[2];
            featuredPlaylistsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("playlists")));

            var playlistsCount = _driver.FindElements(By.ClassName("playlist-list-element")).Count;
            Assert.AreNotEqual(0, playlistsCount);
        }

        [Test]
        public void PlaylistsPage_SavePlaylist_ShowsAlert()
        {
            _driver.Url = PlaylistsPageUrl;
            var featuredPlaylistsBtn = _driver.FindElements(By.TagName("b"))[2];
            featuredPlaylistsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("playlists")));

            _driver
                .FindElements(By.ClassName("playlist-list-buttons"))[0]
                .FindElements(By.TagName("button"))[0]
                .Click();
            var alertWindow = _driver.SwitchTo().Alert();
            Assert.AreEqual("Playlist saved!", alertWindow.Text);
            alertWindow.Accept();
        }

        [Test]
        public void PlaylistsPage_UnsavePlaylist_ShowsAlert()
        {
            _driver.Url = PlaylistsPageUrl;
            var featuredPlaylistsBtn = _driver.FindElements(By.TagName("b"))[2];
            featuredPlaylistsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("playlists")));

            _driver
                .FindElements(By.ClassName("playlist-list-buttons"))[0]
                .FindElements(By.TagName("button"))[1]
                .Click();
            var alertWindow = _driver.SwitchTo().Alert();
            Assert.AreEqual("Playlist unsaved!", alertWindow.Text);
            alertWindow.Accept();
        }

        [Test]
        public void PlaylistsPage_ChoosePlaylist_LeadsToParticularPlaylist()
        {
            _driver.Url = PlaylistsPageUrl;
            var featuredPlaylistsBtn = _driver.FindElements(By.TagName("b"))[2];
            featuredPlaylistsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("playlists")));

            _driver.FindElements(By.ClassName("playlist-definition"))[0].Click();
            bool isUrlCorrect = _driver.Url.Contains(ParticularPlaylistPageUrl);
            Assert.AreEqual(true, isUrlCorrect);
        }

        [Test]
        public void PlaylistPage_LoadsCorrectly()
        {
            _driver.Url = PlaylistsPageUrl;
            var featuredPlaylistsBtn = _driver.FindElements(By.TagName("b"))[2];
            featuredPlaylistsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("playlists")));

            _driver.FindElements(By.ClassName("playlist-definition"))[0].Click();

            _wait.Until(drv => drv.FindElement(By.Id("songs")));

            var songsCount = _driver.FindElements(By.ClassName("song")).Count;
            Assert.AreNotEqual(0, songsCount);
        }


        /// Albums
        [Test]
        public void AlbumsPage_SavedAlbums_ShowsAlbums()
        {
            _driver.Url = AlbumsPageUrl;
            var savedAlbumsBtn = _driver.FindElements(By.TagName("b"))[0];
            savedAlbumsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("albums")));

            var playlistsCount = _driver.FindElements(By.ClassName("album-list-element")).Count;
            Assert.AreNotEqual(0, playlistsCount);
        }

        [Test]
        public void AlbumsPage_NewAlbums_ShowsAlbums()
        {
            _driver.Url = AlbumsPageUrl;
            var newAlbumsBtn = _driver.FindElements(By.TagName("b"))[1];
            newAlbumsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("albums")));

            var playlistsCount = _driver.FindElements(By.ClassName("album-list-element")).Count;
            Assert.AreNotEqual(0, playlistsCount);
        }

        [Test]
        public void AlbumsPage_SaveAlbum_ShowsAlert()
        {
            _driver.Url = AlbumsPageUrl;
            var newAlbumsBtn = _driver.FindElements(By.TagName("b"))[1];
            newAlbumsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("albums")));

            _driver
                .FindElements(By.ClassName("album-list-buttons"))[0]
                .FindElements(By.TagName("button"))[0]
                .Click();
            var alertWindow = _driver.SwitchTo().Alert();
            Assert.AreEqual("Album saved!", alertWindow.Text);
            alertWindow.Accept();
        }

        [Test]
        public void AlbumsPage_UnsaveAlbum_ShowsAlert()
        {
            _driver.Url = AlbumsPageUrl;
            var newAlbumsBtn = _driver.FindElements(By.TagName("b"))[1];
            newAlbumsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("albums")));

            _driver
                .FindElements(By.ClassName("album-list-buttons"))[0]
                .FindElements(By.TagName("button"))[1]
                .Click();
            var alertWindow = _driver.SwitchTo().Alert();
            Assert.AreEqual("Album unsaved!", alertWindow.Text);
            alertWindow.Accept();
        }

        [Test]
        public void AlbumsPage_ChooseAlbum_LeadsToParticularAlbum()
        {
            _driver.Url = AlbumsPageUrl;
            var newAlbumsBtn = _driver.FindElements(By.TagName("b"))[1];
            newAlbumsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("albums")));

            _driver.FindElements(By.ClassName("album-definition"))[0].Click();
            bool isUrlCorrect = _driver.Url.Contains(ParticularAlbumPageUrl);
            Assert.AreEqual(true, isUrlCorrect);
        }

        [Test]
        public void AlbumPage_LoadsCorrectly()
        {
            _driver.Url = AlbumsPageUrl;
            var newAlbumsBtn = _driver.FindElements(By.TagName("b"))[1];
            newAlbumsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("albums")));

            _driver.FindElements(By.ClassName("album-definition"))[0].Click();

            _wait.Until(drv => drv.FindElement(By.Id("songs")));

            var songsCount = _driver.FindElements(By.ClassName("song")).Count;

            Assert.AreNotEqual(0, songsCount);
        }


        /// Artists
        [Test]
        public void ArtistsPage_SavedArtists_ShowsArtists()
        {
            _driver.Url = ArtistsPageUrl;
            var savedArtistsBtn = _driver.FindElements(By.TagName("b"))[0];
            savedArtistsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("artists")));

            var playlistsCount = _driver.FindElements(By.ClassName("artist-list-element")).Count;
            Assert.AreNotEqual(0, playlistsCount);
        }

        [Test]
        public void ArtistsPage_MostArtists_ShowsArtists()
        {
            _driver.Url = ArtistsPageUrl;
            var mostArtistsBtn = _driver.FindElements(By.TagName("b"))[1];
            mostArtistsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("artists")));

            var playlistsCount = _driver.FindElements(By.ClassName("artist-list-element")).Count;
            Assert.AreNotEqual(0, playlistsCount);
        }

        [Test]
        public void ArtistsPage_SaveArtist_ShowsAlert()
        {
            _driver.Url = ArtistsPageUrl;
            var mostArtistsBtn = _driver.FindElements(By.TagName("b"))[1];
            mostArtistsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("artists")));

            _driver
                .FindElements(By.ClassName("artist-list-buttons"))[0]
                .FindElements(By.TagName("button"))[0]
                .Click();

            var alertWindow = _driver.SwitchTo().Alert();
            Assert.AreEqual("Artist saved!", alertWindow.Text);
            alertWindow.Accept();
        }

        [Test]
        public void ArtistsPage_UnsaveArtist_ShowsAlert()
        {
            _driver.Url = ArtistsPageUrl;
            var mostArtistsBtn = _driver.FindElements(By.TagName("b"))[1];
            mostArtistsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("artists")));

            _driver
                .FindElements(By.ClassName("artist-list-buttons"))[0]
                .FindElements(By.TagName("button"))[1]
                .Click();
            var alertWindow = _driver.SwitchTo().Alert();
            Assert.AreEqual("Artist unsaved!", alertWindow.Text);
            alertWindow.Accept();
        }

        [Test]
        public void ArtistsPage_ChooseArtist_LeadsToParticularArtist()
        {
            _driver.Url = ArtistsPageUrl;

            var mostArtistsBtn = _driver.FindElements(By.TagName("b"))[1];
            mostArtistsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("artists")));

            var artistDefinitionElement = _driver.FindElements(By.ClassName("artist-definition"))[0];
            artistDefinitionElement.Click();
            bool isUrlCorrect = _driver.Url.Contains(ParticularArtistPageUrl);
            Assert.AreEqual(true, isUrlCorrect);
        }


        [Test]
        public void ArtistPage_LoadsCorrectly()
        {
            _driver.Url = ArtistsPageUrl;
            var mostArtistsBtn = _driver.FindElements(By.TagName("b"))[1];
            mostArtistsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("artists")));

            var artistDefinitionElement = _driver.FindElements(By.ClassName("artist-definition"))[0];
            var artistName = artistDefinitionElement.Text;
            artistDefinitionElement.Click();

            _wait.Until(drv => drv.FindElement(By.Id("artist-definition")));

            var isLoadedCorrectly = _driver.FindElement(By.Id("artist-definition")).Text.Contains(artistName);
            Assert.AreEqual(true, isLoadedCorrectly);
        }

        [Test]
        public void ArtistPage_ArtistsAlike_ShowsArtists()
        {
            _driver.Url = ArtistsPageUrl;

            var mostArtistsBtn = _driver.FindElements(By.TagName("b"))[1];
            mostArtistsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("artists")));

            _driver.FindElements(By.ClassName("artist-definition"))[0].Click();
            var artistsAlikeBtn = _driver.FindElements(By.TagName("b"))[0];
            artistsAlikeBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("artists")));

            var artistsCount = _driver.FindElements(By.ClassName("artist-list-element")).Count;
            Assert.AreNotEqual(0, artistsCount);
        }

        [Test]
        public void ArtistPage_ArtistsAlbums_ShowsAlbums()
        {
            _driver.Url = ArtistsPageUrl;

            var mostArtistsBtn = _driver.FindElements(By.TagName("b"))[1];
            mostArtistsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("artists")));

            _driver.FindElements(By.ClassName("artist-definition"))[0].Click();

            _wait.Until(drv => drv.FindElement(By.Id("artist-definition")));

            var artistsAlbumsBtn = _driver.FindElements(By.TagName("b"))[1];
            artistsAlbumsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("albums")));

            var albumsCount = _driver.FindElements(By.ClassName("album-list-element")).Count;
            Assert.AreNotEqual(0, albumsCount);
        }

        [Test]
        public void ArtistPage_ArtistsSongs_ShowsSongs()
        {
            _driver.Url = ArtistsPageUrl;

            var mostArtistsBtn = _driver.FindElements(By.TagName("b"))[1];
            mostArtistsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("artists")));

            _driver.FindElements(By.ClassName("artist-definition"))[0].Click();

            _wait.Until(drv => drv.FindElement(By.Id("artist-definition")));

            var artistsSongsBtn = _driver.FindElements(By.TagName("b"))[2];
            artistsSongsBtn.Click();

            _wait.Until(drv => drv.FindElement(By.Id("songs")));

            var songsCount = _driver.FindElements(By.ClassName("song")).Count;
            Assert.AreNotEqual(0, songsCount);
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
        }
    }
}