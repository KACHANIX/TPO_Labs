using TPO_Lab1.Menus.Generators;
using TPO_Lab1.Utils;

namespace TPO_Lab1.MenuFunctions.Artist
{
    public class ArtistsMenuFunctions
    {
        private readonly ArtistsUtils _artistsUtils;
        private readonly ArtistsGenerator _artistsGenerator;

        public ArtistsMenuFunctions(ArtistsUtils artistsUtils, ArtistsGenerator menuGenerator)
        {
            _artistsUtils = artistsUtils;
            _artistsGenerator = menuGenerator;
        }

        public bool FollowedArtists()
        {
            var followedArtists = _artistsUtils.GetFollowedArtists();
            var artistsMenu = _artistsGenerator.GenerateArtists(followedArtists);
            bool running = true;
            while (running)
            {
                running = artistsMenu.Display();
            }

            return true;
        }

        public bool TopArtists()
        {
            var userTopArtists = _artistsUtils.GetTopArtists();
            var artistsMenu = _artistsGenerator.GenerateArtists(userTopArtists);
            bool running = true;
            while (running)
            {
                running = artistsMenu.Display();
            }

            return true;
        }
    }
}