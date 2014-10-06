using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class DeliveryItemDAL:BaseDAL
    {
        public List<DeliveryItem> GetDeliveryItemsByDelId(int id)
        {
            return Db.DeliveryItem.Where(di => di.Delivery_Id == id).ToList();
        }

        public void DeleteDeliveryItem(int diId)
        { 
            var dbDi = Db.DeliveryItem.SingleOrDefault(di=>di.DeliveryItem_Id == diId);
            Db.DeliveryItem.DeleteObject(dbDi);
        }

        public void UpdateDeliveryItem(DeliveryItem item)
        {
            var dbDi = Db.DeliveryItem.SingleOrDefault(di => di.DeliveryItem_Id == item.DeliveryItem_Id);
            dbDi.Intro = item.Intro;
            dbDi.Name = item.Name;
            dbDi.Project = item.Project;
            dbDi.Quantity = item.Quantity;
            dbDi.Remark = item.Remark;
            dbDi.Spec = item.Spec;
            dbDi.Unit = item.Unit;
            dbDi.UnitPrice = item.UnitPrice;
        }


    }
}
