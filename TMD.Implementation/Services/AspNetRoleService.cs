using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
     public   class AspNetRoleService : IAspNetRoleService
    {

        #region 'Private and Constructor'
        private readonly IAspNetRoleRepository AspNetRoleRepository;


        public AspNetRoleService(IAspNetRoleRepository AspNetRoleRepository)
        {
            this.AspNetRoleRepository = AspNetRoleRepository;
            
        }

        #endregion 'Private and Constructor'

        public string AddRole(AspNetRole AspNetRole)
        {
            AspNetRoleRepository.Add(AspNetRole);
            AspNetRoleRepository.SaveChanges();

            return AspNetRole.Id;
        }

        public string UpdateRole(AspNetRole AspNetRole)
        {
            AspNetRoleRepository.Update(AspNetRole);
            AspNetRoleRepository.SaveChanges();

            return AspNetRole.Id;
        }
        public AspNetRole GetRoleById(string id)
        {
            return AspNetRoleRepository.Find(id);
        }

        public IEnumerable<AspNetRole> GetAllRegisteredRoles()
        {
            return AspNetRoleRepository.GetAll();
        }

         public IEnumerable<AspNetRole> GetAllRolesExceptSuperAdmin()
         {
             return AspNetRoleRepository.GetAllRolesExceptSuperAdmin();
         }
    }
}
