using TPO_Lab1.Menus.Generators;
using TPO_Lab1.Utils;

namespace TPO_Lab1.MenuFunctions.Track
{
    public class TracksMenuFunctions
    {
        private readonly TracksUtils _tracksUtils;
        private readonly TracksGenerator _tracksGenerator;

        public TracksMenuFunctions(TracksUtils tracksUtils, TracksGenerator tracksGenerator)
        {
            _tracksUtils = tracksUtils;
            _tracksGenerator = tracksGenerator;
        }

        public bool SavedTracks()
        {
            var savedTracks = _tracksUtils.GetSavedTracks();
            var tracksMenu = _tracksGenerator.GenerateTracks(savedTracks);
            bool running = true;
            while (running)
            {
                running = tracksMenu.Display();
            }

            return true;
        }

        public bool TopTracks()
        {
            var topTracks = _tracksUtils.GetTopTracks();
            var tracksMenu = _tracksGenerator.GenerateTracks(topTracks);
            bool running = true;
            while (running)
            {
                running = tracksMenu.Display();
            }

            return true;
        }

        public bool RecentlyPlayedTracks()
        {
            var recentlyPlayedTracks = _tracksUtils.GetRecentlyPlayedTracks();
            var tracksMenu = _tracksGenerator.GenerateTracks(recentlyPlayedTracks);
            bool running = true;
            while (running)
            {
                running = tracksMenu.Display();
            }

            return true;
        }
    }
}