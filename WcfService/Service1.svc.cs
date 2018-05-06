using System;
using System.Collections.Generic;
using System.Linq;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}


        //Supplier
        #region Supplier

        List<vwSupplier> IService1.GetAllSuppliers()
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    List<vwSupplier> list = new List<vwSupplier>();

                    list = (from x in context.vwSupplier select x).ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public vwSupplier AddSupplier(vwSupplier supplier)
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    if (supplier.SupplierID == 0)
                    {
                        tblSupplier newSupplier = new tblSupplier()
                        {
                            SupplierID = supplier.SupplierID,
                            SupplierName = supplier.SupplierName,
                            Address = supplier.Address,
                            City = supplier.City,
                            Phone = supplier.Phone,
                            Email = supplier.Email,
                            Notes = supplier.Notes
                        };
                        context.tblSupplier.Add(newSupplier);

                        context.SaveChanges();
                        supplier.SupplierID = newSupplier.SupplierID;

                        return supplier;
                    }
                    else
                    {
                        tblSupplier supplierToEdit = (from s in context.tblSupplier where s.SupplierID == supplier.SupplierID select s).First();
                        supplierToEdit.SupplierID = supplier.SupplierID;
                        supplierToEdit.SupplierName = supplier.SupplierName;
                        supplierToEdit.Address = supplier.Address;
                        supplierToEdit.City = supplier.City;
                        supplierToEdit.Phone = supplier.Phone;
                        supplierToEdit.Email = supplier.Email;
                        supplierToEdit.Notes = supplier.Notes;

                        context.SaveChanges();

                        return supplier;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }

        public void DeleteSupplier(int supplierID)
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    tblSupplier supplierToDelete = (from s in context.tblSupplier where s.SupplierID == supplierID select s).First();
                    context.tblSupplier.Remove(supplierToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        public bool IsSupplierExist(int supplierID)
        {
            try
            {
                int supplier;
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    supplier = (from s in context.vwSupplier where s.SupplierID == supplierID select s.SupplierID).FirstOrDefault();

                }
                if (supplier != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        #endregion

        //Customer
        #region Customer
        public List<vwCustomer> GetAllCustomers()
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    List<vwCustomer> customerList = new List<vwCustomer>();

                    customerList = (from c in context.vwCustomer select c).ToList();

                    return customerList;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public vwCustomer AddCustomer(vwCustomer customer)
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    if (customer.CustomerID == 0)
                    {
                        tblCustomer newCustomer = new tblCustomer()
                        {
                            CustomerID = customer.CustomerID,
                            CustomerName = customer.CustomerName,
                            Address = customer.Address,
                            City = customer.City,
                            Phone = customer.Phone
                        };
                        context.tblCustomer.Add(newCustomer);

                        context.SaveChanges();
                        customer.CustomerID = newCustomer.CustomerID;

                        return customer;
                    }
                    else
                    {
                        tblCustomer customerToEdit = (from c in context.tblCustomer where c.CustomerID == customer.CustomerID select c).First();
                        customerToEdit.CustomerID = customer.CustomerID;
                        customerToEdit.CustomerName = customer.CustomerName;
                        customerToEdit.Address = customer.Address;
                        customerToEdit.City = customer.City;
                        customerToEdit.Phone = customer.Phone;

                        context.SaveChanges();

                        return customer;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }

        public void DeleteCustomer(int customerID)
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    tblCustomer customerToDelete = (from c in context.tblCustomer where c.CustomerID == customerID select c).First();
                    context.tblCustomer.Remove(customerToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        public bool IsCustomerExist(int customerID)
        {
            try
            {
                int customer;
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    customer = (from c in context.tblCustomer where c.CustomerID == customerID select c.CustomerID).FirstOrDefault();

                }
                if (customer != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
        #endregion

        //Product
        #region Product

        public List<vwProduct> GetAllProducts()
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    List<vwProduct> productList = new List<vwProduct>();

                    productList = (from x in context.vwProduct select x).ToList();

                    return productList;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public vwProduct AddProduct(vwProduct product)
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    if (product.ProductID == 0)
                    {
                        tblProduct newProduct = new tblProduct()
                        {
                            ProductID = product.ProductID,
                            ProductName = product.ProductName,
                            Price = product.Price,
                            ProductDesc = product.ProductDesc,
                            SupplierID = product.SupplierID,
                            CategoryID = product.CategoryID
                        };
                        context.tblProduct.Add(newProduct);

                        context.SaveChanges();
                        product.ProductID = newProduct.ProductID;

                        return product;
                    }
                    else
                    {
                        tblProduct productToEdit = (from p in context.tblProduct where p.ProductID == product.ProductID select p).First();
                        productToEdit.ProductID = product.ProductID;
                        productToEdit.ProductName = product.ProductName;
                        productToEdit.Price = product.Price;
                        productToEdit.ProductDesc = product.ProductDesc;
                        productToEdit.SupplierID = product.SupplierID;
                        productToEdit.CategoryID = product.CategoryID;

                        context.SaveChanges();

                        return product;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }

        public void DeleteProduct(int productID)
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    tblProduct productToDelete = (from p in context.tblProduct where p.ProductID == productID select p).First();
                    context.tblProduct.Remove(productToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        public bool IsProductExist(int productID)
        {
            try
            {
                int product;
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    product = (from p in context.tblProduct where p.ProductID == productID select p.ProductID).FirstOrDefault();

                }
                if (product != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        #endregion

        //Category
        #region Category
        public List<vwCategory> GetAllCategories()
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    List<vwCategory> categoryList = new List<vwCategory>();

                    categoryList = (from c in context.vwCategory select c).ToList();

                    return categoryList;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public vwCategory AddCategory(vwCategory category)
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    if (category.CategoryID == 0)
                    {
                        tblCategory newCategory = new tblCategory()
                        {
                            CategoryID = category.CategoryID,
                            CategoryName = category.CategoryName,
                            CategoryDesc = category.CategoryDesc
                        };
                        context.tblCategory.Add(newCategory);

                        context.SaveChanges();
                        category.CategoryID = newCategory.CategoryID;

                        return category;
                    }
                    else
                    {
                        tblCategory categoryToEdit = (from c in context.tblCategory where c.CategoryID == category.CategoryID select c).First();
                        categoryToEdit.CategoryID = category.CategoryID;
                        categoryToEdit.CategoryName = category.CategoryName;
                        categoryToEdit.CategoryDesc = category.CategoryDesc;

                        context.SaveChanges();

                        return category;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }

        public void DeleteCategory(int categoryID)
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    tblCategory categoryToDelete = (from c in context.tblCategory where c.CategoryID == categoryID select c).First();
                    context.tblCategory.Remove(categoryToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        public bool IsCategoryExist(int categoryID)
        {
            try
            {
                int category;
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    category = (from c in context.tblCategory where c.CategoryID == categoryID select c.CategoryID).FirstOrDefault();

                }
                if (category != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }
        #endregion

        //Payment
        #region Payment

        public List<vwPayment> GetAllPayments()
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    List<vwPayment> paymentList = new List<vwPayment>();

                    paymentList = (from p in context.vwPayment select p).ToList();

                    return paymentList;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public vwPayment AddPayment(vwPayment payment)
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    if (payment.PaymentID == 0)
                    {
                        tblPayment newPayment = new tblPayment()
                        {
                            PaymentID = payment.PaymentID,
                            PaymentType = payment.PaymentType
                        };
                        context.tblPayment.Add(newPayment);

                        context.SaveChanges();
                        payment.PaymentID = newPayment.PaymentID;

                        return payment;
                    }
                    else
                    {
                        tblPayment paymentToEdit = (from p in context.tblPayment where p.PaymentID == payment.PaymentID select p).First();
                        paymentToEdit.PaymentID = payment.PaymentID;
                        paymentToEdit.PaymentType = payment.PaymentType;

                        context.SaveChanges();

                        return payment;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }

        public void DeletePayment(int paymentID)
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    tblPayment paymentToDelete = (from p in context.tblPayment where p.PaymentID == paymentID select p).First();
                    context.tblPayment.Remove(paymentToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        public bool IsPaymentExist(int paymentID)
        {
            try
            {
                int payment;
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    payment = (from p in context.tblPayment where p.PaymentID == paymentID select p.PaymentID).FirstOrDefault();

                }
                if (payment != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        #endregion

        //Carrier
        #region Carrier

        public List<vwCarrier> GetAllCarriers()
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    List<vwCarrier> list = new List<vwCarrier>();

                    list = (from c in context.vwCarrier select c).ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public vwCarrier AddCarrier(vwCarrier carrier)
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    if (carrier.CarrierID == 0)
                    {
                        tblCarrier newCarrier = new tblCarrier()
                        {
                            CarrierID = carrier.CarrierID,
                            CarrierName = carrier.CarrierName,
                            Address = carrier.Address,
                            City = carrier.City,
                            Phone = carrier.Phone,
                            Email = carrier.Email,
                            Notes = carrier.Notes
                        };
                        context.tblCarrier.Add(newCarrier);

                        context.SaveChanges();
                        carrier.CarrierID = newCarrier.CarrierID;

                        return carrier;
                    }
                    else
                    {
                        tblCarrier carrierToEdit = (from c in context.tblCarrier where c.CarrierID == carrier.CarrierID select c).First();
                        carrierToEdit.CarrierID = carrier.CarrierID;
                        carrierToEdit.CarrierName = carrier.CarrierName;
                        carrierToEdit.Address = carrier.Address;
                        carrierToEdit.City = carrier.City;
                        carrierToEdit.Phone = carrier.Phone;
                        carrierToEdit.Email = carrier.Email;
                        carrierToEdit.Notes = carrier.Notes;

                        context.SaveChanges();

                        return carrier;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }

        public void DeleteCarrier(int carrierID)
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    tblCarrier carrierToDelete = (from c in context.tblCarrier where c.CarrierID == carrierID select c).First();
                    context.tblCarrier.Remove(carrierToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        public bool IsCarrierExist(int carrierID)
        {
            try
            {
                int carrier;
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    carrier = (from c in context.vwCarrier where c.CarrierID == carrierID select c.CarrierID).FirstOrDefault();

                }
                if (carrier != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        #endregion

        //Order
        #region Order

        public List<vwOrder> GetAllOrders()
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    List<vwOrder> orderList = new List<vwOrder>();

                    orderList = (from o in context.vwOrder select o).ToList();

                    return orderList;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public vwOrder AddOrder(vwOrder order)
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    if (order.OrderID == 0)
                    {
                        tblOrder newOrder = new tblOrder()
                        {
                            //newOrder.OrderID = order.OrderID;     // Don't need this line, OrderID is 0(will get its value later)
                            CustomerID = order.CustomerID,
                            CarrierID = order.CarrierID,
                            PaymentID = order.PaymentID,
                            OrderDate = (DateTime)order.OrderDate,
                            ShipDate = (DateTime)order.ShipDate,
                            PaidDate = (DateTime)order.PaidDate,
                            Paid = order.Paid
                        };
                        context.tblOrder.Add(newOrder);
                        context.SaveChanges();
                        order.OrderID = newOrder.OrderID;

                        return order;
                    }
                    else
                    {
                        tblOrder orderToEdit = (from o in context.tblOrder where o.OrderID == order.OrderID select o).First();
                        orderToEdit.OrderID = order.OrderID;
                        orderToEdit.CustomerID = order.CustomerID;
                        orderToEdit.CarrierID = order.CarrierID;
                        orderToEdit.PaymentID = order.PaymentID;
                        orderToEdit.OrderDate = (DateTime)order.OrderDate;
                        orderToEdit.ShipDate = (DateTime)order.ShipDate;
                        orderToEdit.PaidDate = (DateTime)order.PaidDate;
                        orderToEdit.Paid = order.Paid;

                        context.SaveChanges();

                        return order;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }

        public void DeleteOrder(int orderID)
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    tblOrder orderToDelete = (from o in context.tblOrder where o.OrderID == orderID select o).First();
                    context.tblOrder.Remove(orderToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        public bool IsOrderExist(int orderID)
        {
            try
            {
                int order;
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    order = (from o in context.vwOrder where o.OrderID == orderID select o.OrderID).FirstOrDefault();

                }
                if (order != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        #endregion

        //OrderDetails
        #region OrderDetails

        public List<vwOrderDetails> GetAllOrderDetails()
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    List<vwOrderDetails> orderDetailsList = new List<vwOrderDetails>();

                    orderDetailsList = (from od in context.vwOrderDetails select od).ToList();

                    return orderDetailsList;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message.ToString());
                return null;
            }
        }

        public vwOrderDetails AddOrderDetails(vwOrderDetails orderDetails)
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    if (orderDetails.OrderDetailsID == 0)
                    {
                        vwOrderDetails newOrderDetails = new vwOrderDetails()
                        {
                            OrderDetailsID = orderDetails.OrderDetailsID,
                            OrderID = orderDetails.OrderID,
                            ProductID = orderDetails.ProductID,
                            Quantity = orderDetails.Quantity,
                            TotalAmount = orderDetails.TotalAmount,
                            Discount = orderDetails.Discount
                        };
                        context.vwOrderDetails.Add(newOrderDetails);

                        context.SaveChanges();
                        orderDetails.OrderDetailsID = newOrderDetails.OrderDetailsID;

                        return orderDetails;
                    }
                    else
                    {
                        vwOrderDetails orderDetailsToEdit = (from od in context.vwOrderDetails where od.OrderDetailsID == orderDetails.OrderDetailsID select od).First();
                        orderDetailsToEdit.OrderDetailsID = orderDetails.OrderDetailsID;
                        orderDetailsToEdit.OrderID = orderDetails.OrderID;
                        orderDetailsToEdit.ProductID = orderDetails.ProductID;
                        orderDetailsToEdit.Quantity = orderDetails.Quantity;
                        orderDetailsToEdit.TotalAmount = orderDetails.TotalAmount;
                        orderDetailsToEdit.Discount = orderDetails.Discount;

                        context.SaveChanges();

                        return orderDetails;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }

        public void DeleteOrderDetails(int orderDetailsID)
        {
            try
            {
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    vwOrderDetails orderDetailsToDelete = (from od in context.vwOrderDetails where od.OrderDetailsID == orderDetailsID select od).First();
                    context.vwOrderDetails.Remove(orderDetailsToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        public bool IsOrderDetailsExist(int orderDetailsID)
        {
            try
            {
                int orderDetails;
                using (AgroStoreEntities1 context = new AgroStoreEntities1())
                {
                    orderDetails = (from od in context.vwOrderDetails where od.OrderDetailsID == orderDetailsID select od.OrderDetailsID).FirstOrDefault();

                }
                if (orderDetails != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        #endregion
    }
}
