using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class EndProductDAL : BaseDAL
    {
        public void AddEndProduct(EndProduct ep)
        {
            Db.EndProduct.AddObject(ep);
        }

        public bool Exists(string code, int id)
        {
            var eprd = Db.EndProduct.SingleOrDefault(ep => ep.Code == code && (id == -1 || ep.EP_Id != id));
            return eprd != null;
        }

        public EndProduct GetEndProductByCode(string code)
        {
            return Db.EndProduct.SingleOrDefault(ep => ep.Code == code);
        }
        public List<EndProduct> SearchEndProduct(string catelog,
                                                string subCatelog,
                                                string code,
                                                string name,
                                                string supplier,
                                                string location,
                                                int epLong,
                                                int epWidth,
                                                int epDeepth,
                                                double price)
        {
            var result = from p in Db.EndProduct
                         where
                         (
                         p.Catelog == catelog
                         ||
                         string.IsNullOrEmpty(catelog)
                         )
                         &&
                         (
                         p.SubCatelog == subCatelog
                         ||
                         string.IsNullOrEmpty(subCatelog)
                         )
                         &&
                         (
                         p.Code == code
                         ||
                         string.IsNullOrEmpty(code)
                         )
                         &&
                         (
                         p.Name == name
                         ||
                         string.IsNullOrEmpty(name)
                         )
                         &&
                         (
                         p.SupplierName == supplier
                         ||
                         string.IsNullOrEmpty(supplier)
                         )
                         &&
                         (
                         p.Location == location
                         ||
                         string.IsNullOrEmpty(location)
                         )
                         &&
                         (
                         p.Long == epLong
                         ||
                         epLong == -1
                         )
                         &&
                         (
                         p.Width == epWidth
                         ||
                         epWidth == -1
                         )
                         &&
                         (
                         p.Deepth == epDeepth
                         ||
                         epDeepth == -1
                         )
                         &&
                         (
                         p.Price == price
                         ||
                         price == -1
                         )
                         select p;
            return result.ToList();
        }

        public EndProduct GetEndProductById(int id)
        {
            return Db.EndProduct.SingleOrDefault(ep => ep.EP_Id == id);
        }

        public List<EndProduct> GetAllEndProductList()
        {
            return Db.EndProduct.ToList();
        }


    }
}
