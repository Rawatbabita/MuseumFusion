using MuseumFusion.Model;
using System.Collections.ObjectModel;

namespace MuseumFusion;

public partial class AdminPage : ContentPage
{
    private ObservableCollection<Museum> MuseumTiles;

    public AdminPage()
    {
        InitializeComponent();
        MuseumTiles = new ObservableCollection<Museum>(MainPage.GetSampleMuseums());
        museumTilesCollectionView.ItemsSource = MuseumTiles;
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        // Implement logic to delete the museum tile
        var selectedMuseum = (sender as MenuItem)?.CommandParameter as Museum;
        MuseumTiles.Remove(selectedMuseum);
    }

    private void OnAddMuseumClicked(object sender, EventArgs e)
    {
        // Navigate to the 'AddMuseumPage'
        Navigation.PushAsync(new AddMuseumPage());
    }


}