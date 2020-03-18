using System;
using System.Threading;
using TPO_Lab1.Converters;
using TPO_Lab1.Functionality;
using TPO_Lab1.MenuFunctions.Track;
using TPO_Lab1.Menus.BasicModelMenu;

namespace TPO_Lab1.MenuFunctions.Playlist
{
    public static class PlaylistMenuFunctions
    {
        public static bool GetPlaylist(string playlistId)
        {
            var playlist = PlaylistsFunctionality.GetParticularPlaylist(playlistId);
            var playlistTracks = TracksConverter.ToList(playlist.Tracks);
            bool running = true;
            while (running)
            {
                IO.WriteLine($"Author: {playlist.Owner.DisplayName}\nPlaylist Name: {playlist.Name}");
                var menu = new BasicModelMenu();
                int i = 1;
                foreach (var playlistTrack in playlistTracks)
                {
                    TimeSpan ts = TimeSpan.FromMilliseconds(playlistTrack.DurationMs);
                    menu.AddItem($"{playlistTrack.Artists[0].Name} - {playlistTrack.Name} {ts.Minutes}:{ts.Seconds}",
                        TrackMenuFunctions.GetTrack, i++.ToString(), playlistTrack.Id);
                }

                menu.AddItem("Follow Playlist", FollowPlaylist, i++.ToString(), playlistId);
                menu.AddItem("Unfollow Playlist", UnfollowPlaylist, i++.ToString(), playlistId);
                menu.AddItem("Exit", ExitFunctions.Exit, i.ToString(), null);
                running = menu.Display();
            }

            return true;
        }

        public static bool FollowPlaylist(string playlistId)
        {
            var playlistOwnerId = PlaylistsFunctionality.GetParticularPlaylist(playlistId).Owner.Id;
            var isFollowing = SpotifyApi.Spotify.IsFollowingPlaylist(playlistId, SpotifyApi.CurrentUserId).List[0];
            if (isFollowing)
                throw new ArgumentException("Playlist is already followed.");
            SpotifyApi.Spotify.FollowPlaylist(playlistOwnerId, playlistId);
            return true;
        }

        public static bool UnfollowPlaylist(string playlistId)
        {
            var isFollowing = SpotifyApi.Spotify.IsFollowingPlaylist(playlistId, SpotifyApi.CurrentUserId).List[0];
            if (!isFollowing)
                throw new ArgumentException("Playlist isn't followed.");
            SpotifyApi.Spotify.UnfollowPlaylist(playlistId);
            return true;
        }
    }
}