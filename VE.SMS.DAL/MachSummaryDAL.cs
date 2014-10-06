using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class MachSummaryDAL : BaseDAL
    {
        public void AddMachSummary(MachSummary summary)
        {
            Db.MachSummary.AddObject(summary);
        }

        public List<MachSummary> GetSummaryByMachId(int id)
        {
            return Db.MachSummary.Where(m => m.MachId == id).ToList();
        }

        public MachSummary GetSummaryById(int id)
        {
            return Db.MachSummary.SingleOrDefault(m => m.Id == id);
        }
        public void DeleteSummary(int id)
        {
            var summary = GetSummaryById(id);
            Db.MachSummary.DeleteObject(summary);
            Save();
        }
    }
}
