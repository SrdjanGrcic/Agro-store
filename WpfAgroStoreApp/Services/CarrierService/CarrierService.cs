using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WcfService;
using WpfAgroStoreApp.Model;
using WpfAgroStoreApp.ServiceReference1;
using WpfAgroStoreApp.Utilities;

namespace WpfAgroStoreApp.Services.CarrierService
{
    public class CarrierService : ICarrierService
    {
        public bool EditCarrier(Carrier carrier)
        {
            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    MessageBoxResult msgRes = MessageBox.Show(Constants.EditCarrier + carrier.CarrierName, Constants.Warning, MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (msgRes == MessageBoxResult.Yes)
                    {
                        wcf.AddCarrier(TransformToServiceModel(carrier));
                        MessageBox.Show(Constants.CarrierEdited + carrier.CarrierName);

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

        public List<Carrier> LoadCarriers()
        {
            List<vwCarrier> _carrierList = new List<vwCarrier>();

            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    return ServiceModelToDomainModel(wcf.GetAllCarriers().ToList());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Constants.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }

        public Carrier StoreCarrier(Carrier carrier)
        {
            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    wcf.AddCarrier(TransformToServiceModel(carrier));

                    return carrier;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.ServiceError);
                return null;
            }
        }

        public bool DeleteCarrier(Carrier carrier)
        {
            try
            {
                using (Service1Client wcf = new Service1Client())
                {
                    if (wcf.IsCarrierExist(carrier.CarrierID))
                    {
                        MessageBoxResult msgRes = MessageBox.Show(Constants.DeleteCarrier + carrier.CarrierName, Constants.Warning, MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (msgRes == MessageBoxResult.Yes)
                        {
                            wcf.DeleteCarrier(carrier.CarrierID);
                            MessageBox.Show(Constants.CarrierDeleted + carrier.CarrierName);

                            return true;
                        }
                    }
                    else
                    {
                        MessageBox.Show(Constants.ChooseCarrier);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.ServiceError);
            }
            return false;
        }

        private vwCarrier TransformToServiceModel(Carrier carrier)
        {
            return new vwCarrier()
            {
                CarrierID = carrier.CarrierID,
                CarrierName = carrier.CarrierName,
                Address = carrier.Address
            };
        }

        private List<Carrier> ServiceModelToDomainModel(List<vwCarrier> carriers)
        {
            List<Carrier> _carrierList = new List<Carrier>();

            foreach (var item in carriers)
            {
                _carrierList.Add(new Carrier(item.CarrierID, item.CarrierName, item.Address));
            }
            return _carrierList;
        }
    }
}
