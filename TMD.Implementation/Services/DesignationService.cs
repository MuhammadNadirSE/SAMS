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
     public   class DesignationService : IDesignationService
    {

        #region 'Private and Constructor'
        private readonly IDesignationRepository DesignationRepository;


        public DesignationService(IDesignationRepository DesignationRepository)
        {
            this.DesignationRepository = DesignationRepository;
            
        }

 
        public IEnumerable<Designation> GetAllDesignations()
        {
            return DesignationRepository.GetAll();
        }

        #endregion 'Private and Constructor'


    }
}
