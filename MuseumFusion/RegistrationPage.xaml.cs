using MuseumFusion.Model;

namespace MuseumFusion;

public partial class SignUpPage : ContentPage
{
    private User _user;

    public SignUpPage()
    {
        InitializeComponent();
        _user = new User();
        BindingContext = _user;
    }

    private async void OnCreateAccountClicked(object sender, System.EventArgs e)
    {
        if (ValidateInput())
        {
            if (!UserExists(_user.Email))
            {
                var users = GetSampleUsers();
                users.Add(_user);

                // Implement navigation logic to go back to the sign-in page or another destination
                await DisplayAlert("Success", "Account created successfully!", "OK");
                if(_user.IsAdmin)
                    await Navigation.PushAsync(new AdminPage());
                else
                    await Navigation.PopToRootAsync();
            }
            else
            {
                await DisplayAlert("Error", "User with the same email already exists", "OK");
            }
        }
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(_user.Name) ||
            string.IsNullOrWhiteSpace(_user.Email) ||
            string.IsNullOrWhiteSpace(_user.Password))
        {
            DisplayAlert("Validation Error", "Please fill in all required fields.", "OK");
            return false;
        }

        return true;
    }

    private bool UserExists(string email)
    {
        var users = GetSampleUsers();
        return users.Any(u => u.Email == email);
    }

    private System.Collections.Generic.List<User> GetSampleUsers()
    {
        return new System.Collections.Generic.List<User>
            {
                new User { Name = "John Doe", Email = "john@example.com", Password = "password123", IsAdmin = false },
                new User { Name = "Admin User", Email = "admin@example.com", Password = "admin123", IsAdmin = true },
                // Add more users as needed
            };
    }
}