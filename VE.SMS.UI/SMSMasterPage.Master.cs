using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VE.SMS.Common;
using VE.SMS.DAL;

namespace VE.SMS.UI
{
	public partial class SMSMasterPage : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                var nameDict = GetNameDict();
                string url = Request.Url.AbsolutePath.ToLower();
                foreach (var item in nameDict)
                {
                    if (url.Contains(item.Key))
                    {
                        lblFormName.Text = item.Value;
                        break;
                    }
                } 
            }

		}

        private static Dictionary<string, string> GetNameDict()
        {
            Dictionary<string, string> NameDict = new Dictionary<string, string>();
            NameDict.Add("enquiryform", "咨询单");
            NameDict.Add("refineform", "细化单");
            NameDict.Add("surveyform", "测量单");
            NameDict.Add("quotationform", "报价单");
            NameDict.Add("orderform", "订单");
            NameDict.Add("machiningform", "生产单");
            NameDict.Add("deliveryform", "送货安装单");
            NameDict.Add("settlementform", "结算单");
            NameDict.Add("purchaseform", "采购单");
            NameDict.Add("productform", "材料/样品/成品");
            NameDict.Add("systemconfiguration", "系统配置");
            NameDict.Add("accesscontrolmanagement", "权限管理");
            return NameDict;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            ACLUtility.Logout();
        }
	}
}