using SpotifyAPI.Web.Models;
using System.Collections.Generic;
using TPO_Lab1.Utils;

namespace TPO_Lab1.MenuFunctions.Playlist
{
    public class PlaylistsMenuFunctions
    {
        private readonly PlaylistsUtils _playlistsUtils;
        private readonly PlaylistMenuFunctions _playlistMenuFunctions;
        private readonly ExitFunctions _exitFunctions;

        public PlaylistsMenuFunctions(PlaylistsUtils playlistsUtils, PlaylistMenuFunctions playlistMenuFunctions,
            ExitFunctions exitFunctions)
        {
            _playlistsUtils = playlistsUtils;
            _playlistMenuFunctions = playlistMenuFunctions;
            _exitFunctions = exitFunctions;
        }

        public Menus.BasicModelMenu.BasicModelMenu GeneratePlaylists(List<SimplePlaylist> playlistList)
        {
            var playlistsMenu = new Menus.BasicModelMenu.BasicModelMenu();
            int i = 1;
            playlistList.ForEach(simplePlaylist =>
                playlistsMenu.AddItem(
                    $"{simplePlaylist.Owner.DisplayName} - {simplePlaylist.Name}",
                    _playlistMenuFunctions.GetPlaylist, i++.ToString(), simplePlaylist.Id));

            playlistsMenu.AddItem("Exit", _exitFunctions.Exit, i.ToString(), null);
            return playlistsMenu;
        }

        public bool SavedPlaylists()
        {
            var savedPlaylists = _playlistsUtils.GetSavedPlaylists();
            var playlistsMenu = GeneratePlaylists(savedPlaylists);
            bool running = true;
            while (running)
            {
                running = playlistsMenu.Display();
            }

            return true;
        }

        public bool CreatedPlaylists()
        {
            var createdPlaylists = _playlistsUtils.GetCreatedPlaylists();
            var playlistsMenu = GeneratePlaylists(createdPlaylists);
            bool running = true;
            while (running)
            {
                running = playlistsMenu.Display();
            }

            return true;
        }

        public bool SpotifyFeaturedPlaylists()
        {
            var featuredPlaylists = _playlistsUtils.GetSpotifyFeaturedPlaylists();
            var playlistsMenu = GeneratePlaylists(featuredPlaylists);
            bool running = true;
            while (running)
            {
                running = playlistsMenu.Display();
            }

            return true;
        }
    }
}