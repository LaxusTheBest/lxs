using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using FileManager;

namespace FinalProject
{
    public class CustomRoleProvider : RoleProvider
    {
        RoleService roleService = new RoleService(new RoleRepository());

        UserRepository userRepository = new UserRepository();

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            return userRepository.Get(username).Roles.Select(x => x.Title).ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {            
            var user = userRepository.Get(username);

            if (user != null)
            {
                foreach (Role item in user.Roles)
                {
                    if (item.Title == roleName) return true;
                }
            }

            return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}