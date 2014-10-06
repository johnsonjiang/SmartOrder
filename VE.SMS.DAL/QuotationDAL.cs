using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class QuotationDAL : BaseDAL
    {
        public void Delete(int id)
        {
            var quote = GetQuoteById(id); ;
            quote.IsActive = false;
            Save();
        }

        public void AddQuote(Quotation quote)
        {
            quote.IsActive = true;
            Db.Quotation.AddObject(quote);
        }

        public Quotation GetQuoteById(int id)
        {
            return Db.Quotation.SingleOrDefault(q=>q.Quotation_Id == id);
        }

        public Quotation GetQuoteByNo(string no)
        {
            return Db.Quotation.SingleOrDefault(q=>q.Quotation_No == no);
        }

        public List<Quotation> GetQuoteByEnq(string enqNo)
        {
            return Db.Quotation.Where(q => q.EnqNo == enqNo && q.IsActive == true).ToList();
        }

        public List<Quotation> GetQuotesBySource(string sourceType, string sourceNo)
        {
            return Db.Quotation.Where(q => q.SourceNo == sourceNo && q.SourceType == sourceType && q.IsActive == true).ToList();
        }

        public List<Quotation> SearchQuote(string quono, 
                                            string quoman,
                                            string enqOrdMan ,
                                            string status,
                                            DateTime beginDate,
                                            DateTime endDate,
                                            string companyName,
                                            string contcat,
                                            string email, 
                                            string phone, 
                                            string qq)
        {
            var result = from q in Db.Quotation
                         where 
                            (
                            string.Equals(q.Quotation_No, quono)
                            ||
                            string.IsNullOrEmpty(quono)
                            )
                            &&
                            (
                            string.Equals(q.QuotationMan, quoman)
                            ||
                            string.IsNullOrEmpty(quoman)
                            )
                            &&
                            (
                            string.Equals(q.EnqOrdMan, enqOrdMan)
                            ||
                            string.IsNullOrEmpty(enqOrdMan)
                            )
                            &&
                            (
                            string.Equals(q.Status, status)
                            ||
                            string.IsNullOrEmpty(status)
                            )
                            &&
                            (
                            q.CreatedDate >= beginDate && q.CreatedDate <= endDate
                            )
                            &&
                            (
                            string.Equals(q.CustomerCompanyName, companyName)
                            ||
                            string.IsNullOrEmpty(companyName)
                            )
                                                        &&
                            (
                            string.Equals(q.CustomerContactName, contcat)
                            ||
                            string.IsNullOrEmpty(contcat)
                            )
                            &&
                            (
                            string.Equals(q.CustomerEmail, email)
                            ||
                            string.IsNullOrEmpty(email)
                            )
                            &&
                            (
                            string.Equals(q.CustomerEmail, email)
                            ||
                            string.IsNullOrEmpty(email)
                            )
                            &&
                            (
                            string.Equals(q.CustomerPhone1, phone)
                            ||
                            string.Equals(q.CustomerPhone2, phone)
                            ||
                            string.IsNullOrEmpty(phone)
                            )
                            &&
                            (
                            string.Equals(q.CustomerQQ, qq)
                            ||
                            string.IsNullOrEmpty(qq)
                            )
                            &&
                            q.IsActive == true
            select q;
            return result.ToList();
        }
    }
}
