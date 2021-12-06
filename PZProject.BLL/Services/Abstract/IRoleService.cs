using System;
using System.Collections.Generic;
using System.Text;
using CursovaApp.Models;

namespace CursovaApp.BLL.Services.Abstract
{
    public interface IRoleService
    {
        List<RoleDTO> GetAllRoles();
        bool AddRole(RoleDTO role);
        bool UpdateRole(RoleDTO role);
        RoleDTO GetRole(string roleName);
        bool DeleteRole(int id);
    }
}
