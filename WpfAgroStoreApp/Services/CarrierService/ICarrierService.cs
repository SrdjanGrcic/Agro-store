using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAgroStoreApp.Model;

namespace WpfAgroStoreApp.Services.CarrierService
{
    public interface ICarrierService
    {
        List<Carrier> LoadCarriers();
        Carrier StoreCarrier(Carrier carrier);
        bool EditCarrier(Carrier carrier);
        bool DeleteCarrier(Carrier carrier);
    }
}
