using System;
using System.Collections.Generic;
using System.Windows;
using WcfService;
using WpfAgroStoreApp.Model;
using WpfAgroStoreApp.ServiceReference1;
using WpfAgroStoreApp.Utilities;

namespace WpfAgroStoreApp.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        #region Public Methods

        public bool DeletePayment(Payment payment)
        {
            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    if (wcf.IsPaymentExist(payment.PaymentID))
                    {
                        MessageBoxResult msgRes = MessageBox.Show(Constants.DeletePayment + payment.PaymentType, Constants.Warning, MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (msgRes == MessageBoxResult.Yes)
                        {
                            wcf.DeletePayment(payment.PaymentID);
                            MessageBox.Show(Constants.PaymentDeleted + payment.PaymentType);

                            return true;
                        }
                    }
                    else
                    {
                        MessageBox.Show(Constants.ChoosePayment);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.ServiceError);
            }
            return false;
        }

        public bool EditPayment(Payment payment)
        {
            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    MessageBoxResult msgRes = MessageBox.Show(Constants.EditPayment + payment.PaymentType.ToString(), Constants.Warning, MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (msgRes == MessageBoxResult.Yes)
                    {
                        wcf.AddPayment(TransformToServiceModel(payment));
                        MessageBox.Show(Constants.PaymentEdited + payment.PaymentType.ToString());

                        return true;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.ServiceError);
            }
            return false;
        }

        public List<Payment> LoadPayments()
        {
            throw new NotImplementedException();
        }

        public Payment StorePayment(Payment payment)
        {
            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    wcf.AddPayment(TransformToServiceModel(payment));

                    return payment;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.ServiceError);
            }
            return null;
        }

        #endregion

        #region Private Methods

        private vwPayment TransformToServiceModel(Payment payment)
        {
            return new vwPayment()
            {
                PaymentID = payment.PaymentID,
                PaymentType = payment.PaymentType
            };
        }

        #endregion
    }
}
