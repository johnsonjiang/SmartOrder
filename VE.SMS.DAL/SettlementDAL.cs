using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class SettlementDAL:BaseDAL
    {
        public void Delete(int id)
        {
            var st = GetSettlementById(id);
            st.IsActive = false;
            Save();
        }


        public Settlement GetSettlementById(int id)
        {
            return Db.Settlement.SingleOrDefault(s => s.St_Id == id);
        }

        public Settlement GetSettlementByNo(string no)
        {
            return Db.Settlement.SingleOrDefault(s=>s.St_No == no);
        }

        public List<Settlement> GetSettlementByOrderNo(string ordNo)
        {
            return Db.Settlement.Where(s => s.SourceNo == ordNo && s.IsActive == true).ToList();
        }

        public void AddSettlement(Settlement item)
        {
            item.IsActive = true;
            Db.Settlement.AddObject(item);
        }

        public List<Settlement> SearchSettlement(string stno,
            string stMan,
            DateTime beginDate,
            DateTime endDate,
            string ordNo,
            string status)
        {
            var result = from s in Db.Settlement
                         where
                        (
                         s.St_No == stno
                         ||
                         string.IsNullOrEmpty(stno)
                         )
                         &&
                         (
                         s.StMan == stMan
                         ||
                         string.IsNullOrEmpty(stMan)
                         )
                         &&
                         (
                         s.Status == status
                         ||
                         string.IsNullOrEmpty(status)
                         )
                         &&
                         (
                         s.CreatedDate >= beginDate
                         &&
                         s.CreatedDate <= endDate
                         )
                         &&
                         (
                         s.SourceNo == ordNo
                         ||
                         string.IsNullOrEmpty(ordNo)
                         )
                         &&
                         s.IsActive == true

                         select s;
            return result.ToList();
        }
    }
}
