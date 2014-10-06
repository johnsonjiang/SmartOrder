using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class OrderDAL : BaseDAL
    {
        public void Delete(int id)
        {
            var order = GetOrderById(id); ;
            order.IsActive = false;
            Save();
        }

        public void AddOrder(Order order)
        {
            order.IsActive = true;
            Db.Order.AddObject(order);
        }

        public Order GetOrderById(int id)
        {
            return Db.Order.SingleOrDefault(so=>so.Order_Id == id);
        }

        public Order GetOrderByEnq(string enqNo)
        {
            return Db.Order.SingleOrDefault(o => o.EnqNo == enqNo);
        }

        public Order GetOrderByNo(string no)
        {
            return Db.Order.SingleOrDefault(so=>so.Order_No == no);
        }

        public List<Order> SearchOrder(string ordNo,
                                        string ordMan,
                                        string status,
                                        DateTime beginDate,
                                        DateTime endDate,
                                        string companyName,
                                        string contcat,
                                        string phone)
        {
            var result = from o in Db.Order
                         where
                        (
                        o.Order_No == ordNo
                        ||
                        string.IsNullOrEmpty(ordNo)
                        )
                        &&
                        (
                        o.OrderMan == ordMan
                        ||
                        string.IsNullOrEmpty(ordMan)
                        )
                        &&
                        (
                        string.Equals(o.Status, status)
                        ||
                        string.IsNullOrEmpty(status)
                        )
                        &&
                        (
                        o.CreatedDate >= beginDate && o.CreatedDate <= endDate
                        )
                        &&
                        (
                        string.Equals(o.CustomerCompanyName, companyName)
                        ||
                        string.IsNullOrEmpty(companyName)
                        )
                        &&
                        (
                        string.Equals(o.CustomerContactName, contcat)
                        ||
                        string.IsNullOrEmpty(contcat)
                        )
                        &&
                        (
                        string.Equals(o.CustomerPhone1, phone)
                        ||
                        string.Equals(o.CustomerPhone2, phone)
                        ||
                        string.IsNullOrEmpty(phone)
                        )
                        &&
                        o.IsActive == true
                        select o;
            return result.ToList();
        }
    }
}
