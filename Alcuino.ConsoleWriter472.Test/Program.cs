using System;

namespace Alcuino.ConsoleWriter472.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleWriter.WriteHeader("Welcome to Networking App!", ConsoleColor.White, default, 56);

            string[] menus = {
                    "Add Package",
                    "Update Package",
                    "Add Member",
                    "Display Company Earning",
                    "Exit",
                };

            int option = ConsoleWriter.WriteMenu(menus);

        }
    }
}
