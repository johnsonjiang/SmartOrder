using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class MachiningDAL : BaseDAL
    {
        public void Delete(int id)
        {
            var mach = GetMachById(id); ;
            mach.IsActive = false;
            Save();
        }

        public void AddMachining(Machining mach)
        {
            mach.IsActive = true;
            Db.Machining.AddObject(mach);
        }

        public Machining GetMachById(int id)
        {
            return Db.Machining.SingleOrDefault(m => m.Mach_Id == id);
        }
        public Machining GetMachByNo(string no)
        {
            return Db.Machining.SingleOrDefault(m => m.Mach_No == no);
        }

        public List<Machining> GetMachBySource(string sourceType, string sourceNo)
        {
            return Db.Machining.Where(m => m.SourceType == sourceType && m.SourceNo == sourceNo && m.IsActive == true).ToList();
        }

        public List<Machining> SeachMachining(string no,
            string ordNo,
            string machCreateMan,
            string machMan,
            DateTime beginDate,
            DateTime endDate,
            string processCreateMan,
            string status)
        {
            var result = from m in Db.Machining
                         where
                         (
                         m.Mach_No == no
                         ||
                         string.IsNullOrEmpty(no)
                         )
                         &&
                         (
                         m.SourceNo == ordNo
                         ||
                         string.IsNullOrEmpty(ordNo)
                         ) &&
                         (
                         m.MachCreateMan == machCreateMan
                         ||
                         string.IsNullOrEmpty(machCreateMan)
                         ) &&
                         (
                         m.MachMan == machMan
                         ||
                         string.IsNullOrEmpty(machMan)
                         ) &&
                         (
                         m.ProcessCreateMan == processCreateMan
                         ||
                         string.IsNullOrEmpty(processCreateMan)
                         )
                         &&
                         (
                         m.Status == status
                         ||
                         string.IsNullOrEmpty(status)
                         )
                         &&
                         (
                         m.ExpectedCompleteDate >= beginDate && m.ExpectedCompleteDate <= endDate
                         ||
                         !m.ExpectedCompleteDate.HasValue
                         )
                         &&
                         m.IsActive == true
                         select m;
            return result.ToList();
        }
    }
}
