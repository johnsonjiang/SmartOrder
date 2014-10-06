using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class EnquiryDAL : BaseDAL
    {
        public void Delete(int id)
        {
            var enq = GetEnquiryById(id);
            enq.IsActive = false;
            Save();
        }
        public void AddEnquiry(Enquiry enq)
        {
            enq.IsActive = true;
            Db.Enquiry.AddObject(enq);
        }
        public Enquiry GetEnquiryByNo(string no)
        {
            return Db.Enquiry.SingleOrDefault(e => e.Enquiry_No == no);
        }
        public Enquiry GetEnquiryById(int enquiryId)
        {
            return Db.Enquiry.SingleOrDefault(e => e.Enquiry_Id == enquiryId);
        }

        public List<Enquiry> SearchEnquiry(string enqNo,
                                                string companyName,
                                                string customerContactName,
                                                string phone,
                                                DateTime beginDate,
                                                DateTime endDate,
                                                string email,
                                                string status,
                                                string enqMan
                                                 )
        {
            var result = from e in Db.Enquiry
                         where
                            (
                            string.Equals(e.Enquiry_No, enqNo)
                            ||
                            string.IsNullOrEmpty(enqNo)
                            )
                            &&
                            (
                            string.Equals(e.CustomerCompanyName, companyName)
                            ||
                            string.IsNullOrEmpty(companyName)
                            )
                            &&
                            (
                            string.Equals(e.CustomerContactName, customerContactName)
                            || string.IsNullOrEmpty(customerContactName)
                            )
                            &&
                            (
                            string.Equals(e.CustomerEmail, email)
                            || string.IsNullOrEmpty(email)
                            )
                            &&
                            (
                            string.Equals(e.CustomerPhone1, phone)
                            || string.Equals(e.CustomerPhone2, phone)
                            || string.IsNullOrEmpty(phone)
                            )
                            &&
                            (
                            string.Equals(e.Status, status)
                            || string.IsNullOrEmpty(status)
                            )
                            &&
                            (
                            string.Equals(e.EnqMan, enqMan)
                            || string.IsNullOrEmpty(enqMan)
                            )
                            &&
                            (
                            e.CreatedDate >= beginDate
                            )
                            &&
                         (e.CreatedDate <= endDate)
                         &&e.IsActive == true
                         select e;
            return result.ToList();
        }

    }
}
