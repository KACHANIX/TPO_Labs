using SpotifyAPI.Web.Models;
using System.Collections.Generic;
using TPO_Lab1.MenuFunctions;
using TPO_Lab1.MenuFunctions.Artist;

namespace TPO_Lab1.Menus.Generators
{
    public class ArtistsGenerator
    {
        private readonly ExitFunctions _exitFunctions;
        private readonly ArtistMenuFunctions _artistMenuFunctions;

        public ArtistsGenerator(ExitFunctions exitFunctions, ArtistMenuFunctions artistMenuFunctions)
        {
            _exitFunctions = exitFunctions;
            _artistMenuFunctions = artistMenuFunctions;
        }

        public BasicModelMenu.BasicModelMenu GenerateArtists(List<FullArtist> followedArtists)
        {
            var artistsMenu = new BasicModelMenu.BasicModelMenu();
            int i = 1;
            followedArtists.ForEach(artist =>
                artistsMenu.AddItem(artist.Name, _artistMenuFunctions.GetArtist, i++.ToString(), artist.Id));
            artistsMenu.AddItem("Exit", _exitFunctions.Exit, i.ToString(), null);
            return artistsMenu;
        }
    }
}