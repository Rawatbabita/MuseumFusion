using MuseumFusion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumFusion;

public class PaymentService
{
    private static PaymentDetail _currentPaymentDetails;

    public static PaymentDetail CurrentPaymentDetails
    {
        get
        {
            if (_currentPaymentDetails == null)
            {
                // You might want to initialize it or load from a storage if needed
                _currentPaymentDetails = new PaymentDetail();
            }

            return _currentPaymentDetails;
        }
        set
        {
            _currentPaymentDetails = value;
        }
    }

    public static void SavePaymentDetails(PaymentDetail paymentDetails)
    {
        // You might want to implement saving to a database or secure storage
        CurrentPaymentDetails = paymentDetails;
    }
}

