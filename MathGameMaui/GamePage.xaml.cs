using MathGameMaui.Models;

namespace MathGameMaui;

public partial class GamePage : ContentPage {
    public string GameType { get; set; }
    int firstNumber = 0;
    int secondNumber = 0;
    int score = 0;
    const int totalQuestions = 2;
    int gamesLeft = totalQuestions;
    public GamePage(string gameType) {
        InitializeComponent();
        GameType = gameType;
        BindingContext = this;
        CreateNewQuestion();
    }

    private void CreateNewQuestion() {

        Random random = new Random();

        firstNumber = GameType != "Division" ? Random.Shared.Next(1, 9) : Random.Shared.Next(1, 99);
        secondNumber = GameType != "Division" ? Random.Shared.Next(1, 9) : Random.Shared.Next(1, 99);

        if (GameType == "Division" && firstNumber % secondNumber != 0) {
            while (firstNumber < secondNumber || firstNumber % secondNumber != 0) {
                firstNumber = Random.Shared.Next(1, 99);
                secondNumber = Random.Shared.Next(1, 99);
            }
        }

        QuestionLabel.Text = $"{firstNumber} {GameType} {secondNumber}";
    }

    private void OnAnswerSubmitted(object sender, EventArgs e) {
        int answer;
        bool isCorrect = false;

        if (!int.TryParse(AnswerEntry.Text, out answer)) {
            AnswerLabel.Text = "Please enter a valid number.";
            return;
        }

            switch (GameType) {
                case "+":
                    isCorrect = (firstNumber + secondNumber) == answer;
                    break;
                case "-":
                    isCorrect = (firstNumber - secondNumber) == answer;
                    break;
                case "x":
                    isCorrect = (firstNumber * secondNumber) == answer;
                    break;
                case "/":
                    isCorrect = (firstNumber / secondNumber) == answer;
                    break;
            }

        ProcessAnswer(isCorrect);
        gamesLeft--;
        AnswerEntry.Text = string.Empty;

        if (gamesLeft > 0) {
            CreateNewQuestion();
        } else {
            GameOver();
        }
    }

    private void GameOver() {

        GameOperation gameOperation = GameType switch {
            "+" => GameOperation.Addition,
            "-" => GameOperation.Subtraction,
            "x" => GameOperation.Multiplication,
            "/" => GameOperation.Division,
        };

        QuestionArea.IsVisible = false;
        BackToMenuBtn.IsVisible = true;
        GameOverLabel.Text = $"Game Over! Your score is {score} out of {totalQuestions}.";

        App.GameRepository.Add(new Game {
            Type = gameOperation,
            Score = score,
            DatePlayed = DateTime.Now
        });
    }

    private void ProcessAnswer(bool isCorrect) {
        if (isCorrect)
            score++;
        AnswerLabel.Text = isCorrect ? $"Correct!" : "Incorrect";
    }

    private void OnBackToMenu(object sender, EventArgs e) {
        Navigation.PushAsync(new MainPage());
    }
}