namespace MuseumFusion;

public partial class BookTicketsPage : ContentPage
{
	public BookTicketsPage()
	{
		InitializeComponent();
	}
    private void OnBuyClicked(object sender, EventArgs e)
    {
        
        Navigation.PushAsync(new PaymentPage());
    }
}