using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VE.SMS.DAL
{
    public class UserDAL : BaseDAL
    {
        public User GetUserByNameAndPwd(string name, string pwd)
        {
            return Db.User.FirstOrDefault(u => u.UserName == name && u.Password == pwd && u.IsActive == true);
        }
        public void AddUser(User user)
        {
            user.IsActive = true;
            Db.User.AddObject(user);
        }

        public User GetUserByUserName(string name)
        {
            return Db.User.FirstOrDefault(u => u.UserName == name);
        }
        public User GetUserById(int id)
        {
            return Db.User.SingleOrDefault(u => u.User_Id == id);
        }

        public List<User> SearchUser(string userName, string realName)
        {
            var result = from u in Db.User
                         where
                         (
                         u.UserName == userName
                         ||
                         string.IsNullOrEmpty(userName)
                         )
                         &&
                        (
                         u.RealName == realName
                         ||
                         string.IsNullOrEmpty(realName)
                         )
                         &&
                         u.IsActive == true
                         select u;
            return result.ToList();
        }

        public List<UserRoleItem> GetUserRoleList(int userId, int roleId)
        {
            var result = from u in Db.User
                         join ur in Db.UserRole
                         on u.User_Id equals ur.User_Id
                         join r in Db.Role
                         on ur.Role_Id equals r.Role_Id
                         where
                            u.IsActive == true
                            &&
                            r.IsActive == true
                            &&
                            ur.IsActive == true
                            &&
                            (
                            u.User_Id == userId
                            ||
                            userId == -1
                            )
                            &&
                            (
                            r.Role_Id == roleId
                            ||
                            roleId == -1
                            )
                         select new UserRoleItem() 
                         { 
                            User_Id = u.User_Id,
                            Role_Id = r.Role_Id,
                            UserRole_Id = ur.UserRole_Id,
                            UserName = u.UserName,
                            RealName = u.RealName,
                            RoleName = r.Role_Name
                         };
            return result.ToList();
        }

        public void AddUserRole(int userId, int roleId)
        {
            Db.UserRole.AddObject(new UserRole() { User_Id = userId, Role_Id = roleId, IsActive = true });
            Save();
        }
        public void DeleteUserRole(int userRoleId)
        {
            var userRole = Db.UserRole.SingleOrDefault(ur => ur.UserRole_Id == userRoleId);
            userRole.IsActive = false;
            Save();
        }

        public void AddPermission(int roleId, int permissionId)
        {
            var dbPerm = GetRolePermission(roleId, permissionId);
            if (dbPerm != null && dbPerm.Count > 0)
            {
                return;
            }
            var permission = new RolePermission() {Role_Id = roleId, Permission_Id = permissionId };
            Db.RolePermission.AddObject(permission);
            Save();
        }

        public void DeletePermission(int rolePermId)
        {
            var perm = Db.RolePermission.SingleOrDefault(p=>p.RolePermission_Id == rolePermId);
            Db.RolePermission.DeleteObject(perm);
            Save();
        }

        public List<RolePermissionItem> GetRolePermission(int roleId, int permId)
        {
            var result = from rp in Db.RolePermission
                         join r in Db.Role
                         on rp.Role_Id equals r.Role_Id
                         join p in Db.Permission
                         on rp.Permission_Id equals p.Permission_Id
                         where
                         (
                         r.Role_Id == roleId
                         ||
                         roleId == -1
                         )
                         &&
                         (
                         p.Permission_Id == permId
                         ||
                         permId == -1
                         )
                         &&
                         r.IsActive == true
                         select new RolePermissionItem() 
                         { 
                            Id = rp.RolePermission_Id,
                            PermissionName = p.Permission_Name,
                            RoleName = r.Role_Name
                         };
            return result.ToList();
        }

        public List<Permission> GetPermissionList()
        {
            return Db.Permission.ToList();
        }

        public bool HasPermission(string userName, string name)
        {
            bool hasPermission = false;
            var result = from u in Db.User
                         join ur in Db.UserRole
                         on u.User_Id equals ur.User_Id
                         join r in Db.Role
                         on ur.Role_Id equals r.Role_Id
                         join rp in Db.RolePermission
                         on r.Role_Id equals rp.Role_Id
                         join p in Db.Permission
                         on rp.Permission_Id equals p.Permission_Id
                         where
                            p.Permission_Name == name
                            && u.UserName == userName
                            && u.IsActive == true
                            && ur.IsActive == true
                            && r.IsActive == true
                         select u;
            if (result != null && result.Count() > 0)
            {
                hasPermission = true;
            }
            return hasPermission;
        }
    }
}
