using System;

namespace TPO_Lab1.Menus.BasicModelMenu
{
    public class BasicModelMenuItem
    {
        public string Title;
        public Func<string, bool> Action;
        public string Number;
        public string Id;
    }
}