using TPO_Lab1.MenuFunctions.Album;
using TPO_Lab1.MenuFunctions.Artist;
using TPO_Lab1.MenuFunctions.Playlist;
using TPO_Lab1.MenuFunctions.Track;
using TPO_Lab1.Menus.DefaultMenu;

namespace TPO_Lab1.MenuFunctions
{
    public class MainMenuFunctions
    {
        public TracksMenuFunctions TrackMenuFunctions { get; set; }
        public PlaylistsMenuFunctions PlaylistsMenuFunctions { get; set; }
        public ArtistsMenuFunctions ArtistsMenuFunctions { get; set; }
        public AlbumsMenuFunctions AlbumsMenuFunctions { get; set; }
        public ExitFunctions ExitFunctions { get; set; }

        public MainMenuFunctions(TracksMenuFunctions trackMenuFunctions, PlaylistsMenuFunctions playlistsMenuFunctions,
            ArtistsMenuFunctions artistsMenuFunctions, AlbumsMenuFunctions albumsMenuFunctions,
            ExitFunctions exitFunctions)
        {
            TrackMenuFunctions = trackMenuFunctions;
            PlaylistsMenuFunctions = playlistsMenuFunctions;
            ArtistsMenuFunctions = artistsMenuFunctions;
            AlbumsMenuFunctions = albumsMenuFunctions;
            ExitFunctions = exitFunctions;
        }


        public bool MainAlbums()
        {
            var albumsMenu = new DefaultMenu();
            albumsMenu.AddItem("Saved Albums", AlbumsMenuFunctions.SavedAlbums, "1");
            albumsMenu.AddItem("New Album Releases", AlbumsMenuFunctions.NewAlbumReleases, "2");
            albumsMenu.AddItem("Exit", ExitFunctions.Exit, "3");
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
            artistsMenu.AddItem("Followed Artists", ArtistsMenuFunctions.FollowedArtists, "1");
            artistsMenu.AddItem("Your Top Artists", ArtistsMenuFunctions.TopArtists, "2");
            artistsMenu.AddItem("Exit", ExitFunctions.Exit, "3");
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
            playlistsMenu.AddItem("Saved Playlists", PlaylistsMenuFunctions.SavedPlaylists, "1");
            playlistsMenu.AddItem("Created Playlists", PlaylistsMenuFunctions.CreatedPlaylists, "2");
            playlistsMenu.AddItem("Spotify Featured Playlists", PlaylistsMenuFunctions.SpotifyFeaturedPlaylists, "3");
            playlistsMenu.AddItem("Exit", ExitFunctions.Exit, "4");
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
            tracksMenu.AddItem("Saved Tracks", TrackMenuFunctions.SavedTracks, "1");
            tracksMenu.AddItem("Top Tracks", TrackMenuFunctions.TopTracks, "2");
            tracksMenu.AddItem("Recently Played Tracks", TrackMenuFunctions.RecentlyPlayedTracks, "3");
            tracksMenu.AddItem("Exit", ExitFunctions.Exit, "4");
            bool running = true;
            while (running)
            {
                running = tracksMenu.Display();
            }

            return true;
        }
    }
}