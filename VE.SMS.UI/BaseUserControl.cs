using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VE.SMS.Common;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace  VE.SMS.UI._UserControl 
{
    public class BaseUserControl : System.Web.UI.UserControl
    {
        protected virtual string Name { get { return string.Empty; } }
        public virtual bool Editable { get; set; }
        protected void SetFocus(object control)
        {
            Page.SetFocus(control as Control);
        }
        public string SourceType 
        {
            get
            { return ViewState["SourceType"] == null ? string.Empty : ViewState["SourceType"].ToString(); }
            set 
            {
                ViewState["SourceType"] = value;
            }
        }
        public string SourceNo
        {
            get
            { return ViewState["SourceNo"] == null ? string.Empty : ViewState["SourceNo"].ToString(); }
            set
            {
                ViewState["SourceNo"] = value;
            }
        }

        public int SourceId 
        { 
            get 
            { 
                return ViewState["SourceId"] == null ? -1 : Convert.ToInt32(ViewState["SourceId"]); 
            } 
            set 
            { 
                ViewState["SourceId"] = value; 
            } 
        }

        public virtual void BindControl() { }

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

        protected void SetSorting(object sender)
        {
            var linkButton = sender as LinkButton;
            string sortText = string.Empty;
            if (SortOrder == null || SortBy != linkButton.CommandName)
            {
                SortOrder = "ASC";
                SortBy = linkButton.CommandName;
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
            //linkButton.Text = SortText;
            
        }

    }
}