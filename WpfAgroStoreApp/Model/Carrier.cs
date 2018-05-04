using System;

namespace WpfAgroStoreApp.Model
{
    public class Carrier
    {
        public Carrier()
        {

        }

        public Carrier(int carrierID, string carrierName, string address)
        {
            CarrierID = carrierID;
            CarrierName = carrierName;
            Address = address;
        }

        public int CarrierID { get; set; }
        public string CarrierName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
    }
}
