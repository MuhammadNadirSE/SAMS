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

        public IEnumberable<AspNetRole> GetAllRoles()
        {
            return (IEnumberable<AspNetRole>)AspNetRoleRepository.GetAll();
        }

      


        #endregion 'Private and Constructor'


    }
}
