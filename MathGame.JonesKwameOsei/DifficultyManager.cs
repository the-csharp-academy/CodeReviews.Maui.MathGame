using System;

namespace MathGame.JonesKwameOsei.Models;

public class DifficultyManager
{
  private readonly Helpers _helpers;

  public DifficultyManager()
  {
    _helpers = new Helpers();
  }

  public DifficultyLevel SelectDifficulty()
  {
    while (true)
    {
      DisplayDifficultyMenu();
      string choice = _helpers.GetUserChoice();

      switch (choice.ToLower())
      {
        case "1":
        case "e":
          return DifficultyLevel.Easy;
        case "2":
        case "m":
          return DifficultyLevel.Moderate;
        case "3":
        case "h":
          return DifficultyLevel.Hard;
        case "0":
        case "b":
          return (DifficultyLevel)0; // Back to main menu
        default:
          _helpers.DisplayError("Invalid selection. Please try again.");
          _helpers.PauseForUser();
          break;
      }
    }
  }

  private void DisplayDifficultyMenu()
  {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(new string('═', 70));
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("                        🎯 SELECT DIFFICULTY LEVEL");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(new string('═', 70));
    Console.ResetColor();
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Choose your challenge level:");
    Console.ResetColor();
    Console.WriteLine();

    // Easy Level
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("  1. [E]asy      🟢 ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("- Small numbers, perfect for beginners");
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine("                     Addition/Subtraction: 1-20, Multiplication: 1-5, Division: 1-5");
    Console.ResetColor();
    Console.WriteLine();

    // Moderate Level
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("  2. [M]oderate  🟡 ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("- Medium numbers, good for practice");
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine("                     Addition/Subtraction: 1-50, Multiplication: 1-10, Division: 1-10");
    Console.ResetColor();
    Console.WriteLine();

    // Hard Level
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("  3. [H]ard      🔴 ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("- Large numbers, for math masters");
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine("                     Addition/Subtraction: 1-100, Multiplication: 1-15, Division: 1-15");
    Console.ResetColor();
    Console.WriteLine();

    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("  0. [B]ack      ⬅ ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(" - Return to main menu");
    Console.ResetColor();

    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine(new string('═', 70));
    Console.ResetColor();
  }

  public (int, int, int) GenerateQuestionByDifficulty(char operation, DifficultyLevel difficulty, Random random)
  {
    return operation switch
    {
      '+' => GenerateAddition(difficulty, random),
      '-' => GenerateSubtraction(difficulty, random),
      '*' => GenerateMultiplication(difficulty, random),
      '/' => GenerateDivision(difficulty, random),
      _ => throw new ArgumentException("Invalid operation")
    };
  }

  private (int, int, int) GenerateAddition(DifficultyLevel difficulty, Random random)
  {
    var (min, max) = GetAdditionSubtractionRange(difficulty);
    int num1 = random.Next(min, max + 1);
    int num2 = random.Next(min, max + 1);
    return (num1, num2, num1 + num2);
  }

  private (int, int, int) GenerateSubtraction(DifficultyLevel difficulty, Random random)
  {
    var (min, max) = GetAdditionSubtractionRange(difficulty);
    int num1 = random.Next(min, max + 1);
    int num2 = random.Next(min, num1 + 1); // Ensure positive result
    return (num1, num2, num1 - num2);
  }

  private (int, int, int) GenerateMultiplication(DifficultyLevel difficulty, Random random)
  {
    var (min, max) = GetMultiplicationDivisionRange(difficulty);
    int num1 = random.Next(min, max + 1);
    int num2 = random.Next(min, max + 1);
    return (num1, num2, num1 * num2);
  }

  private (int, int, int) GenerateDivision(DifficultyLevel difficulty, Random random)
  {
    var (min, max) = GetMultiplicationDivisionRange(difficulty);
    int answer = random.Next(min, max + 1);
    int num2 = random.Next(min, max + 1);
    int num1 = answer * num2;
    return (num1, num2, answer);
  }

  private (int min, int max) GetAdditionSubtractionRange(DifficultyLevel difficulty)
  {
    return difficulty switch
    {
      DifficultyLevel.Easy => (1, 20),
      DifficultyLevel.Moderate => (1, 50),
      DifficultyLevel.Hard => (1, 100),
      _ => (1, 20)
    };
  }

  private (int min, int max) GetMultiplicationDivisionRange(DifficultyLevel difficulty)
  {
    return difficulty switch
    {
      DifficultyLevel.Easy => (1, 5),
      DifficultyLevel.Moderate => (1, 10),
      DifficultyLevel.Hard => (1, 15),
      _ => (1, 5)
    };
  }

  public string GetDifficultyDescription(DifficultyLevel difficulty)
  {
    return difficulty switch
    {
      DifficultyLevel.Easy => "🟢 Easy - Perfect for beginners",
      DifficultyLevel.Moderate => "🟡 Moderate - Good for practice",
      DifficultyLevel.Hard => "🔴 Hard - For math masters",
      _ => "Unknown difficulty"
    };
  }
}
