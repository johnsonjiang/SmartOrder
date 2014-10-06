using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class InstallLookupDAL : BaseDAL
    {
        public void Add(InstallLookup lookup)
        {
            lookup.IsActive = true;
            Db.InstallLookup.AddObject(lookup);
        }

        public List<InstallLookup> GetAllLookup()
        {
            return Db.InstallLookup.Where(l=>l.IsActive==true).ToList();
        }

        public void Delete(int id)
        {
            var lookup = Db.InstallLookup.SingleOrDefault(l => l.Install_Id == id);
            lookup.IsActive = false;
            Save();
        }

        public InstallLookup GetLookupById(int id)
        {
            return Db.InstallLookup.SingleOrDefault(l => l.Install_Id == id);
        }
    }
}
