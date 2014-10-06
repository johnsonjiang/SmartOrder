using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using VE.SMS.DAL;

namespace VE.SMS.Common
{
    public class SMSContext
    {
        public UserInfo User 
        {
            get
            {
                UserInfo user = null;
                if (!string.IsNullOrEmpty(ACLUtility.GetCookie("UserName")) && !string.IsNullOrEmpty(ACLUtility.GetCookie("RealName")))
                {
                    UserDAL dal = new UserDAL();
                    var dbuser = dal.GetUserByUserName(ACLUtility.GetCookie("UserName"));
                    user = new UserInfo() { UserName = ACLUtility.GetCookie("UserName"), RealName = dbuser.RealName };
                }
                return user;
            }
        }
        private static readonly SMSContext context = new SMSContext();
        public static SMSContext Current
        {
            get
            {
                return context;
            }
        }
    }
}
    