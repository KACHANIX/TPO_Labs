using System;
using System.Collections.Generic;
using System.Text;

namespace TPO_Lab1.Menu
{
    class MenuItem
    {
        public string Title;
        public Func<SpotifyApi, bool> Action;
        public string Number;
    }
}