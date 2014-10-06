using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class LineItemDAL : BaseDAL
    {
        public List<LineItem> GetLineItemsBySource(int sourceId, string sourceType)
        {
            return Db.LineItem.Where(l => l.SourceId == sourceId && l.SourceType == sourceType).ToList();
        }

        public LineItem GetLineItemById(int id)
        {
            return Db.LineItem.SingleOrDefault(l => l.LineItem_Id == id);
        }

        public void AddLineItem(LineItem item)
        {
            Db.LineItem.AddObject(item);
        }

        public void DeleteItem(int itemId)
        {
            var item = Db.LineItem.SingleOrDefault(l=>l.LineItem_Id == itemId);
            Db.LineItem.DeleteObject(item);
            Save();
        }
    }
}
