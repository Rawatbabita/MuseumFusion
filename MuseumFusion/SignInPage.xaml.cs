namespace MuseumFusion;

public partial class SignInPage : ContentPage
{
	public SignInPage()
	{
		InitializeComponent();
	}
    private void OnSignInClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new BookTicketsPage());
    }

    private void OnSignUpClicked(object sender, EventArgs e)
    {
        
        Navigation.PushAsync(new RegistrationPage());
    }
       

}