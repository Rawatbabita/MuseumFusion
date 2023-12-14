using MuseumFusion.Model;
using MuseumFusion.ViewModels;

namespace MuseumFusion
{
    public partial class MuseumDetailsPage : ContentPage
    {
        public Museum museum { get; set; }
        public MuseumDetailsPage(Museum _museum)
        {
            InitializeComponent();
            museum = _museum;
            BindingContext = museum;
        }

        private async void OnBuyTicketsClicked(object sender, EventArgs e)
        {
            bool isLoggedIn = CheckIfUserLoggedIn();

            if (isLoggedIn)
            {
                await Navigation.PushAsync(new PaymentPage(museum));
            }
            else
            {
                await Navigation.PushAsync(new SignInPage(new LoginPageVM()));
            }
        }

        private bool CheckIfUserLoggedIn()
        {
            return true; // Assume the user is logged in
        }
    }


    //public partial class MuseumDetailsPage : ContentPage
    //{
    //    public MuseumDetailsPage()
    //    {
    //        InitializeComponent();

    //        BindingContext = new MuseumDetailsPageViewModel();
    //    }

    //    private void OnBuyTicketsClicked(object sender, EventArgs e)
    //    {
    //      //  var ticketPrice = ((MuseumDetailsPageViewModel)BindingContext).TicketPrice;
          
            
    //        Navigation.PushAsync(new SignInPage());
    //    }
    //}

    //public class MuseumDetailsPageViewModel : BindableObject
    //{
    //    private string _museumName;
    //    private string _museumSubtitle;
    //    private string _todayDate;
    //    private decimal _ticketPrice; 

    //    public string MuseumName
    //    {
    //        get => _museumName;
    //        set
    //        {
    //            _museumName = value;
    //            OnPropertyChanged(nameof(MuseumName));
    //        }
    //    }

    //    public string MuseumSubtitle
    //    {
    //        get => _museumSubtitle;
    //        set
    //        {
    //            _museumSubtitle = value;
    //            OnPropertyChanged(nameof(MuseumSubtitle));
    //        }
    //    }

    //    public string TodayDate
    //    {
    //        get => _todayDate;
    //        set
    //        {
    //            _todayDate = value;
    //            OnPropertyChanged(nameof(TodayDate));
    //        }
    //    }

    //    public decimal TicketPrice
    //    {
    //        get => _ticketPrice;
    //        set
    //        {
    //            _ticketPrice = value;
    //            OnPropertyChanged(nameof(TicketPrice));
    //        }
    //    }
    //}
}
