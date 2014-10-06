using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace VE.SMS.DAL
{
    public class BaseDAL
    {
        private SMSDbEntities db = new SMSDbEntities();

        protected SMSDbEntities Db
        {
            get { return db; }
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
