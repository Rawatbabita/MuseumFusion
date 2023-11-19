﻿namespace MuseumFusion
{
    public partial class MuseumDetailsPage : ContentPage
    {
        public MuseumDetailsPage()
        {
            InitializeComponent();

            BindingContext = new MuseumDetailsPageViewModel();
        }

        private void OnBuyTicketsClicked(object sender, EventArgs e)
        {
            //  var ticketPrice = ((MuseumDetailsPageViewModel)BindingContext).TicketPrice;


            //Navigation.PushAsync(new SignInPage());
        }
    }

    public class MuseumDetailsPageViewModel : BindableObject
    {
        private string _museumName;
        private string _museumSubtitle;
        private string _todayDate;
        private decimal _ticketPrice;

        public string MuseumName
        {
            get => _museumName;
            set
            {
                _museumName = value;
                OnPropertyChanged(nameof(MuseumName));
            }
        }

        public string MuseumSubtitle
        {
            get => _museumSubtitle;
            set
            {
                _museumSubtitle = value;
                OnPropertyChanged(nameof(MuseumSubtitle));
            }
        }

        public string TodayDate
        {
            get => _todayDate;
            set
            {
                _todayDate = value;
                OnPropertyChanged(nameof(TodayDate));
            }
        }

        public decimal TicketPrice
        {
            get => _ticketPrice;
            set
            {
                _ticketPrice = value;
                OnPropertyChanged(nameof(TicketPrice));
            }
        }
    }
}