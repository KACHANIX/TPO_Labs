using System;
using System.Collections.Generic;
using System.Linq;
using TPO_Lab1.Converters;
using TPO_Lab1.MenuFunctions.Track;
using TPO_Lab1.Menus.BasicModelMenu;
using TPO_Lab1.Utils;

namespace TPO_Lab1.MenuFunctions.Album
{
    public class AlbumMenuFunctions
    {
        public AlbumsUtils AlbumsUtils { get; set; }
        public TracksConverter TracksConverter { get; set; }
        public ExitFunctions ExitFunctions { get; set; }
        public TrackMenuFunctions TrackMenuFunctions { get; set; }
        public SpotifyApi SpotifyApi { get; set; }

        public AlbumMenuFunctions(AlbumsUtils albumsUtils, TracksConverter tracksConverter, ExitFunctions exitFunctions,
            TrackMenuFunctions trackMenuFunctions, SpotifyApi spotifyApi)
        {
            AlbumsUtils = albumsUtils;
            TracksConverter = tracksConverter;
            ExitFunctions = exitFunctions;
            TrackMenuFunctions = trackMenuFunctions;
            SpotifyApi = spotifyApi;
        }

        public bool GetAlbum(string albumId)
        {
            var album = AlbumsUtils.GetParticularAlbum(albumId);
            var albumTracks = TracksConverter.ToList(album.Tracks);
            bool running = true;
            while (running)
            {
                IO.WriteLine(
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
                menu.AddItem("Exit", ExitFunctions.Exit, i++.ToString(), null);
                running = menu.Display();
            }

            return true;
        }

        public bool SaveAlbum(string albumId)
        {
            bool isFollowed = AlbumsUtils.GetSavedAlbums().Any(album => album.Id == albumId);
            if (isFollowed)
                throw new ArgumentException("Album is already saved.");
            SpotifyApi.Spotify.SaveAlbum(albumId);
            return true;
        }

        public bool RemoveSavedAlbum(string albumId)
        {
            bool isFollowed = AlbumsUtils.GetSavedAlbums().Any(album => album.Id == albumId);
            if (!isFollowed)
                throw new ArgumentException("Album isn't saved.");
            SpotifyApi.Spotify.RemoveSavedAlbums(new List<string> {albumId});
            return true;
        }
    }
}