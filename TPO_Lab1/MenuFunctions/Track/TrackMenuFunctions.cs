using System;
using System.Collections.Generic;
using System.Linq;
using TPO_Lab1.Functionality;
using TPO_Lab1.Menus.BasicModelMenu;

namespace TPO_Lab1.MenuFunctions.Track
{
    public class TrackMenuFunctions
    {
        public static bool GetTrack(string trackId)
        {
            var track = TracksFunctionality.GetParticularTrack(trackId);
            bool running = true;
            while (running)
            {
                Console.WriteLine($"Author: {track.Artists[0].Name}\nTrack Name: {track.Name}");
                var menu = new BasicModelMenu();
                menu.AddItem("Save Track", SaveTrack, "1", track.Id);
                menu.AddItem("Remove Track From Saved", RemoveSavedTrack, "2", track.Id);
                menu.AddItem("Exit", ExitFunction.Exit, "3", null);
                running = menu.Display();
            }

            return true;
        }

        public static bool SaveTrack(string trackId)
        {
            var savedTracks = TracksFunctionality.GetSavedTracks();
            bool isSaved = savedTracks.Any(savedTrack => savedTrack.Id == trackId);

            SpotifyApi.Spotify.SaveTrack(trackId);
            return false;
        }

        /// <returns>Returns false if track isn't saved.</returns>
        public static bool RemoveSavedTrack(string trackId)
        {
            var savedTracks = TracksFunctionality.GetSavedTracks();
            bool isSaved = savedTracks.Any(savedTrack => savedTrack.Id == trackId);

            SpotifyApi.Spotify.RemoveSavedTracks(new List<string> {trackId});
            return false;
        }
    }
}