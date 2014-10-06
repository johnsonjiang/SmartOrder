using System;
using System.Web;
using VE.SMS.DAL;

namespace VE.SMS.UI
{
    public class MonitorHandler : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string debug = context.Request.QueryString["debug"];
            if (!string.IsNullOrWhiteSpace(debug))
            {
                var dal = new MonitorDAL();
                if (string.Equals(debug,"m=1", StringComparison.OrdinalIgnoreCase))
                {
                    dal.SaveMonitor(1);
                }
                else if (string.Equals(debug,"m=2", StringComparison.OrdinalIgnoreCase))
                {
                    dal.SaveMonitor(2);
                }
            }
            else
            {
                context.Response.Write("Monitor is working successfully!");
            }
        }

        #endregion
    }
}
