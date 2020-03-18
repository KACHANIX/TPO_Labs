﻿using System.Collections.Generic;
using System.Linq;
using SpotifyAPI.Web.Models;

namespace TPO_Lab1.Converters
{
    public static class AlbumsConverter
    {
        public static List<FullAlbum> ToList(Paging<SavedAlbum> albums)
        {
            return albums.Items.Select(x => x.Album).ToList();
        }

        public static List<SimpleAlbum> ToList(Paging<SimpleAlbum> albums)
        {
            return albums.Items.Select(x => x).ToList();
        }
    }
}