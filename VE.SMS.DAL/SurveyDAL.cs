using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class SurveyDAL : BaseDAL
    {
        public void Delete(int id)
        {
            var survey = GetSurveyById(id); 
            survey.IsActive = false;
            Save();
        }

        public void AddSurvey(Survey survey)
        {
            survey.IsActive = true;
            Db.Survey.AddObject(survey);
        }

        public Survey GetSurveyByNo(string no)
        {
            return Db.Survey.SingleOrDefault(s=>s.SourceNo == no);
        }

        public Survey GetSurveyById(int id)
        {
            return Db.Survey.SingleOrDefault(s=>s.Survey_Id == id);
        }

        public List<Survey> GetSurveyByEnq(string enqNo)
        {
            return Db.Survey.Where(s => s.EnqNo == enqNo && s.IsActive == true).ToList();
        }

        public List<Survey> GetSurveyBySource(string sourceNo, string sourceType)
        {
            return Db.Survey.Where(s => s.SourceNo == sourceNo && s.SourceType == sourceType && s.IsActive == true).ToList();
        }
        public List<Survey> SearchSurvey(
            string svNo,
            string svMan,
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
            var result = from s in Db.Survey
                         where
                         (
                         s.SourceNo == svNo
                         ||
                         string.IsNullOrEmpty(svNo)
                         )
                         &&
                         (
                         s.SurveyMan == svMan
                         ||
                         string.IsNullOrEmpty(svMan)
                         )
                         &&
                         (
                         s.EnqOrdMan== enqOrdMan
                         ||
                         string.IsNullOrEmpty(enqOrdMan)
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
                        string.Equals(s.CustomerCompanyName, companyName)
                        ||
                        string.IsNullOrEmpty(companyName)
                        )
                        &&
                        (
                        string.Equals(s.CustomerContactName, contact)
                        || string.IsNullOrEmpty(contact)
                        )
                        &&
                        (
                        string.Equals(s.CustomerEmail, email)
                        || string.IsNullOrEmpty(email)
                        )
                        &&
                        (
                        string.Equals(s.CustomerPhone1, phone)
                        || string.Equals(s.CustomerPhone2, phone)
                        || string.IsNullOrEmpty(phone)
                        )
                        &&
                        (
                        string.Equals(s.CustomerQQ, qq)
                        || string.IsNullOrEmpty(qq)
                        )
                        &&
                        s.IsActive == true
                         select s;
            return result.ToList();
        }
    }
}
