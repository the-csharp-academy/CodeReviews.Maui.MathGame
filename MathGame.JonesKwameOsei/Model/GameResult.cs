using System;

namespace MathGame.JonesKwameOsei.Models;

public class GameResult
{
  public DateTime Date { get; set; }
  public string? Operation { get; set; }
  public int Score { get; set; }
  public int QuestionsAsked { get; set; }
  public DifficultyLevel Difficulty { get; set; }
  public double Accuracy => QuestionsAsked > 0 ? (double)Score / QuestionsAsked * 100 : 0;

  public override string ToString()
  {
    string difficultyIcon = Difficulty switch
    {
      DifficultyLevel.Easy => "🟢",
      DifficultyLevel.Moderate => "🟡",
      DifficultyLevel.Hard => "🔴",
      _ => "⚪"
    };

    return $"{Date:MM-dd-yyyy HH:mm} | {Operation,-12} | {difficultyIcon} {Difficulty,-8} | {Score,2}/{QuestionsAsked,-2} | {Accuracy:F1}%";
  }
}

public class GameSession
{
  public string OperationType { get; set; } = string.Empty;
  public char OperatorSymbol { get; set; }
  public int NumberOfQuestions { get; set; }
  public int CurrentScore { get; set; }
  public List<string> GameLog { get; set; } = new List<string>();
  public ConsoleColor ThemeColor { get; set; }
  public DifficultyLevel Difficulty { get; set; }
}

public enum GameOperation
{
  Addition = 1,
  Subtraction = 2,
  Multiplication = 3,
  Division = 4,
  History = 5,
  ChangeUsername = 6,
  Quit = 7
}

public enum DifficultyLevel
{
  Easy = 1,
  Moderate = 2,
  Hard = 3
}
