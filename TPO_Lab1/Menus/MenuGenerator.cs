using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using TPO_Lab1.Functionality;
using TPO_Lab1.MenuFunctions;
using TPO_Lab1.MenuFunctions.Album;
using TPO_Lab1.MenuFunctions.Artist;
using TPO_Lab1.MenuFunctions.Playlist;
using TPO_Lab1.MenuFunctions.Track;

namespace TPO_Lab1.Menus
{
    public static class MenuGenerator
    {
        public static DefaultMenu.DefaultMenu GenerateMainMenu()
        {
            var mainMenu = new Menus.DefaultMenu.DefaultMenu();
            mainMenu.AddItem("Albums", MainMenuFunctions.MainAlbums, "1");
            mainMenu.AddItem("Artists", MainMenuFunctions.MainArtists, "2");
            mainMenu.AddItem("Playlists", MainMenuFunctions.MainPlaylists, "3");
            mainMenu.AddItem("Tracks", MainMenuFunctions.MainTracks, "4");
            mainMenu.AddItem("Exit", ExitFunction.Exit, "5");
            return mainMenu;
        }

        public static DefaultMenu.DefaultMenu GenerateTracksMenu()
        {
            var mainMenu = new Menus.DefaultMenu.DefaultMenu();
            mainMenu.AddItem("Saved Tracks", TracksMenuFunctions.SavedTracks, "1");
            mainMenu.AddItem("Top Tracks", TracksMenuFunctions.TopTracks, "2");
            mainMenu.AddItem("Recently Played Tracks", TracksMenuFunctions.RecentlyPlayedTracks, "3");
            mainMenu.AddItem("Exit", ExitFunction.Exit, "4");
            return mainMenu;
        }

        public static BasicModelMenu.BasicModelMenu GenerateTracks(List<FullTrack> trackList)
        {
            var tracksMenu = new BasicModelMenu.BasicModelMenu();
            int i = 1;
            trackList.ForEach(fullTrack =>
            {
                var ts = TimeSpan.FromMilliseconds(fullTrack.DurationMs);
                tracksMenu.AddItem(
                    $"{fullTrack.Artists[0].Name} - {fullTrack.Name} {ts.Minutes}:{ts.Seconds}",
                    TrackMenuFunctions.GetTrack, i++.ToString(), fullTrack.Id);
            });

            tracksMenu.AddItem("Exit", ExitFunction.Exit, i.ToString(), null);
            return tracksMenu;
        }

        public static BasicModelMenu.BasicModelMenu GenerateTracks(List<SimpleTrack> trackList)
        {
            var tracksMenu = new BasicModelMenu.BasicModelMenu();
            int i = 1;
            trackList.ForEach(fullTrack =>
            {
                var ts = TimeSpan.FromMilliseconds(fullTrack.DurationMs);
                tracksMenu.AddItem(
                    $"{fullTrack.Artists[0].Name} - {fullTrack.Name} {ts.Minutes}:{ts.Seconds}",
                    TrackMenuFunctions.GetTrack, i++.ToString(), fullTrack.Id);
            });

            tracksMenu.AddItem("Exit", ExitFunction.Exit, i.ToString(), null);
            return tracksMenu;
        }

        public static DefaultMenu.DefaultMenu GeneratePlaylistsMenu()
        {
            var mainMenu = new Menus.DefaultMenu.DefaultMenu();
            mainMenu.AddItem("Saved Playlists", PlaylistsMenuFunctions.SavedPlaylists, "1");
            mainMenu.AddItem("Created Playlists", PlaylistsMenuFunctions.CreatedPlaylists, "2");
            mainMenu.AddItem("Spotify Featured Playlists", PlaylistsMenuFunctions.SpotifyFeaturedPlaylists, "3");
            mainMenu.AddItem("Exit", ExitFunction.Exit, "4");
            return mainMenu;
        }

