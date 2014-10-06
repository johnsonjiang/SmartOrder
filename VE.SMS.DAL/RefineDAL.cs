using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class RefineDAL:BaseDAL
    {
        public void Delete(int id)
        {
            var refine = GetRefineById(id);
            refine.IsActive = false;
            Save();
        }

        public Refine GetRefineByNo(string no)
        {
            return Db.Refine.SingleOrDefault(r => r.Refine_No == no);
        }

        public Refine GetRefineById(int id)
        {
            return Db.Refine.SingleOrDefault(r=>r.Refine_Id == id);
        }

        public List<Refine> GetRefineByEnq(string enqNo)
        {
            return Db.Refine.Where(r => r.EnqNo == enqNo && r.IsActive ==true).ToList();
        }

        public List<Refine> GetRefineBySource(string sourceType, string sourceNo)
        {
            return Db.Refine.Where(r => r.SourceNo == sourceNo && r.SourceType == sourceType && r.IsActive == true).ToList();
        }
        public void AddRefine(Refine refine)
        {
            refine.IsActive = true;
            Db.Refine.AddObject(refine);
        }

        public List<Refine> SearchRefine(string refNo,
                                        string refMan,
                                        string enqOrdMan,
                                        string status,
                                        DateTime beginDate,
                                        DateTime endDate,
                                        string companyName,
                                        string contact,
                                        string email,
                                        string phone,
                                        string qq
                                        )
        {
            var result = from r in Db.Refine
                         where
                         (
                         string.Equals(r.Refine_No, refNo)
                         ||
                         string.IsNullOrEmpty(refNo)
                         )
                         &&
                         (
                         string.Equals(r.RefineMan, refMan)
                         || string.IsNullOrEmpty(refMan)
                         )
                         &&
                         (
                         string.Equals(r.EnqOrdMan, enqOrdMan)
                         || string.IsNullOrEmpty(enqOrdMan)
                         )
                         &&
                         (
                         string.Equals(r.Status, status)
                         || string.IsNullOrEmpty(status)
                         )
                         &&
                         (
                         string.Equals(r.CustomerCompanyName, companyName)
                         ||
                         string.IsNullOrEmpty(companyName)
                         )
                         &&
                         (
                         string.Equals(r.CustomerContactName, contact)
                         || string.IsNullOrEmpty(contact)
                         )
                         &&
                         (
                         string.Equals(r.CustomerEmail, email)
                         || string.IsNullOrEmpty(email)
                         )
                         &&
                         (
                         string.Equals(r.CustomerPhone1, phone)
                         || string.Equals(r.CustomerPhone2, phone)
                         || string.IsNullOrEmpty(phone)
                         )
                         &&
                         (
                         r.CreatedDate >= beginDate
                         )
                         &&
                         (r.CreatedDate <= endDate)
                         &&
                         r.IsActive == true
                         select r;
            return result.ToList();
        }
    }
}
