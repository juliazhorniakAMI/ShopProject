using System;
using System.Collections.Generic;
using System.Text;
using CursovaApp.DAL.IRepositories;
using CursovaApp.Models;

namespace CursovaApp.BLL.Services.Abstract
{
    public class RoleService : IRoleService
    {

        private readonly IRoleRepository _Repository;

        public RoleService(IRoleRepository Repository)
        {
            _Repository = Repository;
        }

        public bool AddRole(RoleDTO role)
        {
            return _Repository.AddRole(role);
        }

        public bool DeleteRole(int id)
        {
            return _Repository.DeleteRole(id);
        }

        public List<RoleDTO> GetAllRoles()
        {
            return _Repository.GetAllRoles();
        }

        public RoleDTO GetRole(string roleName)
        {
            return _Repository.GetRole(roleName);
        }

        public bool UpdateRole(RoleDTO role)
        {
            return _Repository.UpdateRole(role);
        }
    }

}
