using Autofac;

namespace TPO_Lab1.Utils
{
    public static class UtilsAutofac
    {
        public static void RegisterUtils(this ContainerBuilder builder)
        {
            builder.RegisterType<AlbumsUtils>();

            builder.RegisterType<ArtistsUtils>();

            builder.RegisterType<PlaylistsUtils>();

            builder.RegisterType<TracksUtils>();
        }
    }
}
