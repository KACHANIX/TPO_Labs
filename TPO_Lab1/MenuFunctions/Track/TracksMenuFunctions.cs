using TPO_Lab1.Functionality;
using TPO_Lab1.Menus;

namespace TPO_Lab1.MenuFunctions.Track
{
    public static class TracksMenuFunctions
    {
        public static bool SavedTracks()
        {
            var savedTracks = TracksFunctionality.GetSavedTracks();
            var tracksMenu = MenuGenerator.GenerateTracks(savedTracks);
            bool running = true;
            while (running)
            {
                running = tracksMenu.Display();
            }

            return true;
        }

        public static bool TopTracks()
        {
            var topTracks = TracksFunctionality.GetTopTracks();
            var tracksMenu = MenuGenerator.GenerateTracks(topTracks);
            bool running = true;
            while (running)
            {
                running = tracksMenu.Display();
            }

            return true;
        }

        public static bool RecentlyPlayedTracks()
        {
            var recentlyPlayedTracks = TracksFunctionality.GetRecentlyPlayedTracks();
            var tracksMenu = MenuGenerator.GenerateTracks(recentlyPlayedTracks);
            bool running = true;
            while (running)
            {
                running = tracksMenu.Display();
            }

            return true;
        }
    }
}