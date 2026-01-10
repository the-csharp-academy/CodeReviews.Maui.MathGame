namespace MathGame.Maui;

public partial class PreviousGames : ContentPage
{
	public PreviousGames()
	{
		InitializeComponent();

        var games = App.GameRepository.GetAllGames().ToList();
        gamesList.ItemsSource = games;

        DataDisplaySection.IsVisible = games.Count > 0;

        //var games = App.GameRepository.GetAllGames();
        //gamesList.ItemsSource = games.ToList();

        //if (gamesList.ItemsSource.Count > 0)
        //      {
        //	DataDisplaySection.IsVisible = true;
        //}

    }

    private void OnDelete(object sender, EventArgs e)
	{
		ImageButton btn = (ImageButton)sender;
		int gameId = (int)btn.CommandParameter;

		App.GameRepository.Delete(gameId);

		gamesList.ItemsSource = App.GameRepository.GetAllGames();
	}

    private void OnBackToMenu(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}