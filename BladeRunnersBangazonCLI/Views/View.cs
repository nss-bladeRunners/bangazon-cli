using System;
using System.Collections.Generic;

namespace BladeRunnersBangazonCLI.Views
{
    class View
    {

        string companyName = @"
__________________________________
    ____                          
    /   )    /             /      
___/__ /____/_____________/_______
  /    )   /   /   ) /   /   /___)
_/____/___/___(___(_(___/___(___ _
                                  
                                  
______________________________________________
    ____                                      
    /    )                                    
___/___ /____________________________)________
  /    |   /   /  /   ) /   ) /___) /   ) (_ `
_/_____|__(___(__/___/_/___/_(___ _/_____(__)_";


        internal IList<string> _menuItems;
        int itemNumber = 0;

        internal View()
        {
            _menuItems = new List<string> { companyName };
        }

        internal View AddMenuText(string text)
        {
            var menuText = $"{Environment.NewLine}{text}{Environment.NewLine}";
            _menuItems.Add(menuText);
            return this;
        }

        internal View AddMenuOption(string menuItem)
        {
            ++itemNumber;
            var menuEntry = $"{itemNumber}. {menuItem}";
            _menuItems.Add(menuEntry);
            return this;
        }

        internal View AddMenuOptions(IList<string> menuItems)
        {
            foreach (var menuItem in menuItems)
            {
                AddMenuOption(menuItem);
            }

            return this;
        }

        internal string GetFullMenu()
        {
            Console.Clear();
            var menu = string.Join(Environment.NewLine, _menuItems);
            return $"{menu}{Environment.NewLine}> ";
        }
    }
}
