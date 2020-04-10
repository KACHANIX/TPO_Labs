using System;
using TPO_Lab1.Converters;
using TPO_Lab1.MenuFunctions.Track;
using TPO_Lab1.Menus.BasicModelMenu;
using TPO_Lab1.Utils;

namespace TPO_Lab1.MenuFunctions.Playlist
{
    public class PlaylistMenuFunctions
    {
        private readonly PlaylistsUtils _playlistsUtils;
        private readonly TracksConverter _tracksConverter;
        private readonly TrackMenuFunctions _trackMenuFunctions;
        private readonly ExitFunctions _exitFunctions;
        private readonly SpotifyApi _spotifyApi;

        public PlaylistMenuFunctions(TracksConverter tracksConverter, PlaylistsUtils playlistsUtils, TrackMenuFunctions trackMenuFunctions, ExitFunctions exitFunctions, SpotifyApi spotifyApi)
        {
            _tracksConverter = tracksConverter;
            _playlistsUtils = playlistsUtils;
            _trackMenuFunctions = trackMenuFunctions;
            _exitFunctions = exitFunctions;
            _spotifyApi = spotifyApi;
        }

        public bool GetPlaylist(string playlistId)
        {
            var playlist = _playlistsUtils.GetParticularPlaylist(playlistId);
            var playlistTracks = _tracksConverter.ToList(playlist.Tracks);
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
                        _trackMenuFunctions.GetTrack, i++.ToString(), playlistTrack.Id);
                }

                menu.AddItem("Follow Playlist", FollowPlaylist, i++.ToString(), playlistId);
                menu.AddItem("Unfollow Playlist", UnfollowPlaylist, i++.ToString(), playlistId);
                menu.AddItem("Exit", _exitFunctions.Exit, i.ToString(), null);
                running = menu.Display();
            }

            return true;
        }

        public bool FollowPlaylist(string playlistId)
        {
            var playlistOwnerId = _playlistsUtils.GetParticularPlaylist(playlistId).Owner.Id;
            var isFollowing = _spotifyApi.Spotify.IsFollowingPlaylist(playlistId, _spotifyApi.CurrentUserId).List[0];
            if (isFollowing)
                throw new ArgumentException("Playlist is already followed.");
            _spotifyApi.Spotify.FollowPlaylist(playlistOwnerId, playlistId);
            return true;
        }

        public bool UnfollowPlaylist(string playlistId)
        {
            var isFollowing = _spotifyApi.Spotify.IsFollowingPlaylist(playlistId, _spotifyApi.CurrentUserId).List[0];
            if (!isFollowing)
                throw new ArgumentException("Playlist isn't followed.");
            _spotifyApi.Spotify.UnfollowPlaylist(playlistId);
            return true;
        }
    }
}