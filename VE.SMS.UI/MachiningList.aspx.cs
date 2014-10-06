using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using VE.SMS.Common;
using VE.SMS.DAL;
using VE.SMS.UI._UserControl;

namespace VE.SMS.UI
{
	public partial class MachiningList : BasePage
	{
        protected override string ViewName
        {
            get
            {
                return ACLConsts.ViewMachiningList;
            }
        }

		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                Utility.BindDataToDropdown(ddlMachiningStatus, Utility.GetMachiningStatusList(true));
                Utility.BindDataToDropdown(ddlCreator, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlMachMan, Utility.GetUserList2(true));
                Utility.BindDataToDropdown(ddlMachTableMan, Utility.GetUserList2(true));
                Utility.BindDataToRepeater(rpMachiningList, GetMachList());
            }
		}

        private List<Machining> GetMachList()
        {
            MachiningDAL dal = new MachiningDAL();
            var result = dal.SeachMachining(txtMachinineId.Text,
                                            txtOrderId.Text,
                                            Utility.GetSelectedText(ddlCreator),
                                            Utility.GetSelectedText(ddlMachMan),
                                            !string.IsNullOrEmpty(txtExpectedDateBegin.Text) ? DateTime.Parse(txtExpectedDateBegin.Text) : DateTime.MinValue,
                                            !string.IsNullOrEmpty(txtExpectedDateEnd.Text) ? DateTime.Parse(txtExpectedDateEnd.Text) : DateTime.MaxValue,
                                            Utility.GetSelectedText(ddlMachTableMan),
                                            Utility.GetSelectedText(ddlMachiningStatus)
                                            );
            return result;
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Utility.BindDataToRepeater(rpMachiningList, GetMachList());
        }

        protected void rpMachiningList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete" && (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item))
            {
                HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
                new MachiningDAL().Delete(int.Parse(hdId.Value));
                Utility.BindDataToRepeater(rpMachiningList, GetMachList());
            }
            else
            {
                SetSorting(e);
                if (!string.IsNullOrWhiteSpace(SortOrder))
                {
                    Utility.BindDataToRepeater(rpMachiningList, GetMachList().Sort(string.Format("{0} {1}", e.CommandName, SortOrder)));
                }
            }
        }

        protected void rpMachiningList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                FollowUpTop3UserControl followUp = e.Item.FindControl("followUpTop3UserControl") as FollowUpTop3UserControl;
                UIUtility.BindUserControl(followUp, SysConst.SourceTypeMaching, ((Machining)e.Item.DataItem).Mach_No);
            }
        }
	}
}