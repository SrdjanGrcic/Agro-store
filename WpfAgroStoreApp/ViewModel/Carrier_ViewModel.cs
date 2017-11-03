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
    class Carrier_ViewModel : ViewModelBase
    {
        List<vwCarrier> carrierList = new List<vwCarrier>();
        vwCarrier carrier = new vwCarrier();

        public Carrier_ViewModel()
        {
            Refresh();
        }

        private void Refresh()
        {
            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    carrierList = wcf.GetAllCarriers().ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            carrier = carrier ?? new vwCarrier();
        }

        public List<vwCarrier> Carriers
        {
            get { return carrierList; }
        }

        public vwCarrier Carrier
        {
            get { return carrier; }
            set
            {
                carrier = value;
                OnPropertyChanged("Carrier");
            }
        }

        #region IComandButtons

        public ICommand Show
        {
            get
            {
                return new RelayCommand(x => Execute(x), x => CanExecute(x));
            }
        }

        private void Execute(object param)
        {
            if (param.ToString().Equals("btn_Add_Carrier"))
            {
                try
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        wcf.AddCarrier(carrier);
                        Refresh();
                        OnPropertyChanged("Carriers");
                        MessageBox.Show("Dodat je prevoznik.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }

            if (param.ToString().Equals("btn_UpDateCarrier"))
            {
                try
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        MessageBoxResult msgRes = MessageBox.Show("Da li zelite da izmenite prevoznika: " + carrier.CarrierName.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (msgRes == MessageBoxResult.Yes)
                        {
                            wcf.AddCarrier(carrier);
                            MessageBox.Show("Izmenjen je prevoznik: " + carrier.CarrierName.ToString());
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }

            else if (param.ToString().Equals("btn_DeleteCarrier"))
            {
                try
                {
                    using (Service1Client wcf = new Service1Client())
                    {
                        int carID = (int)carrier.CarrierID;
                        bool isCarrierExist = wcf.IsCarrierExist(carID);
                        if (isCarrierExist)
                        {
                            MessageBoxResult msgRes = MessageBox.Show("Da li zelite da obrisete prevoznika: " + carrier.CarrierName.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            if (msgRes == MessageBoxResult.Yes)
                            {
                                vwCarrier CarrierForDeletion = carrier;
                                wcf.DeleteCarrier(carID);
                                Refresh();
                                OnPropertyChanged("Carriers");
                                MessageBox.Show("Obrisan je prevoznik: " + CarrierForDeletion.CarrierName.ToString());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Izaberite prevoznika za brisanje.");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Brisanje nije uspelo.");
                }
            }
        }

        private bool CanExecute(object param)
        {
            if (param.ToString().Equals("btn_Add_Carrier"))
            {
                if (carrier != null)
                {
                    if (String.IsNullOrEmpty(carrier.CarrierName) || String.IsNullOrEmpty(carrier.Address) || String.IsNullOrEmpty(carrier.Phone))
                    {
                        return false;
                    }
                }
            }
            if (param.ToString().Equals("btn_DeleteCurrier"))
            {
                //if (String.IsNullOrEmpty(carrier.CarrierName))
                //{
                //    return false;
                //}
            }
            return true;
        }

        #endregion
    }
}
