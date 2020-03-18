using TPO_Lab1.Functionality;
using TPO_Lab1.Menus;

namespace TPO_Lab1.MenuFunctions.Artist
{
    public static class ArtistsMenuFunctions
    {
        public static bool FollowedArtists()
        {
            var followedArtists = ArtistsFunctionality.GetFollowedArtists();
            var artistsMenu = MenuGenerator.GenerateArtists(followedArtists);
            bool running = true;
            while (running)
            {
                running = artistsMenu.Display();
            }
             
            return true;
        }

        public static bool TopArtists()
        { 
            var userTopArtists = ArtistsFunctionality.GetTopArtists();
            var artistsMenu = MenuGenerator.GenerateArtists(userTopArtists);
            bool running = true;
            while (running)
            {
                running = artistsMenu.Display();
            }

            return true;
        }
    }
}
