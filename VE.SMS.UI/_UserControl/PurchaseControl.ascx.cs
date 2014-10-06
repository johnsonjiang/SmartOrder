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
	public partial class PurchaseControl : BaseUserControl
	{
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override void BindControl()
        {
            PurchaseOrderDAL dal = new PurchaseOrderDAL();
            var result = dal.GetPOBySource(SourceType, SourceNo);
            Utility.BindDataToRepeater(rpPurchase, result);
        }

        protected void btnCreatePurchase_Click(object sender, EventArgs e)
        {
            //get no
            SeedDAL sdal = new SeedDAL();
            string no = sdal.GetNoByTableName(SysConst.TablePurchaseOrder, SysConst.SuffixPurchaseOrder);
            //get enqordman
            string enqOrdMan = string.Empty;
            string companyName = string.Empty;
            string contact = string.Empty;
            string address = string.Empty;
            string email = string.Empty;
            string qq = string.Empty;
            string phone1 = string.Empty;
            string phone2 = string.Empty;
            string other = string.Empty;

            if (string.Equals(SourceType, SysConst.SourceTypeOrder, StringComparison.OrdinalIgnoreCase))
            {
                OrderDAL soDAL = new OrderDAL();
                var so = soDAL.GetOrderByNo(SourceNo);
                so.Status = "申请采购";
                soDAL.Save();

                enqOrdMan = so.OrderMan;
                companyName = so.CustomerCompanyName;
                contact = so.CustomerContactName;
                address = so.CustomerAddress;
                email = so.CustomerEmail;
                qq = so.CustomerQQ;
                phone1 = so.CustomerPhone1;
                phone2 = so.CustomerPhone2;
                other = so.CustomerOthers;  
            }
            else if(string.Equals(SourceType, SysConst.SourceTypeMaching, StringComparison.OrdinalIgnoreCase))
            {
                MachiningDAL mDAL = new MachiningDAL();
                var mach = mDAL.GetMachByNo(SourceNo);
                companyName = mach.CustomerCompanyName;
                contact = mach.CustomerContactName;
                address = mach.CustomerAddress;
                email = mach.CustomerEmail;
                qq = mach.CustomerQQ;
                phone1 = mach.CustomerPhone1;
                phone2 = mach.CustomerPhone2;
                other = mach.CustomerOthers;

            }
            //new refine
            PurchaseOrderDAL dal = new PurchaseOrderDAL();
            PurchaseOrder po = new PurchaseOrder()
            {
                Purchase_No = no,
                Status = FirstStatusConsts.Purchase,
                EnqOrdMan = enqOrdMan,
                SourceType = SourceType,
                SourceNo = SourceNo,
                CreatedDate = DateTime.Now,
                CreatedAt = DateTime.Now,
                CreatedBy = SMSContext.Current.User.UserName
            };
            dal.AddPO(po);
            dal.Save();

            int poid = po.Purchase_Id;
            string pono = po.Purchase_No;

            //poitem
            if (string.Equals(SourceType, SysConst.SourceTypeMaching, StringComparison.OrdinalIgnoreCase))
            {
                MachiningDAL mDAL = new MachiningDAL();
                var mach = mDAL.GetMachByNo(SourceNo);
                MachItemDAL miDAL = new MachItemDAL();
                var machItems = miDAL.GetMachItemsByMachId(mach.Mach_Id);

                POItemDAL pDAL = new POItemDAL();
                foreach (var item in machItems)
                {
                    PurchaseOrderItem poItem = new PurchaseOrderItem() 
                    { 
                        Code = item.Code,
                        Deepth = item.Deepth,
                        Intro = item.Intro,
                        Long = item.Long,
                        PO_Id = poid,
                        Product_Code = item.Product_Code,
                        Quantity = item.Quantity,
                        Square = item.Square,
                        Width = item.Width
                    };
                    pDAL.AddPOItem(poItem);
                }
                pDAL.Save();
            }

            string url = Page.ResolveUrl(string.Format("~/PurchaseForm.aspx?poid={0}&pono={1}&sourcetype={2}&sourceno={3}", poid, pono, SourceType, SourceNo));
            string script = string.Format("<script>window.open('{0}')</script>", url);
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "createpo", script);
            BindControl();
            SetFocus(btnCreatePurchase);
        }
	}
}