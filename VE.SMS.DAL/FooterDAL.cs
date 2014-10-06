using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class FooterDAL : BaseDAL
    {
        public void AddFooter(Footer footer)
        {
            Db.Footer.AddObject(footer);
        }

        public List<Footer> GetFooterBySource(string sourceNo, string sourceType)
        {
            return Db.Footer.Where(f => f.SourceNo == sourceNo && f.SourceType == sourceType).ToList();
        }

        public Footer GetFooterById(int id)
        {
            return Db.Footer.SingleOrDefault(f => f.Id == id);
        }

        public void DeleteFooterItem(int id)
        {
            var footer = Db.Footer.SingleOrDefault(f => f.Id == id);
            Db.Footer.DeleteObject(footer);
            Save();
        }
    }
}
