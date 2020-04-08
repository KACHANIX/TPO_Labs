using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace TPO_Lab1.Menus.Generators
{
    public static class GeneratorsAutofac
    {
        public static void RegisterGenerators(this ContainerBuilder builder)
        {
            builder.RegisterType<MainMenuGenerator>();

            builder.RegisterType<TracksGenerator>();

            builder.RegisterType<AlbumsGenerator>();

            builder.RegisterType<ArtistsGenerator>();
        }
    }
}