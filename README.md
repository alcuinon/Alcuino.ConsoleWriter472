# Alcuino.ConsoleWriter472

ConsoleWriter472 is a C# utility class designed to enhance console output capabilities with additional features for text alignment, colors, typewriter-like effects, and structured formatting.

## Properties

- IsTypeWriterMode = false
- TypeWriterSpeed = 2
- IsTypeWriterByWord = false

## Methods

- Write()
- WriteLine()
- WriteColumn()
- WriteHeader()
- TypeWrite()
- TypeWriteLine()
- ReadLine()

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

## Usage

### Typewriter Mode

```csharp
// Enable typewriter mode
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