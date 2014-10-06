using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VE.SMS.UI
{
    public partial class Error : System.Web.UI.Page
    {
        protected string EX { get { return "System can't access database file, There maybe bad sectors on hard driver, please contact your administrator."; } }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}