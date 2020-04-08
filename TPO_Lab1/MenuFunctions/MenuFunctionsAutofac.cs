using Autofac;
using TPO_Lab1.MenuFunctions.Album;
using TPO_Lab1.MenuFunctions.Artist;
using TPO_Lab1.MenuFunctions.Playlist;
using TPO_Lab1.MenuFunctions.Track;

namespace TPO_Lab1.MenuFunctions
{
    public static class MenuFunctionsAutofac
    {
        public static void RegisterMenuFunctions(this ContainerBuilder builder)
        {
            builder.RegisterType<AlbumMenuFunctions>();
            builder.RegisterType<AlbumsMenuFunctions>();

            builder.RegisterType<ArtistMenuFunctions>();
            builder.RegisterType<ArtistsMenuFunctions>();

            builder.RegisterType<PlaylistMenuFunctions>();
            builder.RegisterType<PlaylistsMenuFunctions>();

            builder.RegisterType<TrackMenuFunctions>();
            builder.RegisterType<TracksMenuFunctions>();

            builder.RegisterType<ExitFunctions>();

            builder.RegisterType<MainMenuFunctions>();
        }
    }
}