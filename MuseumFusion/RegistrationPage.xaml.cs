namespace MuseumFusion;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();
	}
    private void OnSignUpClicked(object sender, EventArgs e)
    {
        
        bool registrationSuccessful = true;

        if (registrationSuccessful)
        {
            
            Navigation.PushAsync(new BookTicketsPage());
        }
        else
        {
            
        }
    }
}