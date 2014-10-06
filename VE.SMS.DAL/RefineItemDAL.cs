using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class RefineItemDAL : BaseDAL
    {
        public void AddRefineItem(RefineItem item)
        {
            Db.RefineItem.AddObject(item);
        }

        public List<RefineItem> GetRefineItemByRefineId(int id)
        {
            return Db.RefineItem.Where(r => r.Refine_Id == id).ToList();
        }
    }
}
