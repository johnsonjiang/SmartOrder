using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class SampleProvidDAL : BaseDAL
    {
        public List<SampleProvid> GetSampleBySource(string sourceType, string sourceNo)
        {
            return Db.SampleProvid.Where(s => s.SourceType == sourceType && s.SourceNo == sourceNo).ToList();
        }

        public void AddSample(SampleProvid sample)
        {
            Db.SampleProvid.AddObject(sample);
        }
    }
}
