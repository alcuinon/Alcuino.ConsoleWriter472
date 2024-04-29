using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace Alcuino.ConsoleWriter472
{

    /// <summary>
    /// Specifies the alignment options for formatting.
    /// </summary>
    public enum Align
    {
        /// <summary>
        /// Aligns content to the left.
        /// </summary>
        Left,

        /// <summary>
        /// Aligns content to the center.
        /// </summary>
        Center,

        /// <summary>
        /// Aligns content to the right.
        /// </summary>
        Right
    }


    /// <summary>
    /// Provides static methods for writing formatted content to the console.
    /// </summary>
    public static class ConsoleWriter
    {
        /// <summary>
        /// Indicates whether the typewriter mode is enabled.
        /// </summary>
        /// <returns>True if the typewriter mode is enabled, false otherwise.</returns>
        /// <remarks>
        /// Determines whether the <see cref="TypeWrite(string)"/> and <see cref="TypeWriteLine"/> methods simulate the typing of text on a typewriter. 
        /// Setting this property to true introduces a randomized delay between each character being written to the console.
        /// </remarks>
        public static bool IsTypeWriterMode = false;

        /// <summary>
        /// Specifies the speed of the typewriter effect in milliseconds.
        /// </summary>
        /// <value>The delay duration in milliseconds between each character being typed.</value>
        /// <remarks>
        /// The <see cref="TypeWriterSpeed"/> property controls the delay between each character being written to the console when the typewriter mode is enabled. 
        /// A higher value increases the delay, simulating slower typing, while a lower value decreases the delay, simulating faster typing.
        /// </remarks>
        public static int TypeWriterSpeed = 2;

        /// <summary>
        /// Indicates whether the typewriter effect is applied word by word.
        /// </summary>
        public static bool IsTypeWriterByWord = false;

        /// <summary>
        /// Writes the specified value to the console with the specified foreground and background colors.
        /// </summary>
        /// <param name="value">The value to write to the console.</param>
        /// <param name="foregroundColor">The color of the text. The default value is White.</param>
        /// <param name="backgroundColor">The color of the background. The default value is Black.</param>
        /// <remarks>
        /// This method writes the specified value to the console, sets the foreground and background colors, and then resets the colors to the default values.
        /// </remarks>
        public static void Write(string value, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            TypeWrite(value, IsTypeWriterMode);
            Console.ResetColor();
        }

        /// <summary>
        /// Writes the specified value followed by a newline to the console with the specified foreground and background colors.
        /// </summary>
        /// <param name="value">The value to write to the console.</param>
        /// <param name="foregroundColor">The color of the text. The default value is White.</param>
        /// <param name="backgroundColor">The color of the background. The default value is Black.</param>
        /// <remarks>
        /// This method writes the specified value to the console, sets the foreground and background colors, and then resets the colors to the default values. It also appends a newline character after the written value.
        /// </remarks>
        public static void WriteLine(string value, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            TypeWriteLine(value, IsTypeWriterMode);
            Console.ResetColor();
        }

        /// <summary>
        /// Writes a column of text to the console with the specified alignment, maximum character width, and foreground and background colors.
        /// </summary>
        /// <param name="values">An array of strings to be displayed in the column.</param>
        /// <param name="align">The alignment of the text within the column. The default value is Align.Left.</param>
        /// <param name="maxChar">The maximum width of each column in characters. The default value is 8.</param>
        /// <param name="foregroundColor">The color of the text. The default value is ConsoleColor.White.</param>
        /// <param name="backgroundColor">The color of the background. The default value is ConsoleColor.Black.</param>
        /// <remarks>
        /// This method formats the provided text into a visually appealing column, taking into account the specified alignment, maximum character width, and foreground and background colors.
        /// </remarks>
        public static void WriteColumn(
            string[] values,
            Align align = Align.Left,
            int maxChar = 8,
            ConsoleColor foregroundColor = ConsoleColor.White,
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;

            foreach (var value in values)
            {
                int withOneSpace = (maxChar - value.Length) % 2;
                int spacesAll = (maxChar - value.Length);
                int spaceLeftAndRight = spacesAll / 2;

                string spaces = "";
                string oneSpace = "";

                for (int i = 0; i < spaceLeftAndRight; i++)
                    spaces += " ";
                if (withOneSpace == 1) oneSpace = " ";

                string left = "";
                string right = "";

                switch (align)
                {
                    case Align.Left:
                        left = "";
                        right = spaces + spaces + oneSpace;
                        break;
                    case Align.Center:
                        left = spaces;
                        right = spaces + oneSpace;
                        break;
                    case Align.Right:
                        left = spaces + spaces + oneSpace;
                        right = "";
                        break;
                    default:
                        break;
                }

                TypeWrite($"|{left}{value}{right}", IsTypeWriterMode);
            }
            Console.WriteLine("|");
            Console.ResetColor();
        }

        /// <summary>
        /// Writes a formatted column of values to the console.
        /// </summary>
        /// <param name="values">A dictionary containing string keys and integer values representing the column values and their maximum character lengths.</param>
        /// <param name="align">Optional. Specifies the alignment of the column values (default: Align.Left).</param>
        /// <param name="foregroundColor">Optional. Specifies the foreground color for the column (default: ConsoleColor.White).</param>
        /// <param name="backgroundColor">Optional. Specifies the background color for the column (default: ConsoleColor.Black).</param>
        public static void WriteColumn(
            Dictionary<string, int> values,
            Align align = Align.Left,
            ConsoleColor foregroundColor = ConsoleColor.White,
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;

            foreach (var value in values)
            {
                int maxChar = value.Value;
                int withOneSpace = (maxChar - value.Key.Length) % 2;
                int spacesAll = (maxChar - value.Key.Length);
                int spaceLeftAndRight = spacesAll / 2;

                string spaces = "";
                string oneSpace = "";

                for (int i = 0; i < spaceLeftAndRight; i++)
                    spaces += " ";
                if (withOneSpace == 1) oneSpace = " ";

                string left = "";
                string right = "";

                switch (align)
                {
                    case Align.Left:
                        left = "";
                        right = spaces + spaces + oneSpace;
                        break;
                    case Align.Center:
                        left = spaces;
                        right = spaces + oneSpace;
                        break;
                    case Align.Right:
                        left = spaces + spaces + oneSpace;
                        right = "";
                        break;
                    default:
                        break;
                }

                TypeWrite($"|{left}{value.Key}{right}", IsTypeWriterMode);
            }
            Console.WriteLine("|");
            Console.ResetColor();
        }

        /// <summary>
        /// Simulates typing out a string either character by character or word by word with a specified speed.
        /// </summary>
        /// <param name="value">The string to be typed out.</param>
        /// <param name="mode">If true, types out the string character by character with random delays; if false, types out the entire string at once.</param>
        private static void TypeWrite(string value, bool mode)
        {
            int ms = TypeWriterSpeed;
            if (!mode)
            {
                Console.Write(value);
                return;
            }

            Random rand = new Random();
            if (IsTypeWriterByWord)
            {
                foreach (var ch in Regex.Split(value, "\\b"))
                {
                    Thread.Sleep(rand.Next(ms));
                    Console.Write(ch);
                }
            }
            else
            {
                foreach (var ch in value.ToCharArray())
                {
                    Thread.Sleep(rand.Next(ms));
                    Console.Write(ch);
                }
            }
        }

        /// <summary>
        /// Writes the specified string to the console with a typewriter-like effect, simulating the delay between each character being typed.
        /// </summary>
        /// <param name="value">The string to write to the console.</param>
        /// <remarks>
        /// This method simulates the typing of text on a typewriter by introducing a randomized delay between each character being written to the console. The delay duration is controlled by the `TypeWriterSpeed` property.
        /// </remarks>
        public static void TypeWrite(string value)
        {
            TypeWrite(value, true);
        }

        /// <summary>
        /// Writes the specified string followed by a newline to the console with a typewriter-like effect, simulating the delay between each character being typed and appending a newline character after the written text.
        /// </summary>
        /// <param name="value">The string to write to the console.</param>
        /// <remarks>
        /// This method simulates the typing of text on a typewriter by introducing a randomized delay between each character being written to the console and appending a newline character after the written text. The delay duration is controlled by the `TypeWriterSpeed` property.
        /// </remarks>
        public static void TypeWriteLine(string value)
        {
            TypeWrite(value, true);
            Console.WriteLine();
        }

        private static void TypeWriteLine(string value, bool mode)
        {
            TypeWrite(value, mode);
            Console.WriteLine();
        }

        /// <summary>
        /// Writes a centered header to the console with the specified foreground and background colors, maximum character width, and border style.
        /// </summary>
        /// <param name="value">The header text to display.</param>
        /// <param name="foregroundColor">The color of the header text. The default value is ConsoleColor.DarkYellow.</param>
        /// <param name="backgroundColor">The color of the header background. The default value is ConsoleColor.Black.</param>
        /// <param name="maxChar">The maximum width of the header in characters. The default value is 64.</param>
        /// <param name="border">The border style to use around the header. The default value is "═".</param>
        /// <remarks>
        /// This method creates a visually appealing header by centering the text, applying the specified foreground and background colors, and drawing a border around the header using the provided border style.
        /// </remarks>
        public static void WriteHeader(
            string value,
            ConsoleColor foregroundColor = ConsoleColor.DarkYellow,
            ConsoleColor backgroundColor = ConsoleColor.Black,
            int maxChar = 64,
            string border = "═")
        {
            int totalNoOfSpaces = (maxChar - value.Length);
            int withOneSpace = totalNoOfSpaces % 2;
            int spaceLeftAndRight = totalNoOfSpaces / 2;

            string spaces = "";
            string oneSpace = "";
            string headerBorder = "";

            for (int i = 0; i < spaceLeftAndRight; i++)
                spaces += " ";
            for (int i = 0; i < maxChar; i++)
                headerBorder += border;
            if (withOneSpace == 1) oneSpace = " ";

            Console.Clear();
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            if (border == "═")
            {
                Console.WriteLine($"╔{headerBorder}╗");
                Console.WriteLine($"║{spaces}{value}{spaces}{oneSpace}║");
                Console.WriteLine($"╚{headerBorder}╝");
            }
            else
            {
                Console.WriteLine($"{border}{headerBorder}{border}");
                Console.WriteLine($"{border}{spaces}{value}{spaces}{oneSpace}{border}");
                Console.WriteLine($"{border}{headerBorder}{border}");
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Writes a header value with specified formatting to the console.
        /// </summary>
        /// <param name="value">The header value to be written.</param>
        /// <param name="foregroundColor">Optional. Specifies the foreground color for the header (default: ConsoleColor.White).</param>
        /// <param name="maxChar">Optional. Specifies the maximum character length for the header (default: 64).</param>
        public static void WriteHeader(
            string value,
            ConsoleColor foregroundColor = ConsoleColor.White,
            int maxChar = 64)
        {
            WriteHeader(value, foregroundColor, ConsoleColor.Black, maxChar);
        }

        /// <summary>
        /// Writes a header value with default formatting to the console.
        /// </summary>
        /// <param name="value">The header value to be written.</param>
        public static void WriteHeader(string value)
        {
            WriteHeader(value, ConsoleColor.White, ConsoleColor.Black, 64);
        }

        /// <summary>
        /// Displays an error message to the console with a red background and prompts the user to press any key to continue.
        /// </summary>
        /// <param name="value">The error message to display.</param>
        /// <remarks>
        /// This method clears the console, displays a header with a red background indicating an error, presents the error message in red text, and prompts the user to press any key to continue.
        /// </remarks>
        public static void WriteError(string value)
        {
            Console.Clear();
            WriteHeader("Oops! Error 404!", ConsoleColor.DarkRed, 64);

            WriteLine($"Error Message: {value}", ConsoleColor.Red);

            WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Reads a line of input from the console and returns the input string.
        /// </summary>
        /// <param name="color">The color of the text prompt. The default value is ConsoleColor.White.</param>
        /// <returns>The input string entered by the user.</returns>
        /// <remarks>
        /// This method prompts the user for input with the specified text color, reads the input line, and returns the input string. The method resets the console color to the default value after reading the input.
        /// </remarks>
        public static string ReadLine(ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            string input = Console.ReadLine();
            Console.ResetColor();
            return input;
        }

        /// <summary>
        /// Displays a menu with the provided options and allows the user to navigate and select an option using arrow keys and Enter key
        /// </summary>
        /// <param name="menus">An array of strings representing the menu options</param>
        /// <param name="instructions">Optional instructions to display above the menu</param>
        /// <returns>
        /// The index of the selected menu option (1-based index)
        /// </returns>
        public static int WriteMenu(string[] menus, string instructions = "")
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            if (MenuSetting.UseInstructions)
                if (string.IsNullOrEmpty(instructions))
                    Console.WriteLine($"\nUse \u2B06 and \u2B07 to navigate and press the Enter/Return key to select");
                else
                    Console.WriteLine(instructions);

            ConsoleKeyInfo key;
            int option = 1;
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            int numberOfMenus = menus.Length;


            while (true)
            {
                Console.SetCursorPosition(left, top);

                for (int i = 0; i < menus.Length; i++)
                {
                    var menu = menus[i];
                    if (IsTypeWriterMode)
                    {
                        IsTypeWriterMode = false;

                        WriteLine(i + 1 == option ? $"✔  {menu}" : $"   {menu}", i + 1 == option ? MenuSetting.HighlightedOptionColor : MenuSetting.ForegroundColor, MenuSetting.BackgroundColor);
                        IsTypeWriterMode = true;
                    }
                    else
                    {
                        WriteLine($"\t{menu}", i + 1 == option ? MenuSetting.HighlightedOptionColor : MenuSetting.ForegroundColor, MenuSetting.BackgroundColor);
                    }
                }

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        option = option == numberOfMenus ? 1 : option + 1;
                        break;
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? numberOfMenus : option - 1;
                        break;
                    case ConsoleKey.Enter:
                        return option;
                }
            }
        }

        /// <summary>
        /// Static class for storing menu settings such as foreground color, background color, highlighted option color, and whether to use instructions.
        /// </summary>
        public static class MenuSetting
        {
            /// <summary>
            /// Gets or sets the foreground color of the console.
            /// Default value is ConsoleColor.White.
            /// </summary>
            public static ConsoleColor ForegroundColor { get; set; } = ConsoleColor.White;
            /// <summary>
            /// Gets or sets the background color of the console.
            /// </summary>
            public static ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Black;
            /// <summary>
            /// Gets or sets the color used to highlight an option in the console menu.
            /// Default value is ConsoleColor.Green.
            /// </summary>
            public static ConsoleColor HighlightedOptionColor { get; set; } = ConsoleColor.Green;
            /// <summary>
            /// Gets or sets a boolean value indicating whether to use instructions.
            /// Default value is true.
            /// </summary>
            public static bool UseInstructions { get; set; } = true;
        }
    }


}