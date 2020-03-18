using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPO_Lab1.MenuFunctions.Album;

namespace TPO_Lab1_Tests.MenuFunctionsTests
{
    [TestClass]
    public class AlbumMenuFunctionsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SaveSavedAlbum_ThrowsException()
        {
            AlbumMenuFunctions.SaveAlbum("7c2Xfq7aQKzs0KdSI3K7Rc");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveUnsavedAlbum_ThrowsException()
        {
            AlbumMenuFunctions.RemoveSavedAlbum("27XsTKRj3plTMzIOIZlUL3");
        }
    }
}
