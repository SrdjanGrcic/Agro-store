using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfAgroStoreApp.DataAccess.DBModel
{
    [Table("AgroStore_Carrier")]
    public class DbCarrier
    {
        [Key]
        [Column("carrier_id")]
        public Guid CarrierID { get; set; }

        [Column("carrierName")]
        public string CarrierName { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("notes")]
        public string Notes { get; set; }
    }
}
