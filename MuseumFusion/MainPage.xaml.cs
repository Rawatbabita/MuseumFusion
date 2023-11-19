using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace MuseumFusion
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();
        }

        public class MainPageViewModel : BindableObject
        {
            public string MuseumName { get; } = "Modern Art Expo";
            public string MuseumSubtitle { get; } = "Gallery of Modern Art   ";
            public string TodayDate { get; } = DateTime.Now.ToString("MMMM dd, yyyy");

            public ICommand MuseumBlockTappedCommand { get; }

            public MainPageViewModel()
            {
                MuseumBlockTappedCommand = new Command(OnMuseumBlockTapped);
            }

            private void OnMuseumBlockTapped()
            {
                var museumDetailsViewModel = new MuseumDetailsPageViewModel
                {
                    MuseumName = MuseumName,
                    MuseumSubtitle = MuseumSubtitle,
                    TodayDate = TodayDate
                };

                var museumDetailsPage = new MuseumDetailsPage { BindingContext = museumDetailsViewModel };
                Application.Current.MainPage.Navigation.PushAsync(museumDetailsPage);
            }
        }
    }
}
