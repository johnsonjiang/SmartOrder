using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VE.SMS.Common;
using System.Collections;
using VE.SMS.DAL;
using VE.SMS.UI._UserControl;

namespace VE.SMS.UI
{
	public partial class PurchaseList : BasePage
	{
        protected override string ViewName
        {
            get
            {
                return ACLConsts.ViewPurchaseList;
            }
        }
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                Utility.BindDataToDropdown(ddlPurchaseStatus, Utility.GetPurchaseStatusList(true));
                Utility.BindDataToDropdown(ddlApplyPurchaseMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlApproveMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlMachMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlMachTableMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlOrdMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlPurchaseMan, Utility.GetUserList2(true));

                Utility.BindDataToRepeater(rpPurchaseList, GetPOList());
            }
		}

        private List<PurchaseOrder> GetPOList()
        {
            PurchaseOrderDAL dal = new PurchaseOrderDAL();
            var pos = dal.SearchPO(txtPurchaseId.Text,
                                    Utility.GetSelectedText(ddlPurchaseStatus),
                                    Utility.GetSelectedText(ddlOrdMan),
                                    Utility.GetSelectedText(ddlMachMan),
                                    Utility.GetSelectedText(ddlPurchaseMan),
                                    Utility.GetSelectedText(ddlApplyPurchaseMan),
                                    Utility.GetSelectedText(ddlMachTableMan),
                                    Utility.GetSelectedText(ddlApproveMan),
                                    !string.IsNullOrEmpty(txtBeginDate.Text) ? DateTime.Parse(txtBeginDate.Text) : DateTime.MinValue,
                                    !string.IsNullOrEmpty(txtEndDate.Text) ? DateTime.Parse(txtEndDate.Text) : DateTime.MaxValue);
            return pos.ToList();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Utility.BindDataToRepeater(rpPurchaseList, GetPOList());
        }

        protected void rpPurchaseList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete" && (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item))
            {
                HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
                new PurchaseOrderDAL().Delete(int.Parse(hdId.Value));
                Utility.BindDataToRepeater(rpPurchaseList, GetPOList());
            }
            else
            {
                SetSorting(e);
                if (!string.IsNullOrWhiteSpace(SortOrder))
                {
                    Utility.BindDataToRepeater(rpPurchaseList, GetPOList().Sort(string.Format("{0} {1}", e.CommandName, SortOrder)));
                }
            }
        }

        protected void rpPurchaseList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                FollowUpTop3UserControl followUp = e.Item.FindControl("followUpTop3UserControl") as FollowUpTop3UserControl;
                UIUtility.BindUserControl(followUp, SysConst.SourceTypePurchase, ((PurchaseOrder)e.Item.DataItem).Purchase_No);
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //get no
            SeedDAL sdal = new SeedDAL();
            string no = sdal.GetNoByTableName(SysConst.TablePurchaseOrder, SysConst.SuffixPurchaseOrder);

            //if (string.Equals(SourceType, SysConst.SourceTypeSalesOrder, StringComparison.OrdinalIgnoreCase))
            //{
            //    SalesOrderDAL soDAL = new SalesOrderDAL();
            //    var so = soDAL.GetOrderByNo(SourceNo);
            //    enqOrdMan = so.OrderMan;
            //    companyName = so.CustomerCompanyName;
            //    contact = so.CustomerContactName;
            //    address = so.CustomerAddress;
            //    email = so.CustomerEmail;
            //    qq = so.CustomerQQ;
            //    phone1 = so.CustomerPhone1;
            //    phone2 = so.CustomerPhone2;
            //    other = so.CustomerOthers;
            //}
            //new po
            PurchaseOrderDAL dal = new PurchaseOrderDAL();
            PurchaseOrder po = new PurchaseOrder()
            {
                Purchase_No = no,
                Status = FirstStatusConsts.Purchase,
                SourceType = string.Empty,
                SourceNo = string.Empty,
                CreatedDate = DateTime.Now,
                CreatedAt = DateTime.Now,
                CreatedBy = SMSContext.Current.User.UserName
            };
            dal.AddPO(po);
            dal.Save();

            int poid = po.Purchase_Id;
            string pono = po.Purchase_No;
            string url = Page.ResolveUrl(string.Format("~/PurchaseForm.aspx?poid={0}&pono={1}&sourcetype={2}&sourceno={3}", poid, pono, string.Empty, string.Empty));
            string script = string.Format("<script>window.open('{0}')</script>", url);
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "createpo", script);
        }
	}
}