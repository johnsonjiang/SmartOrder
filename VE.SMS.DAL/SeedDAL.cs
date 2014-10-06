using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class SeedDAL : BaseDAL
    {
        public string GetNoByTableName(string tableName, string suffix)
        {
            string todayString= DateTime.Now.ToString("yyyyMMdd");
            var dbRecord = Db.Seed.SingleOrDefault(s => s.TableName == tableName && s.Date == todayString);
            if (dbRecord == null)
            {
                dbRecord = new Seed();
                dbRecord.TableName = tableName;
                dbRecord.CurrentNo = 0;
                dbRecord.Date = todayString;
                Db.Seed.AddObject(dbRecord);
                Db.SaveChanges();
            }
            dbRecord.CurrentNo = dbRecord.CurrentNo + 1;
            Db.SaveChanges();
            string no = dbRecord.CurrentNo.ToString();
            int zeroCount = 2 - no.Length;
            StringBuilder sb = new StringBuilder(16);
            sb.Append(todayString);
            for (int i = 0; i < zeroCount; i++)
            {
                sb.Append("0");
            }
            sb.Append(no);
            sb.Append(suffix);
            return sb.ToString();
        }
    }
}
