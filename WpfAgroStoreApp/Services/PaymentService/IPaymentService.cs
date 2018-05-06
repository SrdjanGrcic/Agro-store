using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAgroStoreApp.Model;

namespace WpfAgroStoreApp.Services.PaymentService
{
    public interface IPaymentService
    {
        List<Payment> LoadPayments();
        Payment StorePayment(Payment payment);
        bool EditPayment(Payment payment);
        bool DeletePayment(Payment payment);
    }
}
