using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AjaxControlToolkit;
using System.Collections.Specialized;
using VE.SMS.DAL;

namespace VE.SMS.UI
{
    /// <summary>
    /// Summary description for GinyeeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class GinyeeService : System.Web.Services.WebService
    {

        [WebMethod]
        public CascadingDropDownNameValue[] GetProjects(
          string knownCategoryValues,
          string category)
        {
            List<CascadingDropDownNameValue> result = new List<CascadingDropDownNameValue>();
            var projects = VE.SMS.Common.Utility.GetProjectList();
            foreach (var item in projects)
            {
                result.Add(new CascadingDropDownNameValue(
                  item.Name, item.Value));
            }
            return result.ToArray();
        }

        [WebMethod]
        public CascadingDropDownNameValue[] GetProductByProject(
          string knownCategoryValues,
          string category)
        {
            StringDictionary categoryValues = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            string project = categoryValues["Project"];

            List<CascadingDropDownNameValue> result = new List<CascadingDropDownNameValue>();
            if (string.Equals(project, "Mach", StringComparison.OrdinalIgnoreCase))
            {
                MachLookupDAL dal = new MachLookupDAL();
                var machs = dal.GetAllMach();
                foreach (var item in machs)
                {
                    result.Add(new CascadingDropDownNameValue() {name=item.Name,value=item.Mach_Id.ToString() });
                }
            }
            else if (string.Equals(project, "Install", StringComparison.OrdinalIgnoreCase))
            {
                InstallLookupDAL dal = new InstallLookupDAL();
                var installs = dal.GetAllLookup();
                foreach (var item in installs)
                {
                    result.Add(new CascadingDropDownNameValue() { name = item.Name, value = item.Install_Id.ToString() });
                }
            }
            else if (string.Equals(project, "Product", StringComparison.OrdinalIgnoreCase))
            {
                ProductDAL dal = new ProductDAL();
                var products = dal.GetAllProducts();
                foreach (var item in products)
                {
                    result.Add(new CascadingDropDownNameValue() { name = item.Product_Name, value = item.Product_Id.ToString()});
                }
            }
            else if (string.Equals(project, "EndProduct", StringComparison.OrdinalIgnoreCase))
            {
                EndProductDAL dal = new EndProductDAL();
                var endProducts = dal.GetAllEndProductList();
                foreach (var item in endProducts)
                {
                    result.Add(new CascadingDropDownNameValue() { name = item.Name, value = item.EP_Id.ToString() });
                }
            }

            return result.ToArray();
        }

    }
}
