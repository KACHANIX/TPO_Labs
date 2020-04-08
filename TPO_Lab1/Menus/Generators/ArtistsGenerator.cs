using System;
using System.Collections.Generic;
using System.Text;
using SpotifyAPI.Web.Models;
using TPO_Lab1.MenuFunctions;
using TPO_Lab1.MenuFunctions.Artist;

namespace TPO_Lab1.Menus.Generators
{
    public class ArtistsGenerator
    { 
        public ExitFunctions ExitFunctions { get; set; }
        public ArtistMenuFunctions ArtistMenuFunctions { get; set; }
        public ArtistsGenerator(ExitFunctions exitFunctions, ArtistMenuFunctions artistMenuFunctions)
        {
            ExitFunctions = exitFunctions;
            ArtistMenuFunctions = artistMenuFunctions;
        }

        public BasicModelMenu.BasicModelMenu GenerateArtists(List<FullArtist> followedArtists)
        {
            var artistsMenu = new BasicModelMenu.BasicModelMenu();
            int i = 1;
            followedArtists.ForEach(artist =>
                artistsMenu.AddItem(artist.Name, ArtistMenuFunctions.GetArtist, i++.ToString(), artist.Id));
            artistsMenu.AddItem("Exit", ExitFunctions.Exit, i.ToString(), null);
            return artistsMenu;
        }
    }
}
