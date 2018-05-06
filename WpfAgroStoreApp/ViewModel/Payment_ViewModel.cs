using System.Collections.Generic;
using System.Windows.Input;
using WpfAgroStoreApp.Command;
using WpfAgroStoreApp.Model;
using WpfAgroStoreApp.Services.PaymentService;

namespace WpfAgroStoreApp.ViewModel
{
    class Payment_ViewModel : ViewModelBase
    {
        private List<Payment> _paymentList = new List<Payment>();
        private Payment _payment = new Payment();


        private PaymentService _paymentService;






        public Payment_ViewModel()
        {
            _paymentService = new PaymentService();

            _paymentList = _paymentService.LoadPayments();
        }

        public List<Payment> Payments
        {
            get { return _paymentList; }
        }

        public Payment Payment
        {
            get { return _payment; }
            set
            {
                _payment = value;
                OnPropertyChanged(nameof(Payment));
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
                _paymentService.StorePayment(Payment);
            }

            if (param.ToString().Equals("btn_UpDatePayment"))
            {
                _paymentService.EditPayment(Payment);
            }

            else if (param.ToString().Equals("btn_DeletePayment"))
            {
                _paymentService.DeletePayment(Payment);
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
