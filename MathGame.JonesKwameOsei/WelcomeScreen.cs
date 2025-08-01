using System;

namespace MathGame.JonesKwameOsei;

public class WelcomeScreen
{
  private readonly Helpers _helpers;
  private readonly UserManager _userManager;
  private string? _username;

  public WelcomeScreen()
  {
    _helpers = new Helpers();
    _userManager = new UserManager();
  }

  public void ShowWelcomeScreen()
  {
    _username = _userManager.GetUserName();

    Console.Clear();
    DisplayHeader();
    DisplayDeveloperInfo();
    DisplayWelcomeMessage();
    DisplayMotivationalText();
    DisplayContinuePrompt();

    Console.ReadKey(true); // Wait for any key press
  }

  private void DisplayHeader()
  {
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("╔════════════════════════════════════════════════════════════════════════╗");
    Console.WriteLine("║                                                                        ║");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("║                                  🧮 MATH GAME 🧮                        ║");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("║                                 ✨ Dev Edition ✨                       ║");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("║                                                                        ║");
    Console.WriteLine("╚════════════════════════════════════════════════════════════════════════╝");
    Console.ResetColor();
    Console.WriteLine();
  }

  private void DisplayDeveloperInfo()
  {
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine($"Developed by: JonesDev");
    Console.WriteLine($"Session Date: {DateTime.Now:dddd, MMMM dd, yyyy} at {DateTime.Now:HH:mm}");
    Console.ResetColor();
    Console.WriteLine();
  }

  private void DisplayWelcomeMessage()
  {
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"Welcome 🤝 {(string.IsNullOrEmpty(_username) ? "Player" : _username.ToUpper())}!");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Ready to challenge your math skills?");
    Console.ResetColor();
    Console.WriteLine();
  }

  private void DisplayMotivationalText()
  {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(">> Improve your mental arithmetic through practice");
    Console.WriteLine(">> Track your progress and beat your best scores");
    Console.ResetColor();
    Console.WriteLine();
  }

  private void DisplayContinuePrompt()
  {
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Press any key to continue");
    Console.ResetColor();
  }
}
