using System.Collections.Generic;
using SpotifyAPI.Web.Models;
using TPO_Lab1.Menus;
using TPO_Lab1.Menus.Generators;
using TPO_Lab1.Utils;

namespace TPO_Lab1.MenuFunctions.Artist
{
    public class ArtistsMenuFunctions
    {
        public ArtistsUtils ArtistsUtils { get; set; }
        public ArtistsGenerator ArtistsGenerator { get; set; }

        public ArtistsMenuFunctions(ArtistsUtils artistsUtils, ArtistsGenerator menuGenerator)
        {
            ArtistsUtils = artistsUtils;
            ArtistsGenerator = menuGenerator;
        }

        public bool FollowedArtists()
        {
            var followedArtists = ArtistsUtils.GetFollowedArtists();
            var artistsMenu = ArtistsGenerator.GenerateArtists(followedArtists);
            bool running = true;
            while (running)
            {
                running = artistsMenu.Display();
            }

            return true;
        }

        public bool TopArtists()
        {
            var userTopArtists = ArtistsUtils.GetTopArtists();
            var artistsMenu = ArtistsGenerator.GenerateArtists(userTopArtists);
            bool running = true;
            while (running)
            {
                running = artistsMenu.Display();
            }

            return true;
        }
    }
}