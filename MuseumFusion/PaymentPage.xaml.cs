using MuseumFusion.Model;
using System.Globalization;

namespace MuseumFusion;

public partial class PaymentPage : ContentPage
{
    private PaymentDetail _paymentDetails;

    public PaymentPage(Museum selectedMuseum)
    {
        InitializeComponent();

        _paymentDetails = new PaymentDetail();
        _paymentDetails.MuseumName = selectedMuseum.Name;
        _paymentDetails.Price = (Double)selectedMuseum.Price;
        _paymentDetails.Tax = _paymentDetails.Price * 0.2;
        _paymentDetails.TotalAmount = _paymentDetails.Price + _paymentDetails.Tax;
        _paymentDetails.PaymentDateTime = DateTime.Now;

        BindingContext = _paymentDetails;
    }

    private async void OnMakePaymentClicked(object sender, System.EventArgs e)
    {
        if (ValidatePaymentDetails())
        {


            //Save payment details using the PaymentService
            PaymentService.SavePaymentDetails(_paymentDetails);

            // Navigate to a confirmation page or perform other actions as needed
            await DisplayAlert("Payment Successful", "Thank you for your purchase!", "OK");
            await Navigation.PushAsync(new CongratulationsPage());
        }
        else
        {
            await DisplayAlert("Validation Error", "Please fill in all required fields.", "OK");
        }
    }

    private bool ValidatePaymentDetails()
    {
        // Check if CardNumber is numeric
        if (!IsNumeric(_paymentDetails.CardNumber))
            return false;

        // Check if ExpirationDate is in date format
        if (!IsDateFormat(_paymentDetails.ExpirationDate))
            return false;

        // Check if CVV is numeric and only 3 digits
        if (!IsNumeric(_paymentDetails.CVV) || _paymentDetails.CVV.Length != 3)
            return false;

        // Check if CardHolderName contains only alphabets
        if (!IsAlpha(_paymentDetails.CardHolderName))
            return false;

        return true;
    }

    // Helper method to check if a string is numeric
    private bool IsNumeric(string input)
    {
        return double.TryParse(input, out _);
    }

    // Helper method to check if a string is in date format (MM/YYYY)
    private bool IsDateFormat(string input)
    {
        return DateTime.TryParseExact(input, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
    }

    // Helper method to check if a string contains only alphabets
    private bool IsAlpha(string input)
    {
        return input.All(char.IsLetter);
    }

}

