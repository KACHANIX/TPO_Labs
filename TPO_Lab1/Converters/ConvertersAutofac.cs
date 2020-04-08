using Autofac;

namespace TPO_Lab1.Converters
{
    public static class ConvertersAutofac
    {
        public static void RegisterConverters(this ContainerBuilder builder)
        {
            builder.RegisterType<AlbumsConverter>();
            builder.RegisterType<ArtistsConverter>();
            builder.RegisterType<PlaylistsConverter>();
            builder.RegisterType<TracksConverter>();
        }
    }
}
