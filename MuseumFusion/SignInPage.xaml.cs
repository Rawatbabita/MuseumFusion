using MuseumFusion.Model;
using MuseumFusion.ViewModels;
namespace MuseumFusion;

public partial class SignInPage : ContentPage
{
    //private User _user;

    public SignInPage(LoginPageVM vm)
    {
        InitializeComponent();
        //_user = new User();
        BindingContext = vm;
    }

//    private async void OnLogInClicked(object sender, EventArgs e)
//    {
//        if (ValidateInput())
//        {
//            // Perform authentication
//            User authenticatedUser = AuthenticateUser(_user.Email, _user.Password);

//            if (authenticatedUser != null)
//            {
//                await DisplayAlert("Welcome", "Log In Successful!", "OK");
//                await Navigation.PopAsync();
//            }
//            else
//            {
//                await DisplayAlert("Authentication Failed", "Invalid email or password", "OK");
//            }
//        }
//    }

//    private User AuthenticateUser(string email, string password)
//    {
//        var users = GetSampleUsers();
//        return users.FirstOrDefault(u => u.Email == email && u.Password == password);
//    }

//    private bool ValidateInput()
//    {
//        if (string.IsNullOrWhiteSpace(_user.Email) || string.IsNullOrWhiteSpace(_user.Password))
//        {
//            DisplayAlert("Validation Error", "Please fill in all required fields.", "OK");
//            return false;
//        }

//        return true;
//    }

//    private void OnForgotPasswordClicked(object sender, EventArgs e)
//    {
//        DisplayAlert("Forgot Password", "Implement Forgot Password logic here", "OK");
//    }

//    private void OnSignUpClicked(object sender, EventArgs e)
//    {
//        Navigation.PushAsync(new SignUpPage());
//    }

//    // Sample method to generate a list of sample users (replace with your actual data source)
//    private User[] GetSampleUsers()
//    {
//        return new User[]
//        {
//                new User { Name = "John Doe", Email = "john@example.com", Password = "password123", IsAdmin = false },
//                new User { Name = "Admin User", Email = "admin@example.com", Password = "admin123", IsAdmin = true },
//        };
//    }
}

//private void OnSignInClicked(object sender, EventArgs e)
//{
//    Navigation.PushAsync(new BookTicketsPage());
//}
