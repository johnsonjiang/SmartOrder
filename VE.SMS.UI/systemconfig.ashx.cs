using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VE.SMS.DAL;
using System.Web.Script.Serialization;

namespace VE.SMS.UI
{
    /// <summary>
    /// Summary description for systemconfig
    /// </summary>
    public class systemconfig : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string projecttype = context.Request.QueryString["prj"];
            string productId = context.Request.QueryString["prd"];
            string unit = context.Request.QueryString["unit"];
            double price = 0;

            if (string.Equals(projecttype, "EndProduct", StringComparison.OrdinalIgnoreCase))
            {
                EndProductDAL dal = new EndProductDAL();
                var ep = dal.GetEndProductById(int.Parse(projecttype));
                price = ep.Price.Value;
            }
            else if (string.Equals(projecttype, "Product", StringComparison.OrdinalIgnoreCase))
            {
                ProductDAL dal = new ProductDAL();
                var product = dal.GetProductById(int.Parse(productId));
                if (string.Equals(unit, "M", StringComparison.OrdinalIgnoreCase))
                {
                    price = product.PriceM.Value;
                }
                else if (string.Equals(unit, "M2", StringComparison.OrdinalIgnoreCase))
                {
                    price = product.PriceM2.Value;
                }
                else
                {
                    price = product.PriceOther.Value;
                }
            }
            else if (string.Equals(projecttype, "Install", StringComparison.OrdinalIgnoreCase))
            {
                InstallLookupDAL dal = new InstallLookupDAL();
                var install = dal.GetLookupById(int.Parse(productId));
                if (string.Equals(unit, "M", StringComparison.OrdinalIgnoreCase))
                {
                    price = install.PriceM.Value;
                }
                else if (string.Equals(unit, "M2", StringComparison.OrdinalIgnoreCase))
                {
                    price = install.PriceM2.Value;
                }
                else
                {
                    price = install.PriceOther.Value;
                }
            }
            else if (string.Equals(projecttype, "Mach", StringComparison.OrdinalIgnoreCase))
            {
                MachLookupDAL dal = new MachLookupDAL();
                var mach = dal.GetMachLookupById(int.Parse(productId));
                if (string.Equals(unit, "M", StringComparison.OrdinalIgnoreCase))
                {
                    price = mach.PriceM.Value;
                }
                else if (string.Equals(unit, "M2", StringComparison.OrdinalIgnoreCase))
                {
                    price = mach.PriceM2.Value;
                }
                else
                {
                    price = mach.PriceOther.Value;
                }
            }
            context.Response.Write(new JavaScriptSerializer().Serialize(price));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}