        public static BasicModelMenu.BasicModelMenu GeneratePlaylists(List<SimplePlaylist> playlistList)
        {
            var playlistsMenu = new BasicModelMenu.BasicModelMenu();
            int i = 1;
            playlistList.ForEach(simplePlaylist =>
                playlistsMenu.AddItem(
                    $"{simplePlaylist.Owner.DisplayName} - {simplePlaylist.Name}",
                    PlaylistMenuFunctions.GetPlaylist, i++.ToString(), simplePlaylist.Id));

            playlistsMenu.AddItem("Exit", ExitFunction.Exit, i.ToString(), null);
            return playlistsMenu;
        }

        public static DefaultMenu.DefaultMenu GenerateAlbumsMenu()
        {
            var mainMenu = new DefaultMenu.DefaultMenu();
            mainMenu.AddItem("Saved Albums", AlbumsMenuFunctions.SavedAlbums, "1");
            mainMenu.AddItem("New Album Releases", AlbumsMenuFunctions.NewAlbumReleases, "2");
            mainMenu.AddItem("Exit", ExitFunction.Exit, "3");
            return mainMenu;
        }

        public static BasicModelMenu.BasicModelMenu GenerateAlbums(List<SimpleAlbum> albumList)
        {
            var albumsMenu = new BasicModelMenu.BasicModelMenu();
            int i = 1;
            albumList.ForEach(simpleAlbum => albumsMenu.AddItem(
                $"{simpleAlbum.Artists[0].Name} - {simpleAlbum.Name}",
                AlbumMenuFunctions.GetAlbum, i++.ToString(), simpleAlbum.Id));
            albumsMenu.AddItem("Exit", ExitFunction.Exit, i.ToString(), null);
            return albumsMenu;
        }

        public static BasicModelMenu.BasicModelMenu GenerateAlbums(List<FullAlbum> albumList)
        {
            var albumsMenu = new BasicModelMenu.BasicModelMenu();
            int i = 1;
            albumList.ForEach(simpleAlbum => albumsMenu.AddItem(
                $"{simpleAlbum.Artists[0].Name} - {simpleAlbum.Name}",
                AlbumMenuFunctions.GetAlbum, i++.ToString(), simpleAlbum.Id));
            albumsMenu.AddItem("Exit", ExitFunction.Exit, i.ToString(), null);
            return albumsMenu;
        }

        public static DefaultMenu.DefaultMenu GenerateArtistsMenu()
        {
            var artistsMenu = new DefaultMenu.DefaultMenu();
            artistsMenu.AddItem("Followed Artists", ArtistsMenuFunctions.FollowedArtists, "1");
            artistsMenu.AddItem("Your Top Artists", ArtistsMenuFunctions.TopArtists, "2");
            artistsMenu.AddItem("Exit", ExitFunction.Exit, "3");
            return artistsMenu;
        }

        public static BasicModelMenu.BasicModelMenu GenerateArtists(List<FullArtist> followedArtists)
        {
            var artistsMenu = new BasicModelMenu.BasicModelMenu();
            int i = 1;
            followedArtists.ForEach(artist =>
                artistsMenu.AddItem(artist.Name, ArtistMenuFunction.GetArtist, i++.ToString(), artist.Id));
            artistsMenu.AddItem("Exit", ExitFunction.Exit, i.ToString(),null);
            return artistsMenu;
        }

        public static BasicModelMenu.BasicModelMenu GenerateArtist(string artistId)
        {
            var artistMenu = new BasicModelMenu.BasicModelMenu();
            artistMenu.AddItem($"Related Artists", ArtistMenuFunction.GetRelatedArtists, "1", artistId);
            artistMenu.AddItem($"Artist's Top Tracks", ArtistMenuFunction.GetArtistTopTracks, "2", artistId);
            artistMenu.AddItem($"Artist's Albums", ArtistMenuFunction.GetArtistsAlbums, "3", artistId);
            artistMenu.AddItem($"Follow Artist", ArtistMenuFunction.FollowArtist, "4", artistId);
            artistMenu.AddItem($"UnfollowArtist", ArtistMenuFunction.UnfollowArtist, "5", artistId);
            artistMenu.AddItem($"Exit", ExitFunction.Exit, "6", null);
            return artistMenu;
        }
    }
}