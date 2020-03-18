using System.Collections.Generic;
using System.Linq;
using SpotifyAPI.Web.Models;

namespace TPO_Lab1.Converters
{
    public static class ArtistsConverter
    {
        public static List<FullArtist> ToList(CursorPaging<FullArtist> artists)
        {
            return artists.Items.Select(artist => artist).ToList();
        }
        public static List<FullArtist> ToList(Paging<FullArtist> artists)
        {
            return artists.Items.Select(artist => artist).ToList();
        }
    }
}
