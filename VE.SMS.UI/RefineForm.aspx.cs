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
	public partial class RefineForm : BasePage
	{
        protected override string ViewName
        {
            get
            {
                return ACLConsts.ViewRefineForm;
            }
        }
        protected override string EditName
        {
            get
            {
                return ACLConsts.EditRefineForm;
            }
        }
        protected string SourceType { get { return GetQueryStringValue(SysConst.KeySourceType).ToUpper(); } }
        protected string SourceNo { get { return GetQueryStringValue(SysConst.KeySourceNo); } }
        protected int RefId { get { return int.Parse(GetQueryStringValue("refid")); } }
        protected string RefNo { get { return GetQueryStringValue("refno"); } }

		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                Utility.BindDataToDropdown(ddlEnqOrdMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlRefMan, Utility.GetUserList2(true));

                if (!string.IsNullOrEmpty(SourceType) && !string.IsNullOrEmpty(SourceNo))
                {
                    //link
                    if (string.Equals(SourceType, SysConst.SourceTypeEnquiry, StringComparison.OrdinalIgnoreCase))
                    {
                        EnquiryDAL eDAL = new EnquiryDAL();
                        var enq = eDAL.GetEnquiryByNo(SourceNo);
                        lnkSource.NavigateUrl = Page.ResolveUrl(string.Format("~/enquiryform.aspx?enqno={0}&enqid={1}", SourceNo, enq.Enquiry_Id));
                    }
                    else
                    {
                        OrderDAL sDAL = new OrderDAL();
                        var ord = sDAL.GetOrderByNo(SourceNo);
                        lnkSource.NavigateUrl = Page.ResolveUrl(string.Format("~/orderform.aspx?ordno={0}&ordid={1}&sourcetype={2}&sourceno={3}", SourceNo, ord.Order_Id, ord.SourceType, ord.SourceNo));
                    }
                    lnkSource.Text = SourceNo;

                    RefineDAL dal = new RefineDAL();
                    var refine = dal.GetRefineByNo(RefNo);
                    //basic
                    txtCreatedDate.Text = refine.CreatedDate.ToString("yyyy-MM-dd");
                    ddlEnqOrdMan.SelectedValue = refine.EnqOrdMan;
                    ddlRefMan.SelectedValue = refine.RefineMan;
                    txtCompletedDate.Text = refine.RequestCompleteDate.HasValue ? refine.RequestCompleteDate.Value.ToString("yyyy-MM-dd") : string.Empty;
                    chkConfirm.Checked = refine.NeedCustomerConfirm;
                    txtConfirmIntro.Text = refine.CustomerConfirmIntro;
                    chkIncludeMachining.Checked = refine.IncludeMaching;
                    chkNeedApprove.Checked = refine.NeedApprove;
                    txtRefineIntro.Text = refine.RefineIntro;
                    //customer info
                    this.customerInfoControl.SetValue(
                        refine.CustomerCompanyName,
                        refine.CustomerContactName,
                        refine.CustomerAddress,
                        refine.CustomerEmail,
                        refine.CustomerQQ,
                        refine.CustomerPhone1,
                        refine.CustomerPhone2,
                        refine.CustomerOthers);
                    //history cad
                    UIUtility.BindUserControl(cADRefinementControl, SourceType, SourceNo);
                    //customer drawing
                    UIUtility.BindUserControl(customerDrawingControl, SourceType, SourceNo);
                    //survey
                    UIUtility.BindUserControl(surveyControl, SourceType, SourceNo);
                    //cad
                    cADFileListControl.RefineId = RefId;
                    UIUtility.BindUserControl(cADFileListControl, SourceType, SourceNo);
                    //followup
                    UIUtility.BindUserControl(followUpControl, SysConst.SourceTypeRefine, refine.Refine_No);

                    //status dropdown
                    var result = StatusEngine.GetRefineStatus(chkIncludeMachining.Checked, chkNeedApprove.Checked,chkConfirm.Checked);
                    ddlRefineStatus.Items.Clear();
                    foreach (var item in result)
                    {
                        ddlRefineStatus.Items.Add(new ListItem() { Text = item, Value = item });
                    }
                    ddlRefineStatus.SelectedValue = refine.Status;
                }
            }
            
		}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            RefineDAL dal = new RefineDAL();
            var refine = dal.GetRefineByNo(RefNo);
            refine.RefineMan = Utility.GetSelectedText(ddlRefMan);
            if (!string.IsNullOrEmpty(txtCompletedDate.Text))
            {
                refine.RequestCompleteDate = DateTime.Parse(txtCompletedDate.Text);
            }
            AddFollowUp(followUpControl, refine.Status, Utility.GetSelectedText(ddlRefineStatus));
            refine.Status = Utility.GetSelectedText(ddlRefineStatus);
            refine.NeedCustomerConfirm = chkConfirm.Checked;
            refine.CustomerConfirmIntro = txtConfirmIntro.Text;
            refine.IncludeMaching = chkIncludeMachining.Checked;
            refine.NeedApprove = chkNeedApprove.Checked;
            refine.RefineIntro = txtRefineIntro.Text;
            refine.CustomerCompanyName = customerInfoControl.CompanyName;
            refine.CustomerContactName = customerInfoControl.ContactName;
            refine.CustomerAddress = customerInfoControl.Address;
            refine.CustomerQQ = customerInfoControl.QQ;
            refine.CustomerEmail = customerInfoControl.Email;
            refine.CustomerPhone1 = customerInfoControl.Phone1;
            refine.CustomerPhone2 = customerInfoControl.Phone2;
            refine.CustomerOthers = customerInfoControl.Other;
            
            dal.Save();
            //save new customer
            customerInfoControl.Save();
            SetFocus(sender);

        }

        protected void btnChangeStatus_Click(object sender, EventArgs e)
        {
            RefineDAL dal = new RefineDAL();
            var refine = dal.GetRefineById(RefId);
            AddFollowUp(followUpControl, refine.Status, Utility.GetSelectedText(ddlRefineStatus));
            refine.Status = Utility.GetSelectedText(ddlRefineStatus);
            dal.Save();
            SetFocus(btnChangeStatus);
        }
	}
}