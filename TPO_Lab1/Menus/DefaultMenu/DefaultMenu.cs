using System;
using System.Collections.Generic;

namespace TPO_Lab1.Menus.DefaultMenu
{
    public class DefaultMenu
    {
        private List<DefaultMenuItem> _items = new List<DefaultMenuItem>();

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
            int i = 1;
            foreach (DefaultMenuItem item in _items)
            {
                Console.WriteLine($"{item.Number}. {item.Title}");
            }

            Console.Write("Your input : ");
            string input = Console.ReadLine();

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