using System;
using System.Collections.Generic;
using System.Linq;
using TPO_Lab1.Functionality;
using TPO_Lab1.Menus.BasicModelMenu;

namespace TPO_Lab1.MenuFunctions.Track
{
    public static class TrackMenuFunctions
    {
        public static bool GetTrack(string trackId)
        {
            var track = TracksFunctionality.GetParticularTrack(trackId);
            bool running = true;
            while (running)
            {
                IO.WriteLine($"Author: {track.Artists[0].Name}\nTrack Name: {track.Name}");
                var menu = new BasicModelMenu();
                menu.AddItem("Save Track", SaveTrack, "1", track.Id);
                menu.AddItem("Remove Track From Saved", RemoveSavedTrack, "2", track.Id);
                menu.AddItem("Exit", ExitFunctions.Exit, "3", null);
                running = menu.Display();
            }

            return true;
        }


        public static bool SaveTrack(string trackId)
        {
            var savedTracks = TracksFunctionality.GetSavedTracks();
            bool isSaved = savedTracks.Any(savedTrack => savedTrack.Id == trackId);
            if (isSaved)
                throw new ArgumentException("Track is already saved.");
            SpotifyApi.Spotify.SaveTrack(trackId);
            return true;
        }

        public static bool RemoveSavedTrack(string trackId)
        {
            var savedTracks = TracksFunctionality.GetSavedTracks();
            bool isSaved = savedTracks.Any(savedTrack => savedTrack.Id == trackId);
            if (!isSaved)
                throw new ArgumentException("Track isn't saved.");
            SpotifyApi.Spotify.RemoveSavedTracks(new List<string> {trackId});
            return true;
        }
    }
}