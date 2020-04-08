using System;
using System.Collections.Generic;
using System.Linq;
using TPO_Lab1.Menus.BasicModelMenu;
using TPO_Lab1.Utils;

namespace TPO_Lab1.MenuFunctions.Track
{
    public class TrackMenuFunctions
    {
        public TracksUtils TracksUtils { get; set; }
        public ExitFunctions ExitFunctions { get; set; }
        public SpotifyApi SpotifyApi { get; set; }

        public TrackMenuFunctions(TracksUtils tracksUtils, ExitFunctions exitFunctions, SpotifyApi spotifyApi)
        {
            TracksUtils = tracksUtils;
            ExitFunctions = exitFunctions;
            SpotifyApi = spotifyApi;
        }

        public bool GetTrack(string trackId)
        {
            var track = TracksUtils.GetParticularTrack(trackId);
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

        public bool SaveTrack(string trackId)
        {
            var savedTracks = TracksUtils.GetSavedTracks();
            bool isSaved = savedTracks.Any(savedTrack => savedTrack.Id == trackId);
            if (isSaved)
                throw new ArgumentException("Track is already saved.");
            SpotifyApi.Spotify.SaveTrack(trackId);
            return true;
        }

        public bool RemoveSavedTrack(string trackId)
        {
            var savedTracks = TracksUtils.GetSavedTracks();
            bool isSaved = savedTracks.Any(savedTrack => savedTrack.Id == trackId);
            if (!isSaved)
                throw new ArgumentException("Track isn't saved.");
            SpotifyApi.Spotify.RemoveSavedTracks(new List<string> {trackId});
            return true;
        }
    }
}