using System;

namespace MathGame.JonesKwameOsei;

public class Helpers
{
  public string GetUserChoice()
  {
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Enter your choice (1-6 or letter):");
    Console.ForegroundColor = ConsoleColor.Green;
    string input = ReadNonNullLine();
    Console.ResetColor();

    return string.IsNullOrWhiteSpace(input) ? "" : input.Trim();
  }

  public int GetNumberOfQuestions()
  {
    while (true)
    {
      try
      {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("How many questions would you like to answer? (1 - 50, or 0 to go back):");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string input = ReadNonNullLine();
        Console.ResetColor();

        if (!int.TryParse(input, out int questions))
        {
          DisplayError("Please enter a valid number.");
          continue;
        }

        if (questions == 0)
        {
          // Return to main menu
          return 0;
        }

        if (questions < 1 || questions > 50)
        {
          DisplayError("Please enter a number between 1 and 50.");
          continue;
        }

        return questions;
      }
      catch (Exception ex)
      {
        DisplayError($"Error: {ex.Message}. Please try again");
      }
    }
  }
  public string ReadNonNullLine()
  {
    return Console.ReadLine() ?? string.Empty;
  }

  public void DisplayError(string message)
  {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\n❌ {message}");
    Console.ResetColor();
  }

  public void PauseForUser()
  {
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("\nPress any key to continue...");
    Console.ResetColor();
    Console.ReadKey(true);
  }

  public void DisplaySuccess(string message)
  {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"✅ {message}");
    Console.ResetColor();
  }

  public void DisplayWarning(string message)
  {
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"⚠️ {message}");
    Console.ResetColor();
  }

  public void DisplayInfo(string message)
  {
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"ℹ️  {message}");
    Console.ResetColor();
  }
}
