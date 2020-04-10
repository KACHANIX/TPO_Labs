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
        private readonly AlbumsUtils _albumsUtils;
        private readonly TracksConverter _tracksConverter;
        private readonly ExitFunctions _exitFunctions;
        private readonly TrackMenuFunctions _trackMenuFunctions;
        private readonly SpotifyApi _spotifyApi;
        public AlbumMenuFunctions(AlbumsUtils albumsUtils, TracksConverter tracksConverter, ExitFunctions exitFunctions,
            TrackMenuFunctions trackMenuFunctions, SpotifyApi spotifyApi)
        {
            _albumsUtils = albumsUtils;
            _tracksConverter = tracksConverter;
            _exitFunctions = exitFunctions;
            _trackMenuFunctions = trackMenuFunctions;
            _spotifyApi = spotifyApi;
        }

        public bool GetAlbum(string albumId)
        {
            var album = _albumsUtils.GetParticularAlbum(albumId);
            var albumTracks = _tracksConverter.ToList(album.Tracks);
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
                        _trackMenuFunctions.GetTrack, i++.ToString(), playlistTrack.Id);
                }

                menu.AddItem("Save Album", SaveAlbum, i++.ToString(), albumId);
                menu.AddItem("Remove Saved Album", RemoveSavedAlbum, i++.ToString(), albumId);
                menu.AddItem("Exit", _exitFunctions.Exit, i++.ToString(), null);
                running = menu.Display();
            }

            return true;
        }

        public bool SaveAlbum(string albumId)
        {
            bool isFollowed = _albumsUtils.GetSavedAlbums().Any(album => album.Id == albumId);
            if (isFollowed)
                throw new ArgumentException("Album is already saved.");
            _spotifyApi.Spotify.SaveAlbum(albumId);
            return true;
        }

        public bool RemoveSavedAlbum(string albumId)
        {
            bool isFollowed = _albumsUtils.GetSavedAlbums().Any(album => album.Id == albumId);
            if (!isFollowed)
                throw new ArgumentException("Album isn't saved.");
            _spotifyApi.Spotify.RemoveSavedAlbums(new List<string> {albumId});
            return true;
        }
    }
}