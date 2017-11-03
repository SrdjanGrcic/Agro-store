using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here

        //Supplier
        [OperationContract]
        List<vwSupplier> GetAllSuppliers();

        [OperationContract]
        vwSupplier AddSupplier(vwSupplier supplier);

        [OperationContract]
        void DeleteSupplier(int supplierID);

        [OperationContract]
        bool IsSupplierExist(int supplierID);

        //Customer
        [OperationContract]
        List<vwCustomer> GetAllCustomers();

        [OperationContract]
        vwCustomer AddCustomer(vwCustomer customer);

        [OperationContract]
        void DeleteCustomer(int customerID);

        [OperationContract]
        bool IsCustomerExist(int customerID);

        //Category
        [OperationContract]
        List<vwCategory> GetAllCategories();

        [OperationContract]
        vwCategory AddCategory(vwCategory category);

        [OperationContract]
        void DeleteCategory(int categoryID);

        [OperationContract]
        bool IsCategoryExist(int categoryID);

        //Product
        [OperationContract]
        List<vwProduct> GetAllProducts();

        [OperationContract]
        vwProduct AddProduct(vwProduct product);

        [OperationContract]
        void DeleteProduct(int productID);

        [OperationContract]
        bool IsProductExist(int productID);

        //Payment
        [OperationContract]
        List<vwPayment> GetAllPayments();

        [OperationContract]
        vwPayment AddPayment(vwPayment payment);

        [OperationContract]
        void DeletePayment(int paymentID);

        [OperationContract]
        bool IsPaymentExist(int paymentID);

        //Carrier
        [OperationContract]
        List<vwCarrier> GetAllCarriers();

        [OperationContract]
        vwCarrier AddCarrier(vwCarrier carrier);

        [OperationContract]
        void DeleteCarrier(int carrierID);

        [OperationContract]
        bool IsCarrierExist(int carrierID);

        //Order
        [OperationContract]
        List<vwOrder> GetAllOrders();

        [OperationContract]
        vwOrder AddOrder(vwOrder order);

        [OperationContract]
        void DeleteOrder(int orderID);

        [OperationContract]
        bool IsOrderExist(int orderID);

        //OrderDetails
        [OperationContract]
        List<vwOrderDetails> GetAllOrderDetails();

        [OperationContract]
        vwOrderDetails AddOrderDetails(vwOrderDetails orderDetails);

        [OperationContract]
        void DeleteOrderDetails(int orderDetailsID);

        [OperationContract]
        bool IsOrderDetailsExist(int orderDetailsID);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
