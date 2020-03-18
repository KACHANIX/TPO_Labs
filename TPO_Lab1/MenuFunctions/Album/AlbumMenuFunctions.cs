using System;
using System.Collections.Generic;
using System.Linq;
using TPO_Lab1.Converters;
using TPO_Lab1.Functionality;
using TPO_Lab1.MenuFunctions.Track;
using TPO_Lab1.Menus.BasicModelMenu;

namespace TPO_Lab1.MenuFunctions.Album
{
    public static class AlbumMenuFunctions
    {
        public static bool GetAlbum(string albumId)
        {
            var album = AlbumsFunctionality.GetParticularAlbum(albumId);
            var albumTracks = TracksConverter.ToList(album.Tracks);
            bool running = true;
            while (running)
            {
                Console.WriteLine(
                    $"Artist: {album.Artists[0].Name}\nName: {album.Name}\nRelease date: {album.ReleaseDate}");
                var menu = new BasicModelMenu();
                int i = 1;
                foreach (var playlistTrack in albumTracks)
                {
                    TimeSpan ts = TimeSpan.FromMilliseconds(playlistTrack.DurationMs);
                    menu.AddItem($"{playlistTrack.Name} {ts.Minutes}:{ts.Seconds}",
                        TrackMenuFunctions.GetTrack, i++.ToString(), playlistTrack.Id);
                }

                menu.AddItem("Save Album", SaveAlbum, i++.ToString(), albumId);
                menu.AddItem("Remove Saved Album", RemoveSavedAlbum, i++.ToString(), albumId);
                menu.AddItem("Exit", ExitFunction.Exit, i++.ToString(), null);
                running = menu.Display();
            }

            return true;
        }

        public static bool SaveAlbum(string albumId)
        {
            bool isFollowed = AlbumsFunctionality.GetSavedAlbums().Any(album => album.Id == albumId);
            if (isFollowed)
                throw new ArgumentException("Album is already saved.");
            SpotifyApi.Spotify.SaveAlbum(albumId);
            return true;
        }

        public static bool RemoveSavedAlbum(string albumId)
        {
            bool isFollowed = AlbumsFunctionality.GetSavedAlbums().Any(album => album.Id == albumId);
            if (!isFollowed)
                throw new ArgumentException("Album isn't saved.");
            SpotifyApi.Spotify.RemoveSavedAlbums(new List<string> {albumId});
            return true;
        }
    }
}