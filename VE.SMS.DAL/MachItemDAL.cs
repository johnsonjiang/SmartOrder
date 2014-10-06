using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class MachItemDAL : BaseDAL
    {
        public List<MachItem> GetMachItemsByMachId(int machId)
        {
            return Db.MachItem.Where(m => m.Mach_Id == machId).ToList();
        }

        public MachItem GetMachItemById(int id)
        {
            return Db.MachItem.SingleOrDefault(m => m.MI_Id == id);
        }

        public void AddMachItem(MachItem item)
        {
            Db.MachItem.AddObject(item);
        }

        public void DeleteMachItem(int id)
        {
            var machItem = GetMachItemById(id);
            Db.MachItem.DeleteObject(machItem);
            Save();
        }
    }
}
