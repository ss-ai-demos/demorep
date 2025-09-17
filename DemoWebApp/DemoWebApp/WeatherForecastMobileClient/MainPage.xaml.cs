namespace WeatherForecastMobileClient;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	public static string GetCounterText(int count)
	{
		return count == 1 ? $"Clicked {count} time" : $"Clicked {count} times";
	}

	private void OnCounterClicked(object? sender, EventArgs e)
	{
		count++;

		CounterBtn.Text = GetCounterText(count);
		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}
