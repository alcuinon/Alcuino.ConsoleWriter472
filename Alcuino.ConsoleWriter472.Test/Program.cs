using System;
using System.Collections.Generic;

namespace Alcuino.ConsoleWriter472.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleWriter.IsTypeWriterMode = true;
            // Write text with typewriter effect
            ConsoleWriter.Write("Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad " +
                "minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex " +
                "ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate " +
                "velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat " +
                "cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", ConsoleColor.DarkGreen);

            Console.ReadKey();
        }
    }
}
