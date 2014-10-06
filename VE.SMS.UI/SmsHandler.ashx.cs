using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Text;
using System.Collections;
using VE.SMS.DAL;

namespace VE.SMS.UI
{
    /// <summary>
    /// Summary description for SmsHandler
    /// </summary>
    public class SmsHandler : IHttpHandler
    {

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            if (string.Equals(context.Request.QueryString["rtype"], "getsamples", StringComparison.OrdinalIgnoreCase))
            {
                List<string> samples = GetSampleProductList();
                
                context.Response.Write(serializer.Serialize(samples));
            }
            else if (string.Equals(context.Request.QueryString["rtype"], "getproducts", StringComparison.OrdinalIgnoreCase))
	        {
                var products = GetProductList();
                context.Response.Write(serializer.Serialize(products));
	        }
        }

        private List<string> GetSampleProductList()
        {
            SampleDAL dal = new SampleDAL();
            var list = from s in dal.GetAllSamples()
                       select s.SampleCode;
            return list.ToList();
        }

        private List<Product> GetProductList()
        {
            ProductDAL dal = new ProductDAL();
            return dal.GetAllProducts();
        }
    }
}