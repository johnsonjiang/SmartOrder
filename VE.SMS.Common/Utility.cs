using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Text;
using System;
using System.Web;
using VE.SMS.DAL;
using System.Linq;
using System.Xml.Linq;

namespace VE.SMS.Common
{
    public static class Utility
    {
        private static Dictionary<string, List<NameValueItem>> StatusMap = new Dictionary<string, List<NameValueItem>>();
        private static void Initialize()
        {
            StatusMap.Clear();
            string xmlPath = HttpContext.Current.Server.MapPath("~/data.xml");

            var statusGroups = from g in XElement.Load(xmlPath).Elements("statusgroup")
                               select g;
            foreach (var sgroup in statusGroups)
            {
                if (!StatusMap.ContainsKey(sgroup.Attribute("name").Value))
                {
                    var list = (from s in sgroup.Elements()
                                select new NameValueItem() { Name = s.Attribute("key").Value, Value = s.Attribute("value").Value }).ToList();
                    StatusMap.Add(sgroup.Attribute("name").Value, list);
                }
            }
        }
        static Utility()
        {
            Initialize();
        }

        public static double Round(double amount)
        {
            return Math.Round(amount, 2);
        }

        public static double Round(object amount)
        {
            return Math.Round(Convert.ToDouble(amount), 2);
        }

        public static List<ConfigItem> GetColorList()
        {
            return GetLookupList("颜色");
        }

        public static List<ConfigItem> GetColorList(bool addEmpty)
        {
            var result = GetColorList();
            if (addEmpty)
            {
                result.Insert(0, new ConfigItem() { ConfigItem_Key = string.Empty, ConfigItem_Value = string.Empty });
            }
            return result;
        }

        public static void AddDefault(string sourceNo, string sourceType, string formType)
        {
            FooterDAL dal = new FooterDAL();
            var defaultItems = Utility.GetLookupList(formType).Where(f => f.IsDefault == true);
            foreach (var item in defaultItems)
            {
                Footer footer = new Footer() { Intro = item.ConfigItem_Value, SourceNo = sourceNo, SourceType = sourceType};
                dal.AddFooter(footer);
            }
            dal.Save();
        }

        public static List<ConfigItem> GetLookupList(string name, bool addEmpty)
        {
            var result = GetLookupList(name);
            if (addEmpty)
            {
                result.Insert(0, new ConfigItem() { ConfigItem_Key = string.Empty, ConfigItem_Value = string.Empty });
            }
            return result;
        }
        public static List<ConfigItem> GetLookupList(int groupId)
        {
            ConfigItemDAL dal = new ConfigItemDAL();
            return dal.GetConfigByGroup(groupId);
        }

        public static List<ConfigItem> GetLookupList(string name)
        {
            ConfigItemDAL dal = new ConfigItemDAL();
            return dal.GetConfigByGroup(name);
        }

        public static ConfigItem GetScalarItem(int groupId)
        {
            ConfigItem item = null;
            var list = GetLookupList(groupId);
            if (list != null && list.Count > 0)
            {
                item = list[0];
            }
            return item;
        }

        public static ConfigItem GetScalarItem(string groupName)
        {
            ConfigItem item = null;
            var list = GetLookupList(groupName);
            if (list != null && list.Count > 0)
            {
                item = list[0];
            }
            return item;
        }

