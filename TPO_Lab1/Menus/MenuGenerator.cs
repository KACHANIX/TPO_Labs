using System;
using System.Collections.Generic;
using System.Linq;
using SpotifyAPI.Web.Models;
using TPO_Lab1.Functionality;
using TPO_Lab1.MenuFunctions;

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
            var tracks = new BasicModelMenu.BasicModelMenu();
            int i = 1;
            trackList.ForEach(fullTrack =>
            {
                var ts = TimeSpan.FromMilliseconds(fullTrack.DurationMs);
                tracks.AddItem(
                    $"{fullTrack.Artists[0].Name} - {fullTrack.Name} {ts.Minutes}:{ts.Seconds}",
                    TrackMenuFunctions.GetTrack, i++.ToString(), fullTrack.Id);
            });

            tracks.AddItem("Exit", ExitFunction.Exit, i.ToString(), null);
            return tracks;
        }
        public static BasicModelMenu.BasicModelMenu GenerateTracks(List<SimpleTrack> trackList)
        {
            var tracks = new BasicModelMenu.BasicModelMenu();
            int i = 1;
            trackList.ForEach(fullTrack =>
            {
                var ts = TimeSpan.FromMilliseconds(fullTrack.DurationMs);
                tracks.AddItem(
                    $"{fullTrack.Artists[0].Name} - {fullTrack.Name} {ts.Minutes}:{ts.Seconds}",
                    TrackMenuFunctions.GetTrack, i++.ToString(), fullTrack.Id);
            });

            tracks.AddItem("Exit", ExitFunction.Exit, i.ToString(), null);
            return tracks;
        }
    }
}