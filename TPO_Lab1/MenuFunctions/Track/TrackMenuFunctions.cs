using System;
using System.Collections.Generic;
using System.Linq;
using TPO_Lab1.Menus.BasicModelMenu;
using TPO_Lab1.Utils;

namespace TPO_Lab1.MenuFunctions.Track
{
    public class TrackMenuFunctions
    {
        private readonly TracksUtils _tracksUtils;
        private readonly ExitFunctions _exitFunctions;
        private readonly SpotifyApi _spotifyApi;

        public TrackMenuFunctions(TracksUtils tracksUtils, ExitFunctions exitFunctions, SpotifyApi spotifyApi)
        {
            _tracksUtils = tracksUtils;
            _exitFunctions = exitFunctions;
            _spotifyApi = spotifyApi;
        }

        public bool GetTrack(string trackId)
        {
            var track = _tracksUtils.GetParticularTrack(trackId);
            bool running = true;
            while (running)
            {
                IO.WriteLine($"Author: {track.Artists[0].Name}\nTrack Name: {track.Name}");
                var menu = new BasicModelMenu();
                menu.AddItem("Save Track", SaveTrack, "1", track.Id);
                menu.AddItem("Remove Track From Saved", RemoveSavedTrack, "2", track.Id);
                menu.AddItem("Exit", _exitFunctions.Exit, "3", null);
                running = menu.Display();
            }

            return true;
        }

        public bool SaveTrack(string trackId)
        {
            var savedTracks = _tracksUtils.GetSavedTracks();
            bool isSaved = savedTracks.Any(savedTrack => savedTrack.Id == trackId);
            if (isSaved)
                throw new ArgumentException("Track is already saved.");
            _spotifyApi.Spotify.SaveTrack(trackId);
            return true;
        }

        public bool RemoveSavedTrack(string trackId)
        {
            var savedTracks = _tracksUtils.GetSavedTracks();
            bool isSaved = savedTracks.Any(savedTrack => savedTrack.Id == trackId);
            if (!isSaved)
                throw new ArgumentException("Track isn't saved.");
            _spotifyApi.Spotify.RemoveSavedTracks(new List<string> {trackId});
            return true;
        }
    }
}