using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WcfService;
using WpfAgroStoreApp.Command;
using WpfAgroStoreApp.ServiceReference1;


namespace WpfAgroStoreApp.ViewModel
{
    class Payment_ViewModel : ViewModelBase
    {
        private List<vwPayment> paymentList = new List<vwPayment>();

        private vwPayment payment = new vwPayment();

        public Payment_ViewModel()
        {
            using (Service1Client wcf = new Service1Client())
            {
                paymentList = wcf.GetAllPayments().ToList();
            }
        }

        public List<vwPayment> Payments
        {
            get { return paymentList; }
        }

        public vwPayment Payment
        {
            get { return payment; }
            set
            {
                payment = value;
                OnPropertyChanged("Payment");
            }
        }

        public ICommand Show
        {
            get
            {
                return new RelayCommand(x => Execute(x), x => CanExecute(x));
            }
        }

        private void Execute(object param)
        {
            if (param.ToString().Equals("btn_Add_Payment"))
            {
                try
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        wcf.AddPayment(payment);
                        MessageBox.Show("Dodat je nacin placanja.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }

            if (param.ToString().Equals("btn_UpDatePayment"))
            {
                try
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        MessageBoxResult msgRes = MessageBox.Show("Da li zelite da izmenite naziv za izabrani nacin placanja: " + payment.PaymentType.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (msgRes == MessageBoxResult.Yes)
                        {
                            wcf.AddPayment(payment);
                            MessageBox.Show("Izmenjen je nacin placanja: " + payment.PaymentType.ToString());
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }

            else if (param.ToString().Equals("btn_DeletePayment"))
            {
                try
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        int paymID = (int)payment.PaymentID;
                        bool isPaymentExist = wcf.IsPaymentExist(paymID);
                        if (isPaymentExist)
                        {
                            MessageBoxResult msgRes = MessageBox.Show("Da li zelite da obrisete izabrani nacin placanja: " + payment.PaymentType.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            if (msgRes == MessageBoxResult.Yes)
                            {
                                wcf.DeletePayment(paymID);
                                MessageBox.Show("Obrisan je nacin placanja: " + payment.PaymentType.ToString());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Izaberite nacin placanja za brisanje.");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Izaberite nacin placanja za brisanje.");
                }
            }
        }

        private bool CanExecute(object param)
        {
            if (param.ToString().Equals("btn_Add_Payment"))
            {
                //if (String.IsNullOrEmpty(supplier.SupplierName) || String.IsNullOrEmpty(supplier.Address) || String.IsNullOrEmpty(supplier.City) || String.IsNullOrEmpty(supplier.Phone))
                //{
                //    return false;
                //}
            }
            return true;
        }
    }
}
