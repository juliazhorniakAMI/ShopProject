using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using CursovaApp.DAL.IRepositories;
using CursovaApp.Models;
using PZProject.DAL.Models;
namespace CursovaApp.DAL.Repositories
{
    public class RoleRepository : GenericKeyRepository<int, Role, ShopPZContext>, IRoleRepository
    {
        private readonly IMapper mapper;
        public RoleRepository(ShopPZContext context, IMapper _mapper) : base(context)
        {
            mapper = _mapper;
        }
        public List<RoleDTO> GetAllRoles()
        {
            return mapper.Map<List<Role>, List<RoleDTO>>((List<Role>)(from role in Context.Roles
                                                                      select role));
        }


        public bool AddRole(RoleDTO role)
        {
          Role r=  mapper.Map<RoleDTO, Role>(role);
            return Add(r);
        }


        public bool UpdateRole(RoleDTO role)
        {
            var existingRole = Context.Roles.First(x => x.Id == role.Id);

            if (existingRole == null) return false;

            existingRole.FullName = role.FullName;

           return Update(existingRole);
        }


        public RoleDTO GetRole(string roleName)
        {
            Role role= Context.Roles.FirstOrDefault(x => x.FullName == roleName);
            return mapper.Map<Role, RoleDTO>(role);
         

        }
        public bool DeleteRole(int id)
        {
            var role = GetById(id);
            return Delete(role);
        }

    }
}
