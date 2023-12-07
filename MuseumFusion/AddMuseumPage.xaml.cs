using MuseumFusion.Model;
using System.ComponentModel;

namespace MuseumFusion;

public partial class AddMuseumPage : ContentPage
{
    public AddMuseumPage()
    {
        InitializeComponent();
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        var name = entryName.Text;
        var place = entryPlace.Text;
        var date = datePicker.Date; 
        var image = entryImage.Text;
        var description = entryDescription.Text;

        // Validate input fields before saving
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(place) || string.IsNullOrWhiteSpace(date.ToString()) 
            || string.IsNullOrWhiteSpace(image) || string.IsNullOrWhiteSpace(description))
        {
            DisplayAlert("Validation Error", "Please fill in all required fields.", "OK");
            return;
        }
        if (!decimal.TryParse(entryPrice.Text, out decimal price))
        {
            DisplayAlert("Validation Error", "Please enter a valid price.", "OK");
            return;
        }

        // Create a new Museum object
        var newMuseum = new Museum
        {
            Name = name,
            Place = place,
            Date = date,
            ImageUrl = image,
            Description = description,
            Price = price
            // Add more properties as needed
        };

        // Set the newly added museum to be used in OnAppearing of AdminPage
        //(Application.Current as App).NewlyAddedMuseum = newMuseum;

        // Pop the AddMuseumPage off the navigation stack
        Navigation.PopAsync();
    }
}