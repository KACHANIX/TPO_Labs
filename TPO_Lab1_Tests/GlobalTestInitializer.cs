using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1;

namespace TPO_Lab1_Tests
{
    [TestClass]
    class GlobalTestInitializer
    {
        [AssemblyInitialize()]
        public static void Initialize(TestContext tc)
        {
            IO.WriteLine = _ => { };
            IO.Write = _ => { };
            IO.ReadKey = () => new ConsoleKeyInfo();
            IO.ReadLine = () => "string";
            IO.Clear = () => { };
            SpotifyApi.Spotify = Authorization.Authorize();
            var privateProfile = SpotifyApi.Spotify.GetPrivateProfile();
            SpotifyApi.CurrentUserId = privateProfile.Id;
        }
    }
}
