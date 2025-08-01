using System;

namespace MathGame.JonesKwameOsei.Models;

public class Program
{
  public static void Main(string[] args)
  {
    Console.Title = "Math Game";

    try
    {
      // * Show welcome screen before main menu
      WelcomeScreen welcomeScreen = new WelcomeScreen();
      welcomeScreen.ShowWelcomeScreen();

      Menu menu = new Menu();
      menu.ShowMainMenu();
    }
    catch (Exception ex)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine($"Fatal error: {ex.Message}");
      Console.ResetColor();
      Console.WriteLine("Press any key to exit...");
      Console.ReadKey();
    }
  }
}
