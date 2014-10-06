using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class RoleDAL : BaseDAL
    {
        public void AddRole(Role role)
        {
            role.IsActive = true;
            Db.Role.AddObject(role);
        }

        public List<Role> SearchRole(string roleName)
        {
            return Db.Role.Where(r => (r.Role_Name == roleName ||string.IsNullOrEmpty(roleName)) && r.IsActive == true).ToList();
        }

        public void DeleteRole(int roleId)
        {
            var role = Db.Role.SingleOrDefault(r => r.Role_Id == roleId);
            role.IsActive = false;
            Save();
        }
    }
}
