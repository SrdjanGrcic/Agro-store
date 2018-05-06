using System;

namespace WpfAgroStoreApp.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int PaymentID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public bool Paid { get; set; }
        public DateTime? PaidDate { get; set; }
        public int CarrierID { get; set; }
        public int Expr1 { get; set; }
        public int Expr2 { get; set; }
        public int Expr3 { get; set; }
    }
}
