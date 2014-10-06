using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class SampleDAL : BaseDAL
    {
        public List<Sample> GetAllSamples()
        {
            return Db.Sample.ToList();
        }

        public Sample GetSampleByCode(string code)
        {
            return Db.Sample.SingleOrDefault(s => s.SampleCode == code);
        }
        public Sample GetSampleById(int id)
        {
            return Db.Sample.SingleOrDefault(s => s.Sample_Id == id);
        }
        public void AddSample(Sample sample)
        {
            Db.Sample.AddObject(sample);
        }
        public List<Sample> SearchSample(string mCode,
            string mName,
            string sampleCode,
            string supplier,
            double priceM,
            double priceM2,
            string color,
            string texure,
            string alias,
            string location)
        {
            var result = from s in Db.Sample
                         where
                         (
                         s.MaterialName == mName
                         ||
                         string.IsNullOrEmpty(mName)
                         )
                         &&
                         (
                         s.MaterialCode == mCode
                         ||
                         string.IsNullOrEmpty(mCode)
                         )
                         &&
                         (
                         s.SampleCode == sampleCode
                         ||
                         string.IsNullOrEmpty(sampleCode)
                         )
                         &&
                         (
                         s.Supplier == supplier
                         ||
                         string.IsNullOrEmpty(supplier)
                         )
                         &&
                         (
                         s.PriceM == priceM
                         ||
                         priceM == -1
                         )
                         &&
                         (
                         s.PriceM2 == priceM2
                         ||
                         priceM2 == -1
                         )
                         &&
                         (
                         s.SampleColor == color
                         ||
                         string.IsNullOrEmpty(color)
                         )
                         &&
                         (
                         s.SampleTexure == texure
                         ||
                         string.IsNullOrEmpty(texure)
                         )
                         &&
                         (
                         s.SampleLocation == location
                         ||
                         string.IsNullOrEmpty(location)
                         )
                         &&
                         (
                         s.Alias1 == alias
                         ||
                         s.Alias2 == alias
                         ||
                         string.IsNullOrEmpty(mName)
                         )
                         select s;
            return result.ToList();
        }
    }
}
