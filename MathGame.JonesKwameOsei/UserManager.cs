using System;

namespace MathGame.JonesKwameOsei;

public class UserManager
{
  public readonly Helpers _helpers;
  private static string _currentUsername = string.Empty;

  public UserManager()
  {
    _helpers = new Helpers();
  }

  public string GetUserName()
  {
    if (string.IsNullOrEmpty(_currentUsername))
    {
      _currentUsername = PromptForUsername();
    }

    return _currentUsername;
  }

  private string PromptForUsername()
  {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
    Console.WriteLine("║                     👋 WELCOME TO MATH GAME                  ║");
    Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
    Console.ResetColor();
    Console.WriteLine();

    string username;
    while (true)
    {
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write("Please enter your name: ");
      Console.ForegroundColor = ConsoleColor.Yellow;
      username = _helpers.ReadNonNullLine().Trim();
      Console.ResetColor();

      if (!string.IsNullOrWhiteSpace(username) && username.Length <= 20)
      {
        break;
      }

      _helpers.DisplayError("Please enter a valid name (1-20 characters)");
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"\n✅ Nice to meet you, {username}!");
    Console.ResetColor();
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey(true);

    return username;
  }

  public void ChangeUsername()
  {
    _currentUsername = string.Empty; // resets name
    _currentUsername = PromptForUsername();
  }
}

