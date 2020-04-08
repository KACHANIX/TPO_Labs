using System;
using TPO_Lab1.Converters;
using TPO_Lab1.MenuFunctions.Track;
using TPO_Lab1.Menus.BasicModelMenu;
using TPO_Lab1.Utils;

namespace TPO_Lab1.MenuFunctions.Playlist
{
    public class PlaylistMenuFunctions
    {
        public  PlaylistsUtils PlaylistsUtils { get; set; }
        public TracksConverter TracksConverter { get; set; }
        public TrackMenuFunctions TrackMenuFunctions { get; set; }
        public ExitFunctions ExitFunctions { get; set; }
        public SpotifyApi SpotifyApi { get; set; }

        public PlaylistMenuFunctions(TracksConverter tracksConverter, PlaylistsUtils playlistsUtils, TrackMenuFunctions trackMenuFunctions, ExitFunctions exitFunctions, SpotifyApi spotifyApi)
        {
            TracksConverter = tracksConverter;
            PlaylistsUtils = playlistsUtils;
            TrackMenuFunctions = trackMenuFunctions;
            ExitFunctions = exitFunctions;
            SpotifyApi = spotifyApi;
        }

        public bool GetPlaylist(string playlistId)
        {
            var playlist = PlaylistsUtils.GetParticularPlaylist(playlistId);
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

        public bool FollowPlaylist(string playlistId)
        {
            var playlistOwnerId = PlaylistsUtils.GetParticularPlaylist(playlistId).Owner.Id;
            var isFollowing = SpotifyApi.Spotify.IsFollowingPlaylist(playlistId, SpotifyApi.CurrentUserId).List[0];
            if (isFollowing)
                throw new ArgumentException("Playlist is already followed.");
            SpotifyApi.Spotify.FollowPlaylist(playlistOwnerId, playlistId);
            return true;
        }

        public bool UnfollowPlaylist(string playlistId)
        {
            var isFollowing = SpotifyApi.Spotify.IsFollowingPlaylist(playlistId, SpotifyApi.CurrentUserId).List[0];
            if (!isFollowing)
                throw new ArgumentException("Playlist isn't followed.");
            SpotifyApi.Spotify.UnfollowPlaylist(playlistId);
            return true;
        }
    }
}