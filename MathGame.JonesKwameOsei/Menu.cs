using System;

namespace MathGame.JonesKwameOsei.Models;

public class Menu
{
  private readonly GameEngine _gameEngine;
  private readonly Helpers _helpers;
  private readonly UserManager _userManager;

  public Menu()
  {
    _gameEngine = new GameEngine();
    _helpers = new Helpers();
    _userManager = new UserManager();
  }

  public void ShowMainMenu()
  {
    while (true)
    {
      try
      {
        DisplayMainMenu();
        string choice = _helpers.GetUserChoice();

        if (!ProcessMenuChoice(choice))
          break;
      }
      catch (Exception ex)
      {
        _helpers.DisplayError($"An unexpected error occurred: {ex.Message}");
        _helpers.PauseForUser();
      }
    }
  }

  private void DisplayMainMenu()
  {
    Console.Clear();

    // Main menu header with gradient effect
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(new string('═', 70));
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("                     🧮 MATH GAME 🧮");
    Console.WriteLine();
    Console.WriteLine("                  Welcome to the Math Game");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(new string('═', 70));
    Console.ResetColor();

    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Select the game you want to play:");
    Console.ResetColor();
    Console.WriteLine();

    // Menu options with other colors
    DisplayMenuOption("1", "A", "Addition", "➕", ConsoleColor.Green);
    DisplayMenuOption("2", "S", "Subtraction", "➖", ConsoleColor.Red);
    DisplayMenuOption("3", "M", "Multiplication", "✖️", ConsoleColor.Green);
    DisplayMenuOption("4", "D", "Division", "➗", ConsoleColor.Green);

    Console.WriteLine();
    DisplayMenuOption("5", "H", "History", "📜", ConsoleColor.Green);
    DisplayMenuOption("6", "Q", "Quit", "❌", ConsoleColor.Red);

    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(new string('═', 70));
    Console.ResetColor();
  }

  private void DisplayMenuOption(string number, string letter, string operation, string icon, ConsoleColor color)
  {
    Console.ForegroundColor = ConsoleColor.White;
    // Console.Write("  ");
    Console.WriteLine();
    Console.ForegroundColor = color;
    Console.WriteLine($"{number}. [{letter}]");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"{operation,-15}");
    Console.ForegroundColor = color;
    Console.WriteLine($" {icon}");
    Console.ResetColor();
  }

  private bool ProcessMenuChoice(string choice)
  {
    switch (choice.ToLower())
    {
      case "1":
      case "a":
        _gameEngine.StartGame("Addition", '+', ConsoleColor.Green);
        break;
      case "2":
      case "s":
        _gameEngine.StartGame("Subtraction", '-', ConsoleColor.Red);
        break;
      case "3":
      case "m":
        _gameEngine.StartGame("Multiplication", '*', ConsoleColor.Blue);
        break;
      case "4":
      case "d":
        _gameEngine.StartGame("Division", '/', ConsoleColor.Magenta);
        break;
      case "5":
      case "h":
        _gameEngine.ShowGameHistory();
        break;
      case "6":
      case "q":
        ShowExitMessage();
        return false;
      default:
        _helpers.DisplayError("Invalid selection. Please try again.");
        _helpers.PauseForUser();
        break;
    }

    return true;
  }

  private void ShowExitMessage()
  {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(new string('═', 60));
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("                Thank you for playing!");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("                    Goodbye! 👋");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(new string('═', 60));
    Console.ResetColor();
    Console.WriteLine("\nPress any key to exit...");
    Console.ReadKey();
  }
}
