using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class CustomerDrawingDAL : BaseDAL
    {
        public void AddCustomerDrawing(CustomerDrawing cd)
        {
            Db.CustomerDrawing.AddObject(cd);
        }

        public List<CustomerDrawing> GetCustomerDrawingBySource(string sourceType, string sourceNo)
        {
            return Db.CustomerDrawing.Where(cd => cd.SourceType == sourceType && cd.SourceNo == sourceNo).ToList();
        }

        public void DeleteCustomerDrawing(int cdId)
        {
            var item = Db.CustomerDrawing.SingleOrDefault(cd => cd.CustomerDrawing_Id == cdId);
            Db.CustomerDrawing.DeleteObject(item);
            Save();
        }
    }
}
