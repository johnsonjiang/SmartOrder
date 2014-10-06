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
    public partial class CADFileListControl : BaseUserControl
    {
        public string RefineNo
        {
            get { return ViewState["RefineNo"] == null ? string.Empty : ViewState["RefineNo"].ToString(); }
            set { ViewState["RefineNo"] = value; }
        }
        public int RefineId
        {
            get { return ViewState["RefineId"] == null ? -1 : Convert.ToInt32(ViewState["RefineId"]); }
            set { ViewState["RefineId"] = value; }
        }
        public bool Editable
        {
            get { return this.divOperate.Visible; }
            set { this.divOperate.Visible = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public override void BindControl()
        {
            RefineItemDAL dal = new RefineItemDAL();
            Utility.BindDataToRepeater(rpCADFile, dal.GetRefineItemByRefineId(RefineId));
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(fileUploadDrawing.FileName))
            {
                string serverFilePath = string.Empty;
                Utility.UploadFile(fileUploadDrawing, "RefineCAD", SourceNo, ref serverFilePath);
                RefineItem item = new RefineItem() 
                { 
                    Refine_Id = RefineId,
                    CreatedAt = DateTime.Now,
                    CreatedBy = SMSContext.Current.User.UserName,
                    RefineFileName = Utility.GetFileName(fileUploadDrawing),
                    RefineFilePath = serverFilePath,
                    RefineItemDate = DateTime.Now,
                    Intro = txtIntro.Text
                };

                RefineItemDAL dal = new RefineItemDAL();
                dal.AddRefineItem(item);
                dal.Save();
                BindControl();
            }
            SetFocus(sender);
        }
    }
}