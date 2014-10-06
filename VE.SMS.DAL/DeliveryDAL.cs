using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class DeliveryDAL : BaseDAL
    {
        public void Delete(int id)
        {
            var del = GetDeliveryById(id); ;
            del.IsActive = false;
            Save();
        }

        public void AddDelivery(Delivery delivery)
        {
            delivery.IsActive = true;
            Db.Delivery.AddObject(delivery);
        }

        public Delivery GetDeliveryById(int id)
        {
            return Db.Delivery.SingleOrDefault(d => d.Delivery_Id == id);
        }

        public Delivery GetDeliveryByNo(string no)
        {
            return Db.Delivery.SingleOrDefault(d=>d.Delivery_No == no);
        }

        public List<Delivery> GetDeliveryByOrderNo(string orderNo)
        {
            return Db.Delivery.Where(d => d.Order_No == orderNo && d.IsActive == true).ToList();
        }

        public List<Delivery> SearchDelivery(
                                            string deliveryNo,
                                            string customerCompanyName,
                                            string contactName,
                                            string phone,
                                            DateTime beginDate,
                                            DateTime endDate,
                                            string deliveryMan,
                                            string installMan,
                                            string status,
                                            string orderNo                                            
                                            )
        {
            var deliverys = from d in Db.Delivery
                            where ( (string.Equals(d.Delivery_No, deliveryNo) || string.IsNullOrEmpty(deliveryNo))
                                    &&
                                    (string.Equals(d.CustomerCompanyName ,deliveryNo) || string.IsNullOrEmpty(customerCompanyName))
                                    &&
                                    (string.Equals(d.CustomerContactName , deliveryNo) || string.IsNullOrEmpty(contactName))
                                    &&
                                    (string.Equals(d.CustomerPhone1 ,deliveryNo )|| string.IsNullOrEmpty(phone))
                                    &&
                                    (d.CreatedDate >= beginDate)
                                    &&
                                    (d.CreatedDate <= endDate)
                                    &&
                                    (string.Equals(d.DeliveryDriverMan ,deliveryMan )|| string.IsNullOrEmpty(deliveryMan))
                                    &&
                                    (string.Equals(d.InstallMan ,installMan )|| string.IsNullOrEmpty(installMan))
                                    &&
                                    (string.Equals(d.Status ,status )|| string.IsNullOrEmpty(status))
                                    &&
                                    (d.Order_No.Contains(orderNo) || string.IsNullOrEmpty(orderNo))
                                  )
                                  &&
                                  d.IsActive == true
                            select d;
            return deliverys.ToList();
        }
    }
}
