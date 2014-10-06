using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class ReceiptDAL : BaseDAL
    {
        public void Add(Receipt r)
        {
            Db.Receipt.AddObject(r);
        }

        public List<Receipt> GetReceiptBySource(string sourceType ,string sourceNo)
        {
            return Db.Receipt.Where(r => r.SourceNo == sourceNo && r.SourceType == sourceType).ToList();
        }

        public Receipt GetReceiptById(int id)
        {
            return Db.Receipt.SingleOrDefault(r => r.Id == id);
        }

        public void Delete(int id)
        {
            var r = GetReceiptById(id);
            Db.Receipt.DeleteObject(r);
            Save();
        }
    }
}
