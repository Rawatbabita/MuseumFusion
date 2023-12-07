using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuseumFusion.Model;
public class PaymentDetail
{
    public string MuseumName { get; set; }
    public string CardNumber { get; set; }
    public string ExpirationDate { get; set; }
    public string CVV { get; set; }
    public string CardHolderName { get; set; }
    public DateTime PaymentDateTime { get; set; }
    public double Price { get; set; }
    public double Tax { get; set; }
    public double TotalAmount { get; set; }
}
