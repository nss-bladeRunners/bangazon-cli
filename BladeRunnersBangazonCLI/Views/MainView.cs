using System;

namespace BladeRunnersBangazonCLI.Views
{
    class MainView
    {
        public ConsoleKeyInfo MainMenu()
        {
            View mainMenu = new View();

            mainMenu.AddMenuText("");
            mainMenu.AddMenuOption("Add Customer")
            .AddMenuOption("Select Customer")
            .AddMenuText("Press 0 to exit.");

            Console.Write(mainMenu.GetFullMenu());
            ConsoleKeyInfo userOption = Console.ReadKey();
            return userOption;
        }

    }
}
