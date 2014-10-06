using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using VE.SMS.Common;
using VE.SMS.UI._UserControl;

namespace VE.SMS.UI
{
    public class BasePage : System.Web.UI.Page
    {
        protected virtual string ViewName { get { return string.Empty; } }
        protected virtual string EditName { get { return string.Empty; } }
        protected string SourceType { get { return GetQueryStringValue(SysConst.KeySourceType).ToUpper(); } }
        protected string SourceNo { get { return GetQueryStringValue(SysConst.KeySourceNo); } }

        protected void SetControlsStatus(bool enabled)
        {
            for (int i = 0; i < Page.Controls.Count; i++)
            {
                SetStatus(Page.Controls[i], enabled);
            }
        }

        protected void SetControlEnabled(WebControl control, bool enabled)
        {
            control.Enabled = enabled;
        }

        protected void SetStatus(Control control, bool enabled)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                if (control.Controls[i] is WebControl)
                {
                    ((WebControl)control.Controls[i]).Enabled = enabled;
                }
                SetStatus(control.Controls[i], enabled);
            }
        }

        protected void AddFollowUp(FollowUpControl followUpControl, string oldStatus, string newStatus)
        {
            if (!string.Equals(oldStatus, newStatus, StringComparison.OrdinalIgnoreCase))
            {
                followUpControl.AddFollowUp(string.Format("状态由{0}改变为{1}", oldStatus, newStatus));
            }
        }
        protected override void OnInit(EventArgs e)
        {
            if (!ACLUtility.GetMonitorSignal())
            {
                Response.Redirect(Page.ResolveUrl("~/Error.aspx"), true);
            }

            if (SMSContext.Current.User == null)
            {
                Response.Redirect(Page.ResolveUrl("~/login.aspx"),true);
            }
            else
            {
                if (!string.IsNullOrEmpty(ViewName))
                {
                    if (!ACLUtility.IsAccessible(ViewName))
                    {
                        Response.Redirect(Page.ResolveUrl("~/Forbidden.aspx"), true);
                    }
                    else if (!string.IsNullOrEmpty(EditName) && !ACLUtility.IsAccessible(EditName))
                    {
                        SetControlsStatus(false);
                    }
                }
            }
            base.OnInit(e);
        }
        protected string GetQueryStringValue(string queryKey)
        { 
            return Request.QueryString[queryKey];
        }

        protected void SetFocus(object control)
        {
            base.SetFocus(control as Control);
        }
        protected string SortOrder
        {
            get
            {
                return ViewState["SortOrder"] == null ? string.Empty : ViewState["SortOrder"].ToString();
            }
            set
            {
                ViewState["SortOrder"] = value;
            }
        }
        protected string SortBy
        {
            get
            {
                return ViewState["SortBy"] == null ? string.Empty : ViewState["SortBy"].ToString();
            }
            set
            {
                ViewState["SortBy"] = value;
            }
        }

        protected string SortText
        {
            get
            {
                return ViewState["SortText"] == null ? string.Empty : ViewState["SortText"].ToString();
            }
            set
            {
                ViewState["SortText"] = value;
            }
        }

        protected void SetSorting(RepeaterCommandEventArgs e)
        {
            var linkButton = (LinkButton)e.Item.FindControl(e.CommandName.Trim());
            if (e.Item.ItemType == ListItemType.Header)
            {
                string sortText = string.Empty;
                if (SortOrder == null || SortBy != e.CommandName)
                {
                    SortOrder = "ASC";
                    SortBy = e.CommandName;
                    sortText = linkButton.Text + "▲";
                }
                else
                {
                    SortOrder = SortOrder == "ASC" ? "DESC" : "ASC";
                    if (linkButton.Text.IndexOf("▲") == -1)
                    {
                        if (linkButton.Text.IndexOf("▼") == -1)
                            sortText = linkButton.Text + "▲";
                        else
                            sortText = linkButton.Text.Replace("▼", "▲");
                    }
                    else
                    {
                        sortText = linkButton.Text.Replace("▲", "▼");
                    }
                }
                SortText = sortText;
                linkButton.Text = SortText;
            }
        }
    }
}