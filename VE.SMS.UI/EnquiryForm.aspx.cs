using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using VE.SMS.Common;
using VE.SMS.DAL;

namespace VE.SMS.UI
{
	public partial class EnquiryForm : BasePage
	{
        protected string EnqNo { get { return GetQueryStringValue("enqno"); } }
        protected int EnqId { get { return int.Parse(GetQueryStringValue("enqid")); } }
        protected override string ViewName
        {
            get
            {
                return ACLConsts.ViewEnquiryForm;
            }
        }
        protected override string EditName
        {
            get
            {
                return ACLConsts.EditEnquiryForm;
            }
        }
        protected override void OnInit(EventArgs e)
        {
            this.DeliveryEditControl1.OnGetAddress = this.GetAddress;
        }

        private string GetAddress()
        {
            return customerInfoControl.Address;
        }
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                //dropdown
                Utility.BindDataToDropdown(ddlEnquiryStatus, Utility.GetEnquiryStatusList());
                Utility.BindDataToDropdown(ddlEnqMan, Utility.GetUserList2(true));
                if (!string.IsNullOrWhiteSpace(EnqNo))
	            {
                    EnquiryDAL dal = new EnquiryDAL();
                    var enq = dal.GetEnquiryById(EnqId);
                    txtEnqNo.Text = enq.Enquiry_No;
                    this.txtCreatedDate.Text = enq.CreatedDate.ToString("yyyy-MM-dd");
                    this.txtRemark.Text = enq.Remark;
                    this.txtBeginDate.Text = enq.ExpectedBeginDate != null ? enq.ExpectedBeginDate.Value.ToString("yyyy-MM-dd") : string.Empty;
                    this.txtEndDate.Text = enq.ExpectedEndDate != null ? enq.ExpectedEndDate.Value.ToString("yyyy-MM-dd") : string.Empty;
                    this.txtTimeLimitRemark.Text = enq.TimeLimitRemark;
                    this.lblStatus.Text = enq.Status;
                    this.ddlEnqMan.SelectedValue = enq.EnqMan;
                    this.txtEnqSummary.Text = enq.Summary;
                    //customer info
                    this.customerInfoControl.SetValue(
                        enq.CustomerCompanyName, 
                        enq.CustomerContactName, 
                        enq.CustomerAddress, 
                        enq.CustomerEmail, 
                        enq.CustomerQQ, 
                        enq.CustomerPhone1, 
                        enq.CustomerPhone2, 
                        enq.CustomerOthers);
                    //enq content
                    UIUtility.BindUserControl(lineItemsControl, SysConst.SourceTypeEnquiry, enq.Enquiry_Id);
                    //enq img
                    enquiryImageControl.ImagePath = enq.EnquiryImgPath;
                    enquiryImageControl.EnquiryId = enq.Enquiry_Id;
                    UIUtility.BindUserControl(enquiryImageControl, SysConst.SourceTypeSurvey, enq.Enquiry_No);
                    //sample
                    this.SampleControl1.SetValue(enq.IsSampleProvidedToCustomer, enq.IsCustomerProvideSample);
                    UIUtility.BindUserControl(SampleControl1, SysConst.SourceTypeEnquiry, enq.Enquiry_No);
                    //customer drawing
                    customerDrawingControl.IsCustomerProvideImage = enq.IsCustomerProvideImage;
                    UIUtility.BindUserControl(customerDrawingControl, SysConst.SourceTypeEnquiry, enq.Enquiry_No);
                    //survey
                    SurveyEditControl1.IsSurveyNeed = enq.IsSurveyNeeded;
                    SurveyEditControl1.SurveyIntro = enq.SurveyIntro;
                    UIUtility.BindUserControl(SurveyEditControl1, SysConst.SourceTypeEnquiry, enq.Enquiry_No);
                    SurveyEditControl1.SetSurveyType(enq.SurveyType);
                    //cad
                    CADEditControl1.IsCADRefinementNeeded = enq.IsCADRefinementNeeded;
                    CADEditControl1.RefineIntro = enq.CADRefinementIntro;
                    CADEditControl1.IsCustomerCADConfirmationNeeded = enq.IsCADNeedCustomerConfirmation;
                    UIUtility.BindUserControl(CADEditControl1, SysConst.SourceTypeEnquiry, enq.Enquiry_No);
                    //delivery
                    DeliveryEditControl1.DeliveryIntro = enq.DeliveryIntro;
                    DeliveryEditControl1.DeliveryToAddress = enq.DeliveryToAddress;
                    UIUtility.BindUserControl(DeliveryEditControl1, SysConst.SourceTypeEnquiry, enq.Enquiry_No);
                    DeliveryEditControl1.SetDeliveryType(enq.DeliveryType);
                    //install
                    InstallEditControl1.IsInstallProvided = enq.IsInstallProvided;
                    InstallEditControl1.InstallIntro = enq.InstallIntro;
                    UIUtility.BindUserControl(InstallEditControl1, SysConst.SourceTypeEnquiry, enq.Enquiry_No);
                    InstallEditControl1.SetInstallType(enq.InstallType);
                    //quote
                    UIUtility.BindUserControl(quotationControl, SysConst.SourceTypeEnquiry, enq.Enquiry_No);
                    //survey
                    UIUtility.BindUserControl(surveyControl, SysConst.SourceTypeEnquiry, enq.Enquiry_No);
                    //refine
                    UIUtility.BindUserControl(cADRefinementControl, SysConst.SourceTypeEnquiry, enq.Enquiry_No);
                    //intro
                    UIUtility.BindUserControl(FooterIntroControl1, SysConst.SourceTypeEnquiry, enq.Enquiry_No);
                    //status
                    ddlEnquiryStatus.SelectedValue = enq.Status;
                    //followup
                    UIUtility.BindUserControl(followUpControl, SysConst.SourceTypeEnquiry, enq.Enquiry_No);
	            }
			}
		}

        protected void btnUpdateEnqNo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEnqNo.Text))
            {
                EnquiryDAL dal = new EnquiryDAL();
                Enquiry enq = dal.GetEnquiryById(EnqId);
                var dbEnq = dal.GetEnquiryByNo(txtEnqNo.Text);
                if (dbEnq != null && dbEnq.Enquiry_Id != EnqId )
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "updateno", "<script>alert('已经有相同咨询单号!');</script>");
                }
                else
                {
                    enq.Enquiry_No = txtEnqNo.Text;
                    dal.Save();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string enqNo = EnqNo;
            EnquiryDAL dal = new EnquiryDAL();
            var enq = dal.GetEnquiryByNo(enqNo);
            if (!string.IsNullOrEmpty(txtBeginDate.Text))
            {
                enq.ExpectedBeginDate = DateTime.Parse(txtBeginDate.Text);
            }
            if (!string.IsNullOrEmpty(txtEndDate.Text))
            {
                enq.ExpectedEndDate = DateTime.Parse(txtEndDate.Text);
            }
            //update enq
            enq.TimeLimitRemark = txtTimeLimitRemark.Text;
            enq.EnqMan = Utility.GetSelectedText(ddlEnqMan); ;
            enq.Remark = txtRemark.Text;
            enq.Summary = txtEnqSummary.Text;
            enq.CustomerCompanyName = customerInfoControl.CompanyName;
            enq.CustomerContactName = customerInfoControl.ContactName;
            enq.CustomerAddress = customerInfoControl.Address;
            enq.CustomerEmail = customerInfoControl.Email;
            enq.CustomerQQ = customerInfoControl.QQ;
            enq.CustomerPhone1 = customerInfoControl.Phone1;
            enq.CustomerPhone2 = customerInfoControl.Phone2;
            enq.CustomerOthers = customerInfoControl.Other;
            enq.EnquiryImgPath = enquiryImageControl.ImagePath;
            enq.IsSampleProvidedToCustomer = SampleControl1.IsSampleProvidedToCustomer;
            enq.IsCustomerProvideSample = SampleControl1.IsSampleFromCustomer;
            enq.IsCustomerProvideImage = customerDrawingControl.IsCustomerProvideImage;
            enq.IsSurveyNeeded = SurveyEditControl1.IsSurveyNeed;
            if (SurveyEditControl1.IsSurveyNeed)
            {
                enq.SurveyType = SurveyEditControl1.SurveyType;
                enq.SurveyIntro = SurveyEditControl1.SurveyIntro;
            }
            enq.IsCADRefinementNeeded = CADEditControl1.IsCADRefinementNeeded;
            if (CADEditControl1.IsCADRefinementNeeded)
            {
                enq.CADRefinementIntro = CADEditControl1.RefineIntro;
                enq.IsCADNeedCustomerConfirmation = CADEditControl1.IsCustomerCADConfirmationNeeded;
            }
            enq.DeliveryType = DeliveryEditControl1.DeliveryType;
            enq.DeliveryIntro = DeliveryEditControl1.DeliveryIntro;
            enq.DeliveryToAddress = DeliveryEditControl1.DeliveryToAddress;

            enq.IsInstallProvided = InstallEditControl1.IsInstallProvided;
            if (InstallEditControl1.IsInstallProvided)
            {
                enq.InstallType = InstallEditControl1.InstallType;
                enq.InstallIntro = InstallEditControl1.InstallIntro;
            }
            AddFollowUp(followUpControl, enq.Status, Utility.GetSelectedText(ddlEnquiryStatus));
            enq.Status = ddlEnquiryStatus.SelectedItem.Text;
            dal.Save();
            //save new customer
            customerInfoControl.Save();
            this.SetFocus(sender);
        }

        public void btnChangeStatus_OnClick(object sender, EventArgs e)
        {
            int enqId = int.Parse(GetQueryStringValue("enqid"));
            EnquiryDAL dal = new EnquiryDAL();
            var enq = dal.GetEnquiryById(enqId);
            AddFollowUp(followUpControl, enq.Status, Utility.GetSelectedText(ddlEnquiryStatus));
            enq.Status = this.ddlEnquiryStatus.SelectedItem.Text;
            dal.Save();
            SetFocus(sender);
        }

        protected void btnGenerateOrder_Click(object sender, EventArgs e)
        {
            Enquiry enq = new EnquiryDAL().GetEnquiryByNo(GetQueryStringValue("enqno"));
            OrderDAL dal = new OrderDAL();
            var order = dal.GetOrderByEnq(enq.Enquiry_No);
            if (order != null)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "generateorder",
                string.Format("<script>window.open('OrderForm.aspx?ordid={0}&ordno={1}&sourcetype=E&sourceno={2}')</script>", order.Order_Id, order.Order_No, enq.Enquiry_No));
                return;
            }

            SeedDAL sdal = new SeedDAL();
            LineItemDAL lDAL = new LineItemDAL();
            var no = sdal.GetNoByTableName(SysConst.TableOrder, SysConst.SuffixOrder);
            var enqItems = lDAL.GetLineItemsBySource(enq.Enquiry_Id, SysConst.SourceTypeEnquiry);

            Order ord = new Order();
            ord.SourceType = SysConst.SourceTypeEnquiry;
            ord.SourceNo = enq.Enquiry_No;
            ord.Order_No = no;
            ord.Status = FirstStatusConsts.Order;
            ord.CreatedDate = DateTime.Now;
            ord.CustomerAddress = enq.CustomerAddress;
            ord.CustomerCompanyName = enq.CustomerCompanyName;
            ord.CustomerContactName = enq.CustomerContactName;
            ord.CustomerEmail = enq.CustomerEmail;
            ord.CustomerOthers = enq.CustomerOthers;
            ord.CustomerPhone1 = enq.CustomerPhone1;
            ord.CustomerPhone2 = enq.CustomerPhone2;
            ord.CustomerQQ = enq.CustomerQQ;

            ord.IsSampleProvidedToCustomer = enq.IsSampleProvidedToCustomer;
            ord.IsCustomerProvideSample = enq.IsCustomerProvideSample;
            ord.IsCustomerProvideImage = enq.IsCustomerProvideImage;
            ord.IsSurveyNeeded = enq.IsSurveyNeeded;
            ord.SurveyType = enq.SurveyType;
            ord.SurveyIntro = enq.SurveyIntro;
            ord.IsCADRefinementNeeded = enq.IsCADRefinementNeeded;
            ord.CADRefinementIntro = enq.CADRefinementIntro;
            ord.IsCADNeedCustomerConfirmation = enq.IsCADNeedCustomerConfirmation;
            ord.DeliveryType = enq.DeliveryType;
            ord.DeliveryIntro = enq.DeliveryIntro;
            ord.DeliveryToAddress = enq.DeliveryToAddress;
            ord.IsInstallProvided = enq.IsInstallProvided;
            ord.InstallType = string.IsNullOrEmpty(enq.InstallType) ? string.Empty : enq.InstallType;
            ord.InstallIntro = enq.InstallIntro;
            ord.EnqNo = enq.Enquiry_No;
            ord.IsActive = true;
            
            dal.AddOrder(ord);
            dal.Save();
            //intro
            Utility.AddDefault(ord.Order_No, SysConst.SourceTypeOrder, FooterConsts.Order);
            //item
            foreach (var item in enqItems)
            {
                LineItem newItem = new LineItem()
                {
                    Intro = item.Intro,
                    Name = item.Name,
                    Project = item.Project,
                    Quantity = item.Quantity,
                    Remark = item.Remark,
                    SourceId = ord.Order_Id,
                    SourceType = SysConst.SourceTypeOrder,
                    Spec = item.Spec,
                    Unit = item.Unit,
                    UnitPrice = item.UnitPrice
                };
                lDAL.AddLineItem(newItem);
            }
            lDAL.Save();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "generateorder",
                string.Format("<script>window.open('OrderForm.aspx?ordid={0}&ordno={1}&sourcetype=E&sourceno={2}')</script>", ord.Order_Id, ord.Order_No, enq.Enquiry_No));
        }
	}
}