        public static string GetFileName(FileUpload fileUpload)
        {
            string filePath = fileUpload.PostedFile.FileName.ToString();
            string fileName = filePath.Substring(filePath.LastIndexOf(@"\") + 1);
            return fileName;
        }

        public static bool UploadFile(FileUpload fileUpload, string category, string sourceNo, ref string serverFilePath)
        {
            bool result = false;
            if (fileUpload.PostedFile != null)
            {
                //获取文件名路径
                string filePath = fileUpload.PostedFile.FileName.ToString();

                //获取扩展名//
                string fileExt = filePath.Substring(filePath.LastIndexOf(@"."));

                string fileName = filePath.Substring(filePath.LastIndexOf(@"\") + 1);

                string frontFileName = string.Format("{0}_{1}_{2}", sourceNo, DateTime.Now.ToString("yyyyMMdd"), fileName);
                filePath = string.Format("_Files/{0}/{1}", category, frontFileName);

                try
                {
                    //文件保存
                    fileUpload.PostedFile.SaveAs(HttpContext.Current.Server.MapPath(filePath));
                    result = true;
                    serverFilePath = filePath;
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }

        public static string GetSelectedText(DropDownList dropdown)
        {
            string text = string.Empty;
            if (dropdown.SelectedItem != null)
            {
                text = dropdown.SelectedItem.Text;
            }
            return text;
        }

        public static string GetSelectedValue(DropDownList dropdown)
        {
            string text = string.Empty;
            if (dropdown.SelectedItem != null)
            {
                text = dropdown.SelectedValue;
            }
            return text;
        }

        public static void BindDataToCheckBoxList(CheckBoxList cbl, List<ConfigItem> dataSource)
        {
            cbl.DataSource = dataSource;
            cbl.DataTextField = "ConfigItem_Key";
            cbl.DataValueField = "ConfigItem_Key";
            cbl.DataBind();
        }
        public static void BindDataToRepeater(Repeater repeater, object dataSource)
        {
            repeater.DataSource = dataSource;
            repeater.DataBind();
        }

        public static void BindDataToDropdown(DropDownList dropdown, IEnumerable<string> list)
        {
            dropdown.Items.Clear();
            foreach (var item in list)
            {
                dropdown.Items.Add(new ListItem() { Text = item, Value = item });
            }
        }

        public static void BindDataToDropdown(DropDownList dropdown, IEnumerable<NameValueItem> list)
        {
            dropdown.DataSource = list;
            dropdown.DataTextField = "Name";
            dropdown.DataValueField = "Value";
            dropdown.DataBind();
        }

        public static void BindDataToDropdown(DropDownList dropdown, List<ConfigItem> list)
        {
            dropdown.DataSource = list;
            dropdown.DataTextField = "ConfigItem_Key";
            dropdown.DataValueField = "ConfigItem_Key";
            dropdown.DataBind();
        }

        public static void BindDataValueToDropdown(DropDownList dropdown, List<ConfigItem> list)
        {
            dropdown.DataSource = list;
            dropdown.DataTextField = "ConfigItem_Key";
            dropdown.DataValueField = "ConfigItem_Value";
            dropdown.DataBind();
        }

        public static List<NameValueItem> GetEnquiryStatusList()
        {
            StatusMap.Clear();
            if (!StatusMap.ContainsKey("enquiry"))
            {
                Initialize();
            }
            return StatusMap["enquiry"];
        }

        public static List<NameValueItem> GetEnquiryStatusList(bool addEmpty)
        {
            var result = GetEnquiryStatusList();
            if (addEmpty)
            {
                result.Insert(0, new NameValueItem() { Name = string.Empty, Value = string.Empty });
            }
            return result;

        }

        public static List<NameValueItem> GetSurveyStatusList()
        {
            StatusMap.Clear();
            if (!StatusMap.ContainsKey("survey"))
            {
                Initialize();
            }
            return StatusMap["survey"];
        }

        public static List<NameValueItem> GetSurveyStatusList(bool addEmptyItem)
        {
            var result = GetSurveyStatusList();
            if (addEmptyItem)
            {
                result.Insert(0, new NameValueItem() { Name = string.Empty, Value = string.Empty });
            }
            return result;
        }

        public static List<NameValueItem> GetRefineStatusList()
        {
            StatusMap.Clear();
            if (!StatusMap.ContainsKey("refine"))
            {
                Initialize();
            }
            return StatusMap["refine"];
        }

        public static List<NameValueItem> GetRefineStatusList(bool addEmptyItem)
        {
            var list = GetRefineStatusList();
            if (addEmptyItem)
            {
                list.Insert(0, new NameValueItem() { Name = string.Empty, Value = string.Empty });
            }
            return list;
        }

        public static List<NameValueItem> GetMachiningStatusList()
        {
            StatusMap.Clear();
            if (!StatusMap.ContainsKey("mach"))
            {
                Initialize();
            }
            return StatusMap["mach"];
        }

        public static List<NameValueItem> GetMachiningStatusList(bool addEmpty)
        {
            var list = GetMachiningStatusList();
            if (addEmpty)
            {
                list.Insert(0, new NameValueItem(){Name=string.Empty,Value=string.Empty});
            }
            return list;

        }

        public static List<NameValueItem> GetSettlementStatusList()
        {
            StatusMap.Clear();
            if (!StatusMap.ContainsKey("settlement"))
            {
                Initialize();
            }
            return StatusMap["settlement"];
        }

        public static List<NameValueItem> GetSettlementStatusList(bool addEmpty)
        {
            var list = GetSettlementStatusList();
            if (addEmpty)
            {
                list.Insert(0, new NameValueItem() { Name = string.Empty, Value = string.Empty });
            }
            return list;
        }

        public static List<NameValueItem> GetOrderStatusList()
        {
            StatusMap.Clear();
            if (!StatusMap.ContainsKey("order"))
            {
                Initialize();
            }
            return StatusMap["order"];
        }

        public static List<NameValueItem> GetOrderStatusList(bool addEmptyItem)
        {
            var result = GetOrderStatusList();
            if (addEmptyItem)
            {
                result.Insert(0, new NameValueItem() { Name = string.Empty, Value = string.Empty });
            }
            return result;
        }

        public static List<NameValueItem> GetDeliveryStatusList()
        {
            StatusMap.Clear();
            if (!StatusMap.ContainsKey("delivery"))
            {
                Initialize();
            }
            return StatusMap["delivery"];
        }

        public static List<NameValueItem> GetDeliveryStatusList(bool addEmpty)
        {
            var list = GetDeliveryStatusList();
            if (addEmpty)
            {
                list.Insert(0, new NameValueItem() { Name = string.Empty, Value = string.Empty });
            }
            return list;
        }

        public static List<NameValueItem> GetQuotationStatusList()
        {
            StatusMap.Clear();
            if (!StatusMap.ContainsKey("quotation"))
            {
                Initialize();
            }
            return StatusMap["quotation"];
        }

        public static List<NameValueItem> GetQuotationStatusList(bool addEmpty)
        {
            var result = GetQuotationStatusList();
            if (addEmpty)
            {
                result.Insert(0, new NameValueItem() { Name = string.Empty, Value = string.Empty });
            }
            return result;

        }

        public static List<NameValueItem> GetPurchaseStatusList(bool addEmpty)
        {
            var result = GetPurchaseStatusList();
            if (addEmpty)
            {
                result.Insert(0, new NameValueItem() { Name = string.Empty, Value = string.Empty });
            }
            return result;
        }

        public static List<NameValueItem> GetPurchaseStatusList()
        {
            StatusMap.Clear();
            if (!StatusMap.ContainsKey("purchase"))
            {
                Initialize();
            }
            return StatusMap["purchase"];
        }

        public static List<NameValueItem> GetUserList()
        {
            UserDAL dal = new UserDAL();
            var users = dal.SearchUser(string.Empty, string.Empty).AsQueryable<User>();
            var result = from u in users
                         select new NameValueItem() 
                         { 
                            Name = string.Format("{0}/{1}",u.UserName, u.RealName),
                            Value = u.User_Id.ToString()
                         };
            return result.ToList();
        }

        public static List<NameValueItem> GetUserList(bool addEmpty)
        {
            var result = GetUserList();
            if (addEmpty)
            {
                result.Insert(0, new NameValueItem() { Name = string.Empty, Value = string.Empty });
            }
            return result;
        }

        public static List<NameValueItem> GetUserList2()
        {
            UserDAL dal = new UserDAL();
            var users = dal.SearchUser(string.Empty, string.Empty).AsQueryable<User>();
            var result = from u in users
                         select new NameValueItem()
                         {
                             Name = u.RealName,
                             Value = u.RealName
                         };
            return result.ToList();
        }

        public static List<NameValueItem> GetUserList2(bool addEmptyItem)
        {
            var result = GetUserList2();
            if (addEmptyItem)
            {
                result.Insert(0, new NameValueItem() { Name = string.Empty, Value = string.Empty });
            }
            return result.ToList();
        }

        public static List<NameValueItem> GetRoleList()
        {
            RoleDAL dal = new RoleDAL();
            var roles = dal.SearchRole(string.Empty).AsQueryable<Role>();
            var result = from r in roles
                         select new NameValueItem()
                         {
                             Name = r.Role_Name,
                             Value = r.Role_Id.ToString()
                         };
            return result.ToList();
        }
        public static List<NameValueItem> GetRoleList(bool addEmpty)
        {
            var result = GetRoleList();
            if (addEmpty)
            {
                result.Insert(0, new NameValueItem() { Name = string.Empty, Value = string.Empty });
            }
            return result;
        }

        public static List<NameValueItem> GetPermissionList()
        {
            UserDAL dal = new UserDAL();
            var permissions = dal.GetPermissionList();
            var result = from p in permissions
                         select new NameValueItem()
                         {
                             Name = p.Permission_Name,
                             Value = p.Permission_Id.ToString()
                         };
            return result.ToList();
        }

        public static List<NameValueItem> GetPermissionList(bool addEmpty)
        {
            var result = GetPermissionList();
            if (addEmpty)
            {
                result.Insert(0, new NameValueItem() { Name = string.Empty, Value = string.Empty });
            }
            return result;
        }

        public static IEnumerable<NameValueItem> GetProductList()
        {
            ProductDAL dal = new ProductDAL();
            return from p in dal.GetAllProducts()
                   orderby p.Product_Id
                   select new NameValueItem() { Name = p.Product_Name + "/" + p.Product_Code, Value = p.Product_Id.ToString() };
        }

        public static IEnumerable<NameValueItem> GetEndProductList()
        {
            EndProductDAL dal = new EndProductDAL();
            return from ep in dal.GetAllEndProductList()
                   orderby ep.Name
                   select new NameValueItem() { Name = ep.Name + "/" + ep.Code, Value = ep.EP_Id.ToString() };
        }

        public static List<NameValueItem> GetSupplierNameList()
        {
            SupplierDAL dal = new SupplierDAL();
            var suppliers = dal.GetSupplierList();
            var result = from s in suppliers
                         orderby s.Supplier_Name
                         select new NameValueItem()
                         {
                             Name = s.Supplier_Name,
                             Value = s.Supplier_Name
                         };
            return result.ToList();
        }

        public static List<NameValueItem> GetSupplierNameList(bool addEmpty)
        {
            var result = GetSupplierNameList();
            if (addEmpty)
            {
                result.Insert(0, new NameValueItem() { Name = string.Empty, Value = string.Empty });
            }
            return result;
        }

        public static List<NameValueItem> GetProjectList()
        {
            List<NameValueItem> list = new List<NameValueItem>();
            list.Add(new NameValueItem() { Name = "加工", Value = "加工" });
            list.Add(new NameValueItem() { Name = "安装", Value = "安装" });
            list.Add(new NameValueItem() { Name = "材料", Value = "材料" });
            list.Add(new NameValueItem() { Name = "成品", Value = "成品" });
            return list;
        }

        public static List<ConfigItem> GetUnitTypeList()
        {
            List<NameValueItem> list = new List<NameValueItem>();
            return GetLookupList("单位");
        }

        public static List<MachLookUp> GetMachLookupList()
        {
            return new MachLookupDAL().GetAllMach();
        }
        public static List<NameValueItem> GetMachTypeList()
        {
            MachLookupDAL dal = new MachLookupDAL();
            var result = from m in dal.GetAllMach()
                         select new NameValueItem() 
                         { 
                            Name = m.Name,
                            Value= m.Mach_Id.ToString()
                         };
            return result.ToList();
        }

        public static List<NameValueItem> GetCompanyList()
        {
            CustomerDAL dal = new CustomerDAL();
            var customers = dal.GetAllCustomer();
            var result = from c in customers
                         orderby c.CustomerCompanyName
                         where !string.IsNullOrEmpty(c.CustomerCompanyName)
                         select new NameValueItem()
                         {
                             Name = c.CustomerCompanyName,
                             Value = c.CustomerCompanyName
                         };
            return result.ToList();
        }

        public static List<NameValueItem> GetCompanyList(bool addEmptyItem)
        {
            var result = GetCompanyList();
            if (addEmptyItem)
            {
                result.Insert(0, new NameValueItem() { Name = string.Empty, Value = string.Empty });
            }
            return result;
        }

        public static List<NameValueItem> GetContactList()
        {
            CustomerDAL dal = new CustomerDAL();
            var customers = dal.GetAllCustomer();
            var result = from c in customers
                         orderby c.ContactName
                         where !string.IsNullOrEmpty(c.ContactName)
                         select new NameValueItem() 
                         { 
                            Name = c.ContactName,
                            Value=c.ContactName
                         };
            return result.ToList();
        }
        public static List<NameValueItem> GetContactList(bool addEmptyItem)
        {
            var result = GetContactList();
            if (addEmptyItem)
            {
                result.Insert(0, new NameValueItem() { Name = string.Empty, Value = string.Empty });
            }
            return result;
        }


        public static Order GenerateOrder(Quotation quote)
        {
            Order ord = new Order();
            SeedDAL sdal = new SeedDAL();
            var ordNo = sdal.GetNoByTableName(SysConst.TableOrder, SysConst.SuffixOrder);

            ord.Order_No = ordNo;
            ord.SourceNo = quote.Quotation_No;
            ord.SourceType = SysConst.SourceTypeQuote;
            ord.CADRefinementIntro = quote.CADRefinementIntro;
            ord.CreatedDate = quote.CreatedDate;
            ord.CustomerAddress = quote.CustomerAddress;
            ord.CustomerCompanyName = quote.CustomerCompanyName;
            ord.CustomerContactName = quote.CustomerContactName;
            ord.CustomerEmail = quote.CustomerEmail;
            ord.CustomerOthers = quote.CustomerOthers;
            ord.CustomerPhone1 = quote.CustomerPhone1;
            ord.CustomerPhone2 = quote.CustomerPhone2;
            ord.CustomerQQ = quote.CustomerQQ;
            ord.DeliveryIntro = quote.DeliveryIntro;
            ord.DeliveryToAddress = quote.DeliveryToAddress;
            ord.DeliveryType = quote.DeliveryType;
            ord.InstallIntro = quote.InstallIntro;
            ord.InstallType = string.IsNullOrEmpty(quote.InstallType) ? string.Empty : quote.InstallType;
            ord.IsCADNeedCustomerConfirmation = quote.IsCADNeedCustomerConfirmation;
            ord.IsCADRefinementNeeded = quote.IsCADRefinementNeeded;
            ord.IsCustomerProvideImage = quote.IsCustomerProvideImage;
            ord.IsCustomerProvideSample = quote.IsCustomerProvideSample;
            ord.IsInstallProvided = quote.IsInstallProvided;
            ord.IsSampleProvidedToCustomer = quote.IsSampleProvidedToCustomer;
            ord.IsSurveyNeeded = quote.IsSurveyNeeded;
            ord.OrderIntro = quote.QuotationIntro;
            ord.OrderMan= quote.QuotationMan;
            ord.Status = FirstStatusConsts.Order;
            ord.SurveyIntro = quote.SurveyIntro;
            ord.SurveyType = quote.SurveyType;
            ord.EnqNo = quote.EnqNo;
            ord.IsActive = true;
            OrderDAL dal = new OrderDAL();
            dal.AddOrder(ord);
            dal.Save();

            LineItemDAL lDal = new LineItemDAL();
            var items = lDal.GetLineItemsBySource(quote.Quotation_Id, SysConst.SourceTypeQuote);
            
            foreach (var item in items)
            {
                var newOrderItem = new LineItem() 
                { 
                    Intro = item.Intro,
                    Name = item.Name,
                    Project = item.Project,
                    Quantity = item.Quantity,
                    Remark = item.Remark,
                    SourceId = ord.Order_Id,
                    SourceType = SysConst.SourceTypeOrder,
                    Spec = item.Spec,
                    Unit = item.Unit,
                    UnitPrice = item.UnitPrice
                };

                lDal.AddLineItem(newOrderItem);
            }
            lDal.Save();
            Utility.AddDefault(ord.Order_No, SysConst.SourceTypeOrder, FooterConsts.Order);
            return ord;
        }

    }
}
