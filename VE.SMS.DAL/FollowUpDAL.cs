using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class FollowUpDAL:BaseDAL
    {
        public List<FollowUp> GetFollowUpBySource(string sourceType, string sourceNo)
        {
            return Db.FollowUp.Where(f => f.SourceType == sourceType && f.SourceNo == sourceNo).OrderByDescending(f=>f.FollowUp_Date).ToList();
        }

        public List<FollowUp> GetTop3FollowUpBySource(string sourceType, string sourceNo)
        {
            var list = from f in Db.FollowUp
                       orderby f.FollowUp_Date descending
                       where f.SourceNo == sourceNo && f.SourceType == sourceType
                       select f;
            return list.Take(3).ToList();
        }

        public void AddFollowUp(FollowUp followUp)
        {
            Db.FollowUp.AddObject(followUp);
        }
    }
}
