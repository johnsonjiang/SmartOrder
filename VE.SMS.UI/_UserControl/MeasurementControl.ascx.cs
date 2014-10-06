using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VE.SMS.UI._UserControl
{
	public class MyClass
	{
		public string Name { get; set; }
		public int Id { get; set; }
	}
	public partial class MeasurementControl : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        public void BindControl()
        {
            List<MyClass> m = new List<MyClass>();
            m.Add(new MyClass() { Id = 1, Name = "abc" });
            m.Add(new MyClass() { Id = 1, Name = "abc" });
            m.Add(new MyClass() { Id = 1, Name = "abc" });
            m.Add(new MyClass() { Id = 1, Name = "abc" });

            this.rpMeasurementList.DataSource = m;
            this.rpMeasurementList.DataBind();
        }
	}
}