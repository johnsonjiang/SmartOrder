using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using VE.SMS.Common;
using VE.SMS.DAL;
using System.Text;

namespace VE.SMS.UI
{
	public partial class ParamEditForm : BasePage
	{
        private string LongMachList { get { return ViewState["LongMachList"] == null ? string.Empty : ViewState["LongMachList"].ToString(); } set { ViewState["LongMachList"] = value; } }
        private string WidthMachList { get { return ViewState["WidthMachList"] == null ? string.Empty : ViewState["WidthMachList"].ToString(); } set { ViewState["WidthMachList"] = value; } }
        private string DeepthMachList { get { return ViewState["DeepthMachList"] == null ? string.Empty : ViewState["DeepthMachList"].ToString(); } set { ViewState["DeepthMachList"] = value; } }
        private string Type { get { return GetQueryStringValue("type"); } }
        private int MIId { get { return int.Parse(GetQueryStringValue("miid")); } }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MachItemDAL dal = new MachItemDAL();
                var machItem = dal.GetMachItemById(MIId);
                LongMachList = machItem.LongMachList;
                WidthMachList = machItem.WidthMachList;
                DeepthMachList = machItem.DeepthMachList;
                BindControl(); 
            }
        }

        public void BindControl()
        {
            var items = Utility.GetMachLookupList();
            Utility.BindDataToRepeater(rpParams, items);
        }

        protected void rpParams_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                MachLookUp item = e.Item.DataItem as MachLookUp;
                int machLookupId = item.Mach_Id;
                CheckBox cbParam = e.Item.FindControl("cbParam") as CheckBox;
                HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
                if (string.Equals(Type, "l", StringComparison.OrdinalIgnoreCase))
                {
                    if (LongMachList.Contains(machLookupId.ToString()))
                    {
                        cbParam.Checked = true;
                    }
                }
                else if (string.Equals(Type, "w", StringComparison.OrdinalIgnoreCase))
                {
                    if (WidthMachList.Contains(machLookupId.ToString()))
                    {
                        cbParam.Checked = true;
                    }
                }
                else if (string.Equals(Type, "d", StringComparison.OrdinalIgnoreCase))
                {
                    if (DeepthMachList.Contains(machLookupId.ToString()))
                    {
                        cbParam.Checked = true;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var result = new StringBuilder();
            var dal = new MachItemDAL();
            var machItem = dal.GetMachItemById(MIId);
            foreach (RepeaterItem item in rpParams.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox cbParam = item.FindControl("cbParam") as CheckBox;
                    HiddenField hdId = item.FindControl("hdId") as HiddenField;
                    if (cbParam.Checked)
                    {
                        result.Append(hdId.Value).Append("|");
                    }
                }
            }
            if (string.Equals(Type, "l", StringComparison.OrdinalIgnoreCase))
            {
                machItem.LongMachList = result.ToString();
            }
            else if (string.Equals(Type, "w", StringComparison.OrdinalIgnoreCase))
            {
                machItem.WidthMachList = result.ToString();
            }
            else if (string.Equals(Type, "d", StringComparison.OrdinalIgnoreCase))
            {
                machItem.DeepthMachList = result.ToString();
            }
            dal.Save();
            this.RegisterClientScriptBlock("closeparam", "<script>closeWindow();</script>");
        }
	}
}