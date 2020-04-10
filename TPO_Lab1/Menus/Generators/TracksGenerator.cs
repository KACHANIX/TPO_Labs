using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using TPO_Lab1.MenuFunctions;
using TPO_Lab1.MenuFunctions.Track;

namespace TPO_Lab1.Menus.Generators
{
    public class TracksGenerator
    {
        private readonly TrackMenuFunctions _trackMenuFunctions;
        private readonly ExitFunctions _exitFunctions;

        public TracksGenerator(TrackMenuFunctions trackMenuFunctions, ExitFunctions exitFunctions)
        {
            _trackMenuFunctions = trackMenuFunctions;
            _exitFunctions = exitFunctions;
        }

        public BasicModelMenu.BasicModelMenu GenerateTracks(List<FullTrack> trackList)
        {
            var tracksMenu = new BasicModelMenu.BasicModelMenu();
            int i = 1;
            trackList.ForEach(fullTrack =>
            {
                var ts = TimeSpan.FromMilliseconds(fullTrack.DurationMs);
                tracksMenu.AddItem(
                    $"{fullTrack.Artists[0].Name} - {fullTrack.Name} {ts.Minutes}:{ts.Seconds}",
                    _trackMenuFunctions.GetTrack, i++.ToString(), fullTrack.Id);
            });

            tracksMenu.AddItem("Exit", _exitFunctions.Exit, i.ToString(), null);
            return tracksMenu;
        }

        public BasicModelMenu.BasicModelMenu GenerateTracks(List<SimpleTrack> trackList)
        {
            var tracksMenu = new BasicModelMenu.BasicModelMenu();
            int i = 1;
            trackList.ForEach(fullTrack =>
            {
                var ts = TimeSpan.FromMilliseconds(fullTrack.DurationMs);
                tracksMenu.AddItem(
                    $"{fullTrack.Artists[0].Name} - {fullTrack.Name} {ts.Minutes}:{ts.Seconds}",
                    _trackMenuFunctions.GetTrack, i++.ToString(), fullTrack.Id);
            });

            tracksMenu.AddItem("Exit", _exitFunctions.Exit, i.ToString(), null);
            return tracksMenu;
        }
    }
}