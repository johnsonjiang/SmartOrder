using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VE.SMS.DAL;
using System.Web;

namespace VE.SMS.Common
{
    public static class ACLUtility
    {
        public static string GetCookie(string cookieName)
        {
            string cookieValue = string.Empty;
            if (HttpContext.Current.Request.Cookies.AllKeys != null && HttpContext.Current.Request.Cookies.AllKeys.Contains(cookieName))
            {
                cookieValue = HttpContext.Current.Request.Cookies[cookieName].Value;
            }
            return cookieValue;
        }

        public static void WriteLoginCookie(UserInfo user)
        {
            WriteCookie("UserName", user.UserName);
            WriteCookie("RealName", user.RealName);
        }

        private static void WriteCookie(string cookieName, string value)
        {
            HttpContext.Current.Response.AppendCookie(new HttpCookie(cookieName, value));
        }

        public static void Logout()
        {
            DeleteCookie("UserName");
            DeleteCookie("RealName");
            HttpContext.Current.Response.Redirect("~/Login.aspx");
        }
        private static void DeleteCookie(string cookieName)
        {
            var cookie = new HttpCookie(cookieName); 
            cookie.Expires = DateTime.Now.AddDays(-1); 
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        public static bool AuthorizeLoginUser(string userName, string pwd,ref UserInfo user)
        {
            UserDAL dal = new UserDAL();
            var dbuser =  dal.GetUserByNameAndPwd(userName, pwd);

            if (dbuser != null)
            {
                user = new UserInfo() { UserName = dbuser.UserName, RealName = dbuser.RealName };
                return true;
            }
            return false;
        }

        public static bool IsAccessible(string name)
        {
            bool result = false;
            if (SMSContext.Current.User != null)
            {
                UserDAL dal = new UserDAL();
                result = dal.HasPermission(SMSContext.Current.User.UserName, name);
            }
            return result;
        }

        public static bool GetMonitorSignal()
        {
            bool signal = true;
            var dal = new MonitorDAL();
            var monitor = dal.GetMonitor();
            if (monitor != null && monitor.MonitorV == 2)
            {
                signal = false;
            }
            return signal;
        }
    }
}
