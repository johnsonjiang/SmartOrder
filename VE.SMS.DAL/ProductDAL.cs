using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;

namespace VE.SMS.DAL
{
    public class ProductDAL : BaseDAL
    {
        public List<Proce_GetProductByJia_Result> GetProductSummaryByJia(string Code,
            string Name,
            string HuangCode,
            string JiaCode,
            string PianCode,
            string Location,
            string Color,
            string Texure,
            string Supplier,
            int Long,
            int Width,
            int Deep,
            double PriceM,
            double PriceM2)
        {
            var result =  Db.Proce_GetProductByJia(Code,
                Name,
                HuangCode,
                JiaCode,
                PianCode,
                Location,
                Color,
                Texure,
                Supplier,
                Long,
                Width,
                Deep,
                (float)PriceM,
                (float)PriceM2);
            
            return result.ToList();
        }

        public List<Proce_GetProductByHuang_Result> GetProductSummaryByHuang(string Code,
            string Name,
            string HuangCode,
            string JiaCode,
            string PianCode,
            string Location,
            string Color,
            string Texure,
            string Supplier,
            int Long,
            int Width,
            int Deep,
            double PriceM,
            double PriceM2)
        {
            var result = Db.Proce_GetProductByHuang(Code,
            Name,
            HuangCode,
            JiaCode,
            PianCode,
            Location,
            Color,
            Texure,
            Supplier,
            Long,
            Width,
            Deep,
            (float)PriceM,
            (float)PriceM2);

            return result.ToList();
        }

        public List<Proce_GetProductByCode_Result> GetProductSummaryByProductCode(string Code,
            string Name,
            string HuangCode,
            string JiaCode,
            string PianCode,
            string Location,
            string Color,
            string Texure,
            string Supplier,
            int Long,
            int Width,
            int Deep,
            double PriceM,
            double PriceM2)
        {
            var result = Db.Proce_GetProductByCode(Code,
            Name,
            HuangCode,
            JiaCode,
            PianCode,
            Location,
            Color,
            Texure,
            Supplier,
            Long,
            Width,
            Deep,
            (float)PriceM,
            (float)PriceM2);

            return result.ToList();
        }
        public void AddProduct(Product product)
        {
            Db.Product.AddObject(product);
        }

        public List<Product> GetAllProducts()
        {
            return (from p in Db.Product
                   orderby p.Product_Name
                       select p).ToList();
        }

        public bool Exists(string code, 
                            string huangLiaoCode,
                            string jiaCode,
                            string pianCode,
                            int id)
        {
            bool isExists = false;

            var result = from p in Db.Product
                         where p.Product_Code == code
                         && p.HuangliaoCode == huangLiaoCode
                         && p.JiaCode == jiaCode
                         && p.PianCode == pianCode
                         && (id == -1 || p.Product_Id != id)
                         select p;
                             //.Select(p => p.Product_Code == code
                             // && p.HuangliaoCode == huangLiaoCode
                             // && p.JiaCode == jiaCode
                             // && p.PianCode == pianCode
                             // && p.Product_Id != id);
            if (result != null && result.Count() > 0)
            {
                isExists = true;
            }
            return isExists;
        }

        public Product GetProductById(int id)
        {
            return Db.Product.SingleOrDefault(p => p.Product_Id == id);
        }

        public List<Product> SearchProduct(string code,
            string name,
            string huangCode,
            string jiaCode,
            string pianCode,
            string location,
            string color,
            string texure,
            string supplier,
            int pLong,
            int pWidth,
            int pDeep,
            double priceM,
            double priceM2)
        {
            var result = from p in Db.Product
                         where
                         (
                         p.Product_Code == code
                         ||
                         string.IsNullOrEmpty(code)
                         )
                         &&
                         (
                         p.Product_Name == name
                         ||
                         p.Alias1 == name
                         ||
                         p.Alias2 == name
                         ||
                         string.IsNullOrEmpty(name)
                         )
                         &&
                         (
                         p.HuangliaoCode == huangCode
                         ||
                         string.IsNullOrEmpty(huangCode)
                         )
                         &&
                         (
                         p.JiaCode == jiaCode
                         ||
                         string.IsNullOrEmpty(jiaCode)
                         )
                         &&
                         (
                         p.PianCode == pianCode
                         ||
                         string.IsNullOrEmpty(pianCode)
                         )
                         &&
                         (
                         p.Location == location
                         ||
                         string.IsNullOrEmpty(location)
                         )
                         &&
                         (
                         p.Color == color
                         ||
                         string.IsNullOrEmpty(color)
                         )
                         &&
                         (
                         p.Texure == texure
                         ||
                         string.IsNullOrEmpty(texure)
                         )
                         &&
                         (
                         p.SupplierName == supplier
                         ||
                         string.IsNullOrEmpty(supplier)
                         )
                         &&
                         (
                         p.Long == pLong
                         ||
                         pLong == -1
                         )
                         &&
                         (
                         p.Width == pWidth
                         ||
                         pWidth == -1
                         )
                         &&
                         (
                         p.Deep == pDeep
                         ||
                         pDeep == -1
                         )
                         &&
                         (
                         p.PriceM == priceM
                         ||
                         priceM == -1
                         )
                         &&
                         (
                         p.PriceM2 == priceM2
                         ||
                         priceM2 == -1
                         )
                         select p;
            return result.ToList();
        }

    }
}
