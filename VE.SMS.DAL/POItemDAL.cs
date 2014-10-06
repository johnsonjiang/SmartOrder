using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class POItemDAL : BaseDAL
    {
        public void AddPOItem(PurchaseOrderItem item)
        {
            Db.PurchaseOrderItem.AddObject(item);
        }

        public List<PurchaseOrderItem> GetPOItemByPOId(int poId)
        {
            return Db.PurchaseOrderItem.Where(p => p.PO_Id == poId).ToList();
        }

        public PurchaseOrderItem GetPOItemById(int id)
        {
            return Db.PurchaseOrderItem.SingleOrDefault(p => p.PurchaseOrderItem_Id == id);
        }

        public void DeletePOItem(int id)
        {
            var poi = GetPOItemById(id);
            Db.PurchaseOrderItem.DeleteObject(poi);
            Save();
        }
    }
}
