using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using MuseumFusion.Model;

namespace MuseumFusion
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Museum> Museums { get; set; }
        public ObservableCollection<Museum> FilteredMuseums { get; set; }
        public List<string> SortOptions { get; } = new List<string> { "Name", "Place", "Date" };

        private string currentSortOption = "Name"; // Default sorting option

        public MainPage()
        {
            InitializeComponent();

            Museums = new ObservableCollection<Museum>
            {
                new Museum { Name = "Museum 1", ImageUrl = "museum1.jpg", Place = "Place 1", Date = DateTime.Now.AddDays(1) },
                new Museum { Name = "Museum 2", ImageUrl = "museum1.jpg", Place = "Place 0", Date = DateTime.Now.AddDays(2) },
                // Add more museums as needed
            };

            FilteredMuseums = new ObservableCollection<Museum>(Museums);

            BindingContext = this;
        }

        private void OnMuseumSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Museum selectedMuseum)
            {
                Navigation.PushAsync(new MuseumDetailsPage(selectedMuseum));
                ((CollectionView)sender).SelectedItem = null; // Reset selection
            }
        }

        private void OnSortChanged(object sender, EventArgs e)
        {
            currentSortOption = SortPicker.SelectedItem.ToString();
            SortMuseums();
        }

        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            FilterMuseums(FilterEntry.Text);
        }

        private void SortMuseums()
        {
            switch (currentSortOption)
            {
                case "Name":
                    FilteredMuseums = new ObservableCollection<Museum>(FilteredMuseums.OrderBy(m => m.Name));
                    break;
                case "Place":
                    FilteredMuseums = new ObservableCollection<Museum>(FilteredMuseums.OrderBy(m => m.Place));
                    break;
                case "Date":
                    FilteredMuseums = new ObservableCollection<Museum>(FilteredMuseums.OrderBy(m => m.Date));
                    break;
            }
        }

        private void FilterMuseums(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                FilteredMuseums = new ObservableCollection<Museum>(Museums);
            }
            else
            {
                FilteredMuseums = new ObservableCollection<Museum>(
                    Museums.Where(m => m.Name.ToLower().Contains(filter.ToLower())));
            }

            SortMuseums();
        }
    }


}
