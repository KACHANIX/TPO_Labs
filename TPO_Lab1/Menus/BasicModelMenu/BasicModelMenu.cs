using System;
using System.Collections.Generic;

namespace TPO_Lab1.Menus.BasicModelMenu
{
    public class BasicModelMenu
    {
        public List<BasicModelMenuItem> items = new List<BasicModelMenuItem>();

        public void AddItem(string title, Func<string, bool> action, string number, string id)
        {
            var item = new BasicModelMenuItem
            {
                Action = action,
                Title = title,
                Number = number,
                Id = id
            };
            items.Add(item);
        }

        public bool Display()
        { 
            foreach (BasicModelMenuItem item in items)
            {
                IO.WriteLine($"{item.Number}. {item.Title}");
            }

            IO.Write("Your input : ");
            string input = IO.ReadLine();

            foreach (BasicModelMenuItem item in items)
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