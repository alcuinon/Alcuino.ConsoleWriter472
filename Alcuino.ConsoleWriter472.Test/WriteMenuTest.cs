using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcuino.ConsoleWriter472.Test
{
    public class WriteMenuTest
    {
        public static void Test()
        {
            ConsoleWriter.WriteHeader("Welcome to Networking App!", ConsoleColor.White, default, 56);

            string[] menus = {
                    "Add Person",
                    "Update Person",
                    "Add Person",
                    "Display Somthing",
                    "Exit",
                };

            int option = ConsoleWriter.WriteMenu(menus);
        }
    }
}
