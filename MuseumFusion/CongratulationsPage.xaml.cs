namespace MuseumFusion;

public partial class CongratulationsPage : ContentPage
{
	public CongratulationsPage()
	{
		InitializeComponent();
	}
    private void OnGoToHomeClicked(object sender, EventArgs e)
    {
        // Navigate to Home Page or the appropriate starting point of your app
        Navigation.PopToRootAsync();
    }
}