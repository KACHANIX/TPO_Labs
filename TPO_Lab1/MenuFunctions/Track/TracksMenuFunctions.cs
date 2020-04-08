using TPO_Lab1.Menus;
using TPO_Lab1.Menus.Generators;
using TPO_Lab1.Utils;

namespace TPO_Lab1.MenuFunctions.Track
{
    public class TracksMenuFunctions
    {
        public TracksUtils TracksUtils { get; set; }
        public TracksGenerator TracksGenerator { get; set; }

        public TracksMenuFunctions(TracksUtils tracksUtils, TracksGenerator tracksGenerator)
        {
            TracksUtils = tracksUtils;
            TracksGenerator = tracksGenerator;
        }

        public bool SavedTracks()
        {
            var savedTracks = TracksUtils.GetSavedTracks();
            var tracksMenu = TracksGenerator.GenerateTracks(savedTracks);
            bool running = true;
            while (running)
            {
                running = tracksMenu.Display();
            }

            return true;
        }

        public bool TopTracks()
        {
            var topTracks = TracksUtils.GetTopTracks();
            var tracksMenu = TracksGenerator.GenerateTracks(topTracks);
            bool running = true;
            while (running)
            {
                running = tracksMenu.Display();
            }

            return true;
        }

        public bool RecentlyPlayedTracks()
        {
            var recentlyPlayedTracks = TracksUtils.GetRecentlyPlayedTracks();
            var tracksMenu = TracksGenerator.GenerateTracks(recentlyPlayedTracks);
            bool running = true;
            while (running)
            {
                running = tracksMenu.Display();
            }

            return true;
        }
    }
}