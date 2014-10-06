using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using VE.SMS.Common;
using VE.SMS.DAL;

namespace VE.SMS.UI._UserControl
{
	public partial class DeliveryControl : BaseUserControl
	{
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public override void BindControl()
        {
            DeliveryDAL dal = new DeliveryDAL();
            var result = dal.GetDeliveryByOrderNo(SourceNo);
            Utility.BindDataToRepeater(rpDelivery, result);
        }

        protected void btnCreateDelivery_Click(object sender, EventArgs e)
        {
            //get no
            SeedDAL sdal = new SeedDAL();
            string no = sdal.GetNoByTableName(SysConst.TableDelivery, SysConst.SuffixDelivery);
            //customer
            string companyName = string.Empty;
            string contact = string.Empty;
            string address = string.Empty;
            string email = string.Empty;
            string qq = string.Empty;
            string phone1 = string.Empty;
            string phone2 = string.Empty;
            string other = string.Empty;

            OrderDAL soDAL = new OrderDAL();
            var so = soDAL.GetOrderByNo(SourceNo);
            so.Status = "申请送货安装";
            soDAL.Save();

            string orderNo = so.Order_No;
            companyName = so.CustomerCompanyName;
            contact = so.CustomerContactName;
            address = so.CustomerAddress;
            email = so.CustomerEmail;
            qq = so.CustomerQQ;
            phone1 = so.CustomerPhone1;
            phone2 = so.CustomerPhone2;
            other = so.CustomerOthers;
            
            //new delivery
            DeliveryDAL dal = new DeliveryDAL();
            Delivery delivery = new Delivery()
            {
                Order_No = orderNo,
                Delivery_No = no,
                Status = FirstStatusConsts.Delivery,
                CreatedDate = DateTime.Now,
                CreatedAt = DateTime.Now,
                CreatedBy = SMSContext.Current.User.UserName,
                CustomerCompanyName = companyName,
                CustomerContactName = contact,
                CustomerAddress = address,
                CustomerEmail = email,
                CustomerQQ = qq,
                CustomerPhone1 = phone1,
                CustomerPhone2 = phone2,
                CustomerOthers = other
            };
            dal.AddDelivery(delivery);
            dal.Save();

            int dlid = delivery.Delivery_Id;
            string dlno = delivery.Delivery_No;
            Utility.AddDefault(dlno, SysConst.SourceTypeDelivery, FooterConsts.Delivery);
            string url = Page.ResolveUrl(string.Format("~/DeliveryForm.aspx?dlid={0}&dlno={1}&sourcetype={2}&sourceno={3}", dlid, dlno, SourceType, SourceNo));
            string script = string.Format("<script>window.open('{0}')</script>", url);
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "createdelivery", script);
            BindControl();
            SetFocus(btnCreateDelivery);
        }
	}
}