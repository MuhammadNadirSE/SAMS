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
        private readonly IAspNetRoleRepository aspNetRoleRepository;


        public AspNetRoleService(IAspNetRoleRepository AspNetRoleRepository)
        {
            this.aspNetRoleRepository = AspNetRoleRepository;
            
        }

        #endregion 'Private and Constructor'

        public string AddRole(AspNetRole AspNetRole)
        {
            aspNetRoleRepository.Add(AspNetRole);
            aspNetRoleRepository.SaveChanges();

            return AspNetRole.Id;
        }

        public string UpdateRole(AspNetRole AspNetRole)
        {
            aspNetRoleRepository.Update(AspNetRole);
            aspNetRoleRepository.SaveChanges();

            return AspNetRole.Id;
        }
        public string GetLatestAvailableRoleId()
        {
            return aspNetRoleRepository.GetLatestAvailableRoleId();
        }
        public AspNetRole GetRoleById(string id)
        {
            return aspNetRoleRepository.Find(id);
        }

        public IEnumerable<AspNetRole> GetAllRegisteredRoles()
        {
            return aspNetRoleRepository.GetAll();
        }

         public IEnumerable<AspNetRole> GetAllRolesExceptSuperAdmin()
         {
             return aspNetRoleRepository.GetAllRolesExceptSuperAdmin();
         }
    }
}
