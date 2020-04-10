using TPO_Lab1.MenuFunctions.Album;
using TPO_Lab1.MenuFunctions.Artist;
using TPO_Lab1.MenuFunctions.Playlist;
using TPO_Lab1.MenuFunctions.Track;
using TPO_Lab1.Menus.DefaultMenu;

namespace TPO_Lab1.MenuFunctions
{
    public class MainMenuFunctions
    {
        private readonly TracksMenuFunctions _trackMenuFunctions;
        private readonly PlaylistsMenuFunctions _playlistsMenuFunctions;
        private readonly ArtistsMenuFunctions _artistsMenuFunctions;
        private readonly AlbumsMenuFunctions _albumsMenuFunctions;
        private readonly ExitFunctions _exitFunctions;

        public MainMenuFunctions(TracksMenuFunctions trackMenuFunctions, PlaylistsMenuFunctions playlistsMenuFunctions,
            ArtistsMenuFunctions artistsMenuFunctions, AlbumsMenuFunctions albumsMenuFunctions,
            ExitFunctions exitFunctions)
        {
            _trackMenuFunctions = trackMenuFunctions;
            _playlistsMenuFunctions = playlistsMenuFunctions;
            _artistsMenuFunctions = artistsMenuFunctions;
            _albumsMenuFunctions = albumsMenuFunctions;
            _exitFunctions = exitFunctions;
        }


        public bool MainAlbums()
        {
            var albumsMenu = new DefaultMenu();
            albumsMenu.AddItem("Saved Albums", _albumsMenuFunctions.SavedAlbums, "1");
            albumsMenu.AddItem("New Album Releases", _albumsMenuFunctions.NewAlbumReleases, "2");
            albumsMenu.AddItem("Exit", _exitFunctions.Exit, "3");
            bool running = true;
            while (running)
            {
                running = albumsMenu.Display();
            }

            return true;
        }

        public bool MainArtists()
        {
            var artistsMenu = new DefaultMenu();
            artistsMenu.AddItem("Followed Artists", _artistsMenuFunctions.FollowedArtists, "1");
            artistsMenu.AddItem("Your Top Artists", _artistsMenuFunctions.TopArtists, "2");
            artistsMenu.AddItem("Exit", _exitFunctions.Exit, "3");
            bool running = true;
            while (running)
            {
                running = artistsMenu.Display();
            }

            return true;
        }

        public bool MainPlaylists()
        {
            var playlistsMenu = new DefaultMenu();
            playlistsMenu.AddItem("Saved Playlists", _playlistsMenuFunctions.SavedPlaylists, "1");
            playlistsMenu.AddItem("Created Playlists", _playlistsMenuFunctions.CreatedPlaylists, "2");
            playlistsMenu.AddItem("Spotify Featured Playlists", _playlistsMenuFunctions.SpotifyFeaturedPlaylists, "3");
            playlistsMenu.AddItem("Exit", _exitFunctions.Exit, "4");
            bool running = true;
            while (running)
            {
                running = playlistsMenu.Display();
            }

            return true;
        }

        public bool MainTracks()
        {
            var tracksMenu = new DefaultMenu();
            tracksMenu.AddItem("Saved Tracks", _trackMenuFunctions.SavedTracks, "1");
            tracksMenu.AddItem("Top Tracks", _trackMenuFunctions.TopTracks, "2");
            tracksMenu.AddItem("Recently Played Tracks", _trackMenuFunctions.RecentlyPlayedTracks, "3");
            tracksMenu.AddItem("Exit", _exitFunctions.Exit, "4");
            bool running = true;
            while (running)
            {
                running = tracksMenu.Display();
            }

            return true;
        }
    }
}