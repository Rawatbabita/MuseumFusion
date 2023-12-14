using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using MuseumFusion.Model;

namespace MuseumFusion
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Museum> MuseumTiles;

        public MainPage()
        {
            InitializeComponent();
            MuseumTiles = new ObservableCollection<Museum>(GetSampleMuseums());
            museumTilesCollectionView.ItemsSource = MuseumTiles;
        }

        private void OnSortChanged(object sender, EventArgs e)
        {
            var property = SortPicker.SelectedItem as string;

            switch (property)
            {
                case "Name":
                    MuseumTiles = new ObservableCollection<Museum>(MuseumTiles.OrderBy(m => m.Name));
                    break;
                case "Place":
                    MuseumTiles = new ObservableCollection<Museum>(MuseumTiles.OrderBy(m => m.Place));
                    break;
                case "Date":
                    MuseumTiles = new ObservableCollection<Museum>(MuseumTiles.OrderBy(m => m.Date));
                    break;
            }

            museumTilesCollectionView.ItemsSource = MuseumTiles;
        }

        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = e.NewTextValue.ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                museumTilesCollectionView.ItemsSource = MuseumTiles;
            }
            else
            {
                var filteredMuseums = MuseumTiles
                    .Where(m => m.Name.ToLower().Contains(keyword) || m.Place.ToLower().Contains(keyword))
                    .ToList();

                museumTilesCollectionView.ItemsSource = new ObservableCollection<Museum>(filteredMuseums);
            }
        }

        private void OnMuseumSelected(object sender, EventArgs e)
        {
            var selectedMuseum = (sender as View)?.BindingContext as Museum;

            if (selectedMuseum != null)
            {
                // Navigate to the 'museumDetails' page with selectedMuseum details
                Navigation.PushAsync(new MuseumDetailsPage(selectedMuseum));
            }
        }

        public static ObservableCollection<Museum> GetSampleMuseums()
        {
            return new ObservableCollection<Museum>
            {
                new Museum { Name = "Royal Ontario Museum", Place = "Toronto", Date = DateTime.Now.AddDays(1), ImageUrl = "canada.jpeg", 
                            Price = 26, Description = "Opened in 1914, the Royal Ontario Museum (ROM) showcases art, culture, and nature from around the globe and across the ages. One of North America's most renowned cultural institutions, Canada's largest museum is home to a world-class collection of more than six million objects and specimens, featured in 40 gallery and exhibition spaces." },
                new Museum { Name = "Canadian War Museum", Place = "Ottawa", Date = DateTime.Now.AddDays(-10), ImageUrl = "canadianmuseum.jpg", 
                            Price= 23, Description = "The Canadian War Museum is more than a museum that is internationally renowned for its symbolic architecture; it is synonym for inspiring and touching stories. Canada's rich military history is showcased through personal stories, artwork, photographs and interactive presentations. Tour the extensive permanent exhibitions and expand your knowledge of the conflicts that shaped Canada, Canadians and the world, as well as the roll Canadians played in them." },
                new Museum { Name = "Royal BC Museum", Place = "Victoria, British Columbia", Date = DateTime.Now.AddDays(-10), ImageUrl = "woollymammoth.jpg",
                            Price= 20, Description = "Explore the history of British Columbia from the dinosaurs that once roamed our province, to the forest creatures that still share our home." },
                new Museum { Name = "Victoria Guided Food and History Tour", Place = "Victoria", Date = DateTime.Now.AddDays(-10), ImageUrl = "ce.jpg",
                            Price= 89, Description = "Eat and drink your way through historic Victoria on a gourmet walking tour that explores the city’s key sites. From Victoria Public Market to the Parliament Buildings, make stops to sample craft beer, chocolate, cheese, tea, and other local treats. It’s a delicious way to combine sightseeing with Victoria’s most delicious flavors, with both morning and afternoon departures available." },

            };
        }
    }

    //public partial class MainPage : ContentPage
    //{
    //    public ObservableCollection<Museum> Museums { get; set; }
    //    public ObservableCollection<Museum> FilteredMuseums { get; set; }
    //    public List<string> SortOptions { get; } = new List<string> { "Name", "Place", "Date" };

    //    private string currentSortOption = "Name"; // Default sorting option

    //    public MainPage()
    //    {
    //        InitializeComponent();

    //        Museums = new ObservableCollection<Museum>
    //        {
    //            new Museum { Name = "Museum 1", ImageUrl = "museum1.jpg", Place = "Place 1", Date = DateTime.Now.AddDays(1) },
    //            new Museum { Name = "Museum 2", ImageUrl = "museum1.jpg", Place = "Place 0", Date = DateTime.Now.AddDays(2) },
    //            // Add more museums as needed
    //        };

    //        FilteredMuseums = new ObservableCollection<Museum>(Museums);

    //        BindingContext = this;
    //    }

    //    private void OnMuseumSelected(object sender, SelectionChangedEventArgs e)
    //    {
    //        if (e.CurrentSelection.FirstOrDefault() is Museum selectedMuseum)
    //        {
    //            Navigation.PushAsync(new MuseumDetailsPage(selectedMuseum));
    //            ((CollectionView)sender).SelectedItem = null; // Reset selection
    //        }
    //    }

    //    private void OnSortChanged(object sender, EventArgs e)
    //    {
    //        currentSortOption = SortPicker.SelectedItem.ToString();
    //        SortMuseums();
    //    }

    //    private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
    //    {
    //        FilterMuseums(FilterEntry.Text);
    //    }

    //    private void SortMuseums()
    //    {
    //        switch (currentSortOption)
    //        {
    //            case "Name":
    //                FilteredMuseums = new ObservableCollection<Museum>(FilteredMuseums.OrderBy(m => m.Name));
    //                break;
    //            case "Place":
    //                FilteredMuseums = new ObservableCollection<Museum>(FilteredMuseums.OrderBy(m => m.Place));
    //                break;
    //            case "Date":
    //                FilteredMuseums = new ObservableCollection<Museum>(FilteredMuseums.OrderBy(m => m.Date));
    //                break;
    //        }
    //    }

    //    private void FilterMuseums(string filter)
    //    {
    //        if (string.IsNullOrEmpty(filter))
    //        {
    //            FilteredMuseums = new ObservableCollection<Museum>(Museums);
    //        }
    //        else
    //        {
    //            FilteredMuseums = new ObservableCollection<Museum>(
    //                Museums.Where(m => m.Name.ToLower().Contains(filter.ToLower())));
    //        }

    //        SortMuseums();
    //    }
    //}


}
