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
	public partial class SystemConfiguration : BasePage
	{
        protected override string ViewName
        {
            get
            {
                return ACLConsts.ViewSystemConfiguration;
            }
        }
        protected override string EditName
        {
            get
            {
                return ACLConsts.EditSystemConfiguration;
            }
        }
		private int CurrentGroupId
		{
			get
			{
				return ViewState["CurrentGroupId"] == null ? -1 : Convert.ToInt32(ViewState["CurrentGroupId"]);
			}
			set
			{
				ViewState["CurrentGroupId"] = value;
			}
		}
		protected string CurrentGroupName
		{
			get
			{
				return ViewState["CurrentGroupName"] == null ? string.Empty : ViewState["CurrentGroupName"].ToString();
			}
			set
			{
				ViewState["CurrentGroupName"] = value;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				BindTreeView();
			}
		}

		public void BindTreeView()
		{
            trvConfig.Nodes.Clear();
			TreeNode root = new TreeNode() {Text="系统基本信息" };
			trvConfig.Nodes.Add(root);

			ConfigDAL dal = new ConfigDAL();
			var allConfig = dal.GetAllConfigGroup();
			foreach (var item in allConfig)
			{
				root.ChildNodes.Add(new TreeNode() { Text = item.ConfigGroup_Name, Value = item.ConfigGroup_Id.ToString() });
			}
			trvConfig.ExpandAll();

			if (CurrentGroupId > 0 && !string.IsNullOrEmpty(CurrentGroupName) )
			{
				ConfigItemDAL itemDAL = new ConfigItemDAL();
				Utility.BindDataToRepeater(rpConfigItemList, itemDAL.GetConfigByGroup(CurrentGroupId));
			}
		}

		protected void btnAdd_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtGroupName.Text))
			{
				ConfigDAL dal = new ConfigDAL();
				if (!dal.GetAllConfigGroup().Exists(c => c.ConfigGroup_Name == txtGroupName.Text))
				{
					dal.AddConfigGroup(new ConfigGroup() { ConfigGroup_Name = txtGroupName.Text });
					dal.Save();
				}
				BindTreeView();
			}
		}

		protected void trvConfig_SelectedNodeChanged(object sender, EventArgs e)
		{
			TreeNode node = trvConfig.SelectedNode;
			if (node != null && node.Parent != null)
			{
				CurrentGroupId = int.Parse(node.Value);
				CurrentGroupName = node.Text;
				ConfigDAL dal = new ConfigDAL();
				Utility.BindDataToRepeater(rpConfigItemList, dal.GetConfigByGroup(CurrentGroupId));
			}
		}

		protected void rpConfigItemList_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
            ConfigItemDAL dal = new ConfigItemDAL();
			if (e.CommandName == "Add")
			{
				if (e.Item.ItemType == ListItemType.Header)
				{
					TextBox txtIdentity = e.Item.FindControl("txtIdentityAdd") as TextBox;
					TextBox txtValue = e.Item.FindControl("txtValueAdd") as TextBox;
                    CheckBox chkDefaultAdd = e.Item.FindControl("chkDefaultAdd") as CheckBox;

					if (!string.IsNullOrEmpty(txtIdentity.Text) 
						&& !string.IsNullOrEmpty(txtValue.Text)
						&& CurrentGroupId > 0)
					{
						ConfigItem item = new ConfigItem() 
						{ 
							ConfigGroup_Id = CurrentGroupId,
							ConfigItem_Key = txtIdentity.Text,
							ConfigItem_Value = txtValue.Text,
                            IsDefault = chkDefaultAdd.Checked
						};
						dal.AddConfigItem(item);
						dal.Save();
                        ConfigItemDAL itemDAL = new ConfigItemDAL();
                        Utility.BindDataToRepeater(rpConfigItemList, itemDAL.GetConfigByGroup(CurrentGroupId));
					}
				}
			}
            if (e.CommandName == "Save")
            {
                HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
                TextBox txtIdentity = e.Item.FindControl("txtIdentity") as TextBox;
                TextBox txtValue = e.Item.FindControl("txtValue") as TextBox;
                CheckBox chkDefault = e.Item.FindControl("chkDefault") as CheckBox;

                var item = dal.GetConfigItemById(int.Parse(hdId.Value));
                item.ConfigItem_Key = txtIdentity.Text;
                item.ConfigItem_Value = txtValue.Text;
                item.IsDefault = chkDefault.Checked;
                dal.Save();
            }
            if (e.CommandName == "Delete")
            {
                HiddenField hdId = e.Item.FindControl("hdId") as HiddenField;
                
                dal.Delete(int.Parse(hdId.Value));
            }
            Utility.BindDataToRepeater(rpConfigItemList, dal.GetConfigByGroup(CurrentGroupId));
            
		}
	}
}