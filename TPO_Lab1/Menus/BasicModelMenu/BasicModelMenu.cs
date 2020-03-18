using System;
using System.Collections.Generic;

namespace TPO_Lab1.Menus.BasicModelMenu
{
    public class BasicModelMenu
    {
        private List<BasicModelMenuItem> _items = new List<BasicModelMenuItem>();

        public void AddItem(string title, Func<string, bool> action, string number, string id)
        {
            var item = new BasicModelMenuItem
            {
                Action = action,
                Title = title,
                Number = number,
                Id = id
            };
            _items.Add(item);
        }

        public bool Display()
        { 
            foreach (BasicModelMenuItem item in _items)
            {
                Console.WriteLine($"{item.Number}. {item.Title}");
            }

            Console.Write("Your input : ");
            string input = Console.ReadLine();

            foreach (BasicModelMenuItem item in _items)
            {
                if (item.Number == input)
                {
                    return item.Action(item.Id);
                }
            }

            return true;
        }
    }
}