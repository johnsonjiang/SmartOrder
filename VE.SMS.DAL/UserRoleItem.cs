using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class UserRoleItem
    {
        public int UserRole_Id { get; set; }
        public int User_Id { get; set; }
        public int Role_Id { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string RoleName { get; set; }
    }
}
