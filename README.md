# Alcuino.ConsoleWriter472

ConsoleWriter472 is a C# utility class designed to enhance console output capabilities with additional features for text alignment, colors, typewriter-like effects, and structured formatting.



![ConsoleWriter_Write](https://github.com/alcuinon/Alcuino.ConsoleWriter472/blob/main/Alcuino.ConsoleWriter472/Files/ConsoleWriter_Write.gif)

## Properties

- IsTypeWriterMode (false as default, optional)
- TypeWriterSpeed (2 as default)
- IsTypeWriterByWord = false (false as default)

## Methods

- Write()
- WriteLine()
- WriteColumn()
- WriteHeader()
- TypeWrite()
- TypeWriteLine()
- ReadLine()
- WriteMenu() new!

## Features

- **Typewriter Mode**
  - Simulate the typewriter effect with customizable typing speeds.
  - Control individual character or word-by-word typing.
  
- **Text Formatting**
  - Write and write lines of text with custom foreground and background colors.
  - Format text into visually appealing columns with specified alignment and colors.

- **Header Display**
  - Create centered headers with customized foreground and background colors.
  - Design headers with borders for a structured display.

- **Input Handling**
  - Read user input with customizable prompt colors.

- **Creates Functional Menu**
  - Create a simple menus that returns integer on selected menu
  - Customizable menu, can change foreground/background color
  - Disable instructions used or you can have your own instructions

## Usage

![ConsoleWriter_TypeWriter](https://github.com/alcuinon/Alcuino.ConsoleWriter472/blob/main/Alcuino.ConsoleWriter472/Files/ConsoleWriter_TypeWriter.gif)

### Typewriter Mode

```csharp
// Enable typewriter mode, allow ConsoleWriter.Write and ConsoleWriter.WriteLine to take effect
ConsoleWriter.IsTypeWriterMode = true;

// Set typing speed (in milliseconds)
ConsoleWriter.TypeWriterSpeed = 2;

// Write text with typewriter effect
ConsoleWriter.TypeWrite("Hello, World!");

```

### Text Formatting
```csharp
// Write text with custom colors
ConsoleWriter.Write("Hello, World!", ConsoleColor.Green, ConsoleColor.Black);

// Write a line of text with custom colors
ConsoleWriter.WriteLine("Welcome!", ConsoleColor.Yellow, ConsoleColor.Blue);

// Create formatted columns
string[] columnData = { "Column 1", "Column 2", "Column 3" };
ConsoleWriter.WriteColumn(columnData, Align.Center, 15, ConsoleColor.Cyan, ConsoleColor.Magenta);

// Create formatted columns with customize max characters per column
Dictionary<string, int> columnData = new Dictionary<string, int>()
{
    { "Column 1", 8 },
    { "Column 2", 8 },
    { "Column 3", 16 }
};
ConsoleWriter.WriteColumn(columnData, Align.Center, ConsoleColor.Cyan, ConsoleColor.Magenta);
```

### Header Display

```csharp
// Display a header with custom colors
ConsoleWriter.WriteHeader("ConsoleWriter472", ConsoleColor.White, ConsoleColor.DarkBlue, 30);
```

### Text Input

```csharp
// Prompt user for input
string userInput = ConsoleWriter.ReadLine(ConsoleColor.Yellow);
```

![ConsoleWriter_WriteMenu](https://github.com/alcuinon/Alcuino.ConsoleWriter472/blob/main/Alcuino.ConsoleWriter472/Files/ConsoleWriter_WriteMenu.gif)

### Create Menu

```csharp
// create menu
string[] menus = {
        "Add Person",
        "Update Person",
        "Add Person",
        "Display Somthing",
        "Exit",
    };

int option = ConsoleWriter.WriteMenu(menus);
```
