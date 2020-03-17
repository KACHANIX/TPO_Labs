using System;
using TPO_Lab1.Functionality;
using TPO_Lab1.Mappers;
using TPO_Lab1.MenuFunctions.Track;
using TPO_Lab1.Menus.BasicModelMenu;

namespace TPO_Lab1.MenuFunctions.Playlist
{
    class PlaylistMenuFunctions
    {
        public static bool GetPlaylist(string playlistId)
        {
            var playlist = PlaylistsFunctionality.GetParticularPlaylist(playlistId);
            var playlistTracks = PlaylistsMapper.ToList(playlist.Tracks);
            bool running = true;
            while (running)
            {
                Console.WriteLine($"Author: {playlist.Owner.DisplayName}\nPlaylist Name: {playlist.Name}");
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
                menu.AddItem("Exit", ExitFunction.Exit, i.ToString(), null);
                running = menu.Display();
            }

            return true;
        }

        public static bool FollowPlaylist(string playlistId)
        {
            var playlistOwnerId = PlaylistsFunctionality.GetParticularPlaylist(playlistId).Owner.Id;
            SpotifyApi.Spotify.FollowPlaylist(playlistOwnerId, playlistId);
            return true;
        }

        public static bool UnfollowPlaylist(string playlistId)
        {
            SpotifyApi.Spotify.UnfollowPlaylist(playlistId);
            return true;
        }
    }
}