namespace MuseumFusion;

public partial class PaymentPage : ContentPage
{
	public PaymentPage()
	{
		InitializeComponent();
	}
    private void OnPayNowClicked(object sender, EventArgs e)
    {
        
        Navigation.PushAsync(new CongratulationsPage());
    }
}