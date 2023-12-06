using MuseumFusion.Model;

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

    private void OnMakePaymentClicked(object sender, System.EventArgs e)
    {
        if (ValidatePaymentDetails())
        {
            // Save payment details using the PaymentService
            PaymentService.SavePaymentDetails(_paymentDetails);

            // Navigate to a confirmation page or perform other actions as needed
            DisplayAlert("Payment Successful", "Thank you for your purchase!", "OK");
        }
        else
        {
            DisplayAlert("Validation Error", "Please fill in all required fields.", "OK");
        }
    }

    private bool ValidatePaymentDetails()
    {
        // Add your validation logic here
        if (string.IsNullOrWhiteSpace(_paymentDetails.CardNumber) ||
            string.IsNullOrWhiteSpace(_paymentDetails.ExpirationDate) ||
            string.IsNullOrWhiteSpace(_paymentDetails.CVV) ||
            string.IsNullOrWhiteSpace(_paymentDetails.CardHolderName))
        {
            return false; 
        }

        return true; 
    }
}

