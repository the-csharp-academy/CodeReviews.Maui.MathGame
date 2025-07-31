namespace MathGameMaui;

public partial class PreviousGames : ContentPage
{
	public PreviousGames()
	{
		InitializeComponent();
		gamesList.ItemsSource = App.GameRepository.GetAllGames();
	}

	private void OnDelete(object sender, EventArgs e)
	{
		ImageButton button = (ImageButton)sender;
		App.GameRepository.Delete((int)button.BindingContext);
		gamesList.ItemsSource = App.GameRepository.GetAllGames();
    }

	private void OnBack(object sender, EventArgs e)
	{
		Navigation.PopAsync();
    }
}