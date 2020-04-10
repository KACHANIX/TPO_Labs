using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TPO_Lab1;

namespace TPO_Lab1_Tests
{
    [TestClass]
    class GlobalTestInitializer
    {
        public static SpotifyApi SpotifyApi;
        [AssemblyInitialize()]
        public static void Initialize(TestContext tc)
        {
            IO.WriteLine = _ => { };
            IO.Write = _ => { };
            IO.ReadKey = () => new ConsoleKeyInfo();
            IO.ReadLine = () => "string";
            IO.Clear = () => { };

            var a  = new SpotifyApi();
            var spotifyApi = new SpotifyApi { Spotify = Authorization.Authorize() };
            var privateProfile = spotifyApi.Spotify.GetPrivateProfile();
            spotifyApi.CurrentUserId = privateProfile.Id;

            SpotifyApi = spotifyApi;
            // var builder = new ContainerBuilder();
            // builder.RegisterConverters();
            // builder.RegisterGenerators();
            // builder.RegisterMenuFunctions();
            // builder.RegisterUtils();
            // builder.RegisterInstance(spotifyApi);
            // _container = builder.Build();
        }
    }
}
