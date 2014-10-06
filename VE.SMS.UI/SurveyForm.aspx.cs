using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VE.SMS.Common;
using VE.SMS.DAL;
using System.Text;

namespace VE.SMS.UI
{
	public partial class SurveyForm : BasePage
	{
        protected override string ViewName
        {
            get
            {
                return ACLConsts.ViewSurveyForm;
            }
        }
        protected override string EditName
        {
            get
            {
                return ACLConsts.EditSurveyForm;
            }
        }
        protected int SVId { get { return int.Parse(GetQueryStringValue("svid")); } }
        protected string SVNo { get { return GetQueryStringValue("svno"); } }

		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                Utility.BindDataToDropdown(ddlSurveyStatus, Utility.GetSurveyStatusList());
                Utility.BindDataToDropdown(ddlEnqOrdMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlSurveyMan, Utility.GetUserList2(true));
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

                    SurveyDAL dal = new SurveyDAL();
                    var survey = dal.GetSurveyById(SVId);
                    //basic
                    txtCreatedDate.Text = survey.CreatedDate.ToString("yyyy-MM-dd");
                    ddlEnqOrdMan.SelectedValue = survey.EnqOrdMan;
                    txtExpectedSurveyDate.Text = survey.ExpectedSurveyDate != null ? survey.ExpectedSurveyDate.Value.ToString("yyyy-MM-dd") : string.Empty ;
                    txtOnsiteContactName.Text = survey.OnSiteContactName;
                    txtOnsiteContactPhone.Text = survey.OnSiteContactPhone;
                    txtSurveyIntro.Text = survey.SurveyIntro;
                    ddlSurveyMan.SelectedValue = survey.SurveyMan;
                    //goods bring
                    Utility.BindDataToCheckBoxList(chklToos, Utility.GetLookupList("测量物品"));
                    string goods = survey.GoodsBring;
                    if (!string.IsNullOrEmpty(goods))
                    {
                        foreach (ListItem item in chklToos.Items)
                        {
                            if (goods.Contains(item.Text))
                            {
                                item.Selected = true;
                            }
                        } 
                    }
                    //customer info
                    this.customerInfoControl.SetValue(
                        survey.CustomerCompanyName,
                        survey.CustomerContactName,
                        survey.CustomerAddress,
                        survey.CustomerEmail,
                        survey.CustomerQQ,
                        survey.CustomerPhone1,
                        survey.CustomerPhone2,
                        survey.CustomerOthers);
                    //line content
                    LineItemsControl1.SourceId = survey.Survey_Id;
                    UIUtility.BindUserControl(LineItemsControl1, SysConst.SourceTypeDelivery, survey.Survey_No);

                    //history survey
                    LineItemsControl1.IsPriceColumnVisible = false;
                    LineItemsControl1.IsFooterVisible = false;
                    LineItemsControl1.SourceId = survey.Survey_Id;
                    UIUtility.BindUserControl(LineItemsControl1, SysConst.SourceTypeSurvey, survey.Survey_No);
                    //cad refine
                    UIUtility.BindUserControl(cADRefinementControl, SourceType, SourceNo);
                    //customer drawing
                    UIUtility.BindUserControl(customerDrawingControl, SourceType, SourceNo);
                    //refine
                    UIUtility.BindUserControl(surveyControl, SourceType, SourceNo);
                    //survey data
                    if (!string.IsNullOrEmpty(survey.SurveyImagePath))
                    {
                        imgSurveyData.ImageUrl = Page.ResolveUrl(survey.SurveyImagePath);
                        imgSurveyData.AlternateText = survey.SurveyImageName; 
                    }
                    //followup
                    UIUtility.BindUserControl(followUpControl, SysConst.SourceTypeSurvey, survey.Survey_No);

                    //status dropdown
                    ddlSurveyStatus.SelectedValue = survey.Status;

                }
            }
		}

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(fileUploadSurveyImg.FileName))
            {
                string serverFilePath = string.Empty;
                Utility.UploadFile(fileUploadSurveyImg, "SurveyImage", SourceNo, ref serverFilePath);
                SurveyDAL dal = new SurveyDAL();
                var survey = dal.GetSurveyById(SVId);
                survey.SurveyImageName = Utility.GetFileName(fileUploadSurveyImg);
                survey.SurveyImagePath = serverFilePath;
                dal.Save();
                imgSurveyData.ImageUrl = Page.ResolveUrl(serverFilePath);
                imgSurveyData.AlternateText = Utility.GetFileName(fileUploadSurveyImg);
            }
            SetFocus(sender);
        }

        protected void btnChangeStatus_Click(object sender, EventArgs e)
        {
            SurveyDAL dal = new SurveyDAL();
            var survey = dal.GetSurveyById(SVId);
            AddFollowUp(followUpControl, survey.Status, Utility.GetSelectedText(ddlSurveyStatus));
            survey.Status = Utility.GetSelectedText(ddlSurveyStatus);
            dal.Save();
            SetFocus(btnChangeStatus);
        }

        protected void chkSametoContact_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSametoContact.Checked)
            {
                txtOnsiteContactName.Text = customerInfoControl.ContactName;
            }
            else
            {
                txtOnsiteContactName.Text = string.Empty;
            }
        }

        protected void chkSametocontactphone_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSametocontactphone.Checked)
            {
                txtOnsiteContactPhone.Text = !string.IsNullOrEmpty(customerInfoControl.Phone1) ? customerInfoControl.Phone1 : customerInfoControl.Phone2;
            }
            else
            {
                txtOnsiteContactPhone.Text = string.Empty;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string svNo = SVNo;
            SurveyDAL dal = new SurveyDAL();
            var survey = dal.GetSurveyById(SVId);
            if (!string.IsNullOrEmpty(txtExpectedSurveyDate.Text))
            {
                survey.ExpectedSurveyDate = DateTime.Parse(txtExpectedSurveyDate.Text);
            }
            //update survey
            survey.EnqOrdMan = Utility.GetSelectedText(ddlEnqOrdMan);
            survey.OnSiteContactName = txtOnsiteContactName.Text;
            survey.OnSiteContactPhone = txtOnsiteContactPhone.Text;
            survey.SurveyIntro = txtSurveyIntro.Text;
            AddFollowUp(followUpControl, survey.Status, Utility.GetSelectedText(ddlSurveyStatus));
            survey.Status = Utility.GetSelectedText(ddlSurveyStatus);
            survey.SurveyMan = Utility.GetSelectedText(ddlSurveyMan);
            //goods
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < chklToos.Items.Count;i++ )
            {
                if (chklToos.Items[i].Selected)
                {
                    sb.Append(chklToos.Items[i].Text).Append("|");
                }
            }
            survey.GoodsBring = sb.ToString();
            survey.CustomerCompanyName = customerInfoControl.CompanyName;
            survey.CustomerContactName = customerInfoControl.ContactName;
            survey.CustomerAddress = customerInfoControl.Address;
            survey.CustomerEmail = customerInfoControl.Email;
            survey.CustomerQQ = customerInfoControl.QQ;
            survey.CustomerPhone1 = customerInfoControl.Phone1;
            survey.CustomerPhone2 = customerInfoControl.Phone2;
            survey.CustomerOthers = customerInfoControl.Other;
            
            dal.Save();

            //save new customer
            customerInfoControl.Save();
            this.SetFocus(sender);
        }
	}
}