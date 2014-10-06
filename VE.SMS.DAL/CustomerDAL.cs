using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class CustomerDAL : BaseDAL
    {
        public void AddCustomer(Customer customer)
        {
            Db.Customer.AddObject(customer);
        }

        public List<Customer> GetAllCustomer()
        {
            return Db.Customer.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return Db.Customer.SingleOrDefault(c => c.Customer_Id == id);
        }

        public void DeleteCustomer(int customerId)
        {
            var dbCustomer = Db.Customer.SingleOrDefault(c => c.Customer_Id == customerId);
            Db.Customer.DeleteObject(dbCustomer);
            Save();
        }
    }
}
