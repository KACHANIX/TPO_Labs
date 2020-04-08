using System.Collections.Generic;
using SpotifyAPI.Web.Models;
using TPO_Lab1.Menus;
using TPO_Lab1.Menus.Generators;
using TPO_Lab1.Utils;

namespace TPO_Lab1.MenuFunctions.Playlist
{
    public class PlaylistsMenuFunctions
    {
        public PlaylistsUtils PlaylistsUtils { get; set; }
        public PlaylistMenuFunctions PlaylistMenuFunctions { get; set; }
        public ExitFunctions ExitFunctions { get; set; }

        public PlaylistsMenuFunctions(PlaylistsUtils playlistsUtils, PlaylistMenuFunctions playlistMenuFunctions,
            ExitFunctions exitFunctions)
        {
            PlaylistsUtils = playlistsUtils;
            PlaylistMenuFunctions = playlistMenuFunctions;
            ExitFunctions = exitFunctions;
        }

        public Menus.BasicModelMenu.BasicModelMenu GeneratePlaylists(List<SimplePlaylist> playlistList)
        {
            var playlistsMenu = new Menus.BasicModelMenu.BasicModelMenu();
            int i = 1;
            playlistList.ForEach(simplePlaylist =>
                playlistsMenu.AddItem(
                    $"{simplePlaylist.Owner.DisplayName} - {simplePlaylist.Name}",
                    PlaylistMenuFunctions.GetPlaylist, i++.ToString(), simplePlaylist.Id));

            playlistsMenu.AddItem("Exit", ExitFunctions.Exit, i.ToString(), null);
            return playlistsMenu;
        }

        public bool SavedPlaylists()
        {
            var savedPlaylists = PlaylistsUtils.GetSavedPlaylists();
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
            var createdPlaylists = PlaylistsUtils.GetCreatedPlaylists();
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
            var featuredPlaylists = PlaylistsUtils.GetSpotifyFeaturedPlaylists();
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