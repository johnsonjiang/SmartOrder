using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class MachLookupDAL : BaseDAL
    {
        public void AddMachLookup(MachLookUp mach)
        {
            mach.IsActive = true;
            Db.MachLookUp.AddObject(mach);
        }

        public MachLookUp GetMachLookupById(int id)
        {
            return Db.MachLookUp.SingleOrDefault(m => m.Mach_Id == id);
        }

        public MachLookUp GetMachLookupByName(string name)
        {
            return Db.MachLookUp.SingleOrDefault(m => m.Name == name);
        }

        public void DeleteMachLookup(int id)
        {
            var item = GetMachLookupById(id);
            Db.MachLookUp.DeleteObject(item);
            Save();
        }

        public List<MachLookUp> GetAllMach()
        {
            return Db.MachLookUp.ToList();
        }
    }
}
