using System;
using System.Collections.Generic;
using System.Text;
using CursovaApp.Models;
using PZProject.DAL.Models;

namespace CursovaApp.DAL.IRepositories
{
    public interface IRoleRepository: IGenericKeyRepository<int, Role>
    {
    
        List<RoleDTO> GetAllRoles();
        bool AddRole(RoleDTO role);
        bool UpdateRole(RoleDTO role);
        RoleDTO GetRole(string roleName);
        bool DeleteRole(int id);

    }
}
