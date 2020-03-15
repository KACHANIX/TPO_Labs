using System;
using System.Collections.Generic;
using System.Text;

namespace TPO_Lab1.Menu
{
    public class Menu
    {
        private List<MenuItem> _items = new List<MenuItem>();
        public void AddItem(string title, Func<SpotifyApi,bool> action, string number)
        {
            var item = new MenuItem
            {
                Action = action,
                Title = title,
                Number = number
            };
            _items.Add(item);
        }
        public bool Display(SpotifyApi api)
        {
            int i = 1;
            foreach (MenuItem item in _items)
            {
                Console.WriteLine($"{i++}. {item.Title}");
            }

            Console.Write("Your input : ");
            string input = Console.ReadLine();

            foreach (MenuItem item in _items)
            {
                if (item.Number == input)
                {
                    return item.Action(api);
                }
            }
            return true;
        }
    }
}
