//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfService
{
    using System;
    using System.Collections.Generic;
    
    public partial class vwOrder
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int PaymentID { get; set; }
        public System.DateTime? OrderDate { get; set; }
        public System.DateTime? ShipDate { get; set; }
        public bool Paid { get; set; }
        public System.DateTime? PaidDate { get; set; }
        public int CarrierID { get; set; }
        public int Expr1 { get; set; }
        public int Expr2 { get; set; }
        public int Expr3 { get; set; }
    }
}