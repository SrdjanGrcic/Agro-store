using System;
using System.Collections.Generic;
using System.Windows.Input;
using WpfAgroStoreApp.Command;
using WpfAgroStoreApp.Model;
using WpfAgroStoreApp.Services.CarrierService;

namespace WpfAgroStoreApp.ViewModel
{
    class Carrier_ViewModel : ViewModelBase
    {
        #region Private Fields

        private List<Carrier> _carrierList;
        private Carrier _carrier;

        private CarrierService _carrierService;

        #endregion

        #region Public Constructors

        public Carrier_ViewModel()
        {
            _carrierList = new List<Carrier>();
            _carrier = new Carrier();
            _carrierService = new CarrierService();

            LoadAllCarriers();
        }

        #endregion

        #region  Public Properties

        public List<Carrier> Carriers
        {
            get { return _carrierList; }
            set
            {
                _carrierList = value;
                OnPropertyChanged(nameof(Carriers));
            }
        }

        public Carrier Carrier
        {
            get { return _carrier; }
            set
            {
                _carrier = value;
                OnPropertyChanged(nameof(Carrier));
            }
        }

        #endregion

        #region Public ComandButtons

        public ICommand Show
        {
            get
            {
                return new RelayCommand(x => Execute(x), x => CanExecute(x));
            }
        }

        #endregion

        #region Private Methods

        private void Execute(object param)
        {
            if (param.ToString().Equals("btn_Add_Carrier"))
            {
                _carrierService.StoreCarrier(Carrier);
            }

            if (param.ToString().Equals("btn_UpDateCarrier"))
            {
                _carrierService.EditCarrier(Carrier);
            }

            else if (param.ToString().Equals("btn_DeleteCarrier"))
            {
                _carrierService.DeleteCarrier(Carrier);
            }
        }

        private void LoadAllCarriers()
        {
            Carriers = _carrierService.LoadCarriers();
        }

        private bool CanExecute(object param)
        {
            if (param.ToString().Equals("btn_Add_Carrier"))
            {
                if (_carrier != null)
                {
                    if (String.IsNullOrEmpty(_carrier.CarrierName) || String.IsNullOrEmpty(_carrier.Address) || String.IsNullOrEmpty(_carrier.Phone))
                    {
                        return false;
                    }
                }
            }
            if (param.ToString().Equals("btn_DeleteCurrier"))
            {
                return Carrier != null ? true : false;
            }

            return true;
        }

        #endregion
    }
}
