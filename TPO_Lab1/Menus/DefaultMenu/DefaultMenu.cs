using System;
using System.Collections.Generic;

namespace TPO_Lab1.Menus.DefaultMenu
{
    public class DefaultMenu
    {
        public List<DefaultMenuItem> _items = new List<DefaultMenuItem>();

        public void AddItem(string title, Func<bool> action, string number)
        {
            var item = new DefaultMenuItem
            {
                Action = action,
                Title = title,
                Number = number
            };
            _items.Add(item);
        }

        public bool Display()
        { 
            foreach (DefaultMenuItem item in _items)
            {
                IO.WriteLine($"{item.Number}. {item.Title}");
            }

            IO.Write("Your input : ");
            string input = IO.ReadLine();

            foreach (DefaultMenuItem item in _items)
            {
                if (item.Number == input)
                {
                    return item.Action();
                }
            }

            return true;
        }
    }
}