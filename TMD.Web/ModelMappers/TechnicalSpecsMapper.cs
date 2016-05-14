using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.Models.DomainModels;
using TMD.Web.Models;


namespace TMD.Web.ModelMappers
{
    public static class TechnicalSpecsMapper
    {
        public static TechnicalSpec MapClientToServer(this TMD.Web.Models.TechnicalSpecsModel source)
        {
            return new TechnicalSpec
            {
                TechnicalSpecId = source.TechnicalSpecId,
                SpecName = source.SpecName,
              
                CreatedBy = source.CreatedBy,
                CreatedDate = source.CreatedDate,
                UpdatedBy = source.UpdatedBy,
                UpdatedDate = source.UpdatedDate  

            };
        }
        public static TMD.Web.Models.TechnicalSpecsModel MapServerToClient(this TechnicalSpec source)
        {
            return new TMD.Web.Models.TechnicalSpecsModel
            {

                TechnicalSpecId = source.TechnicalSpecId,
                SpecName = source.SpecName,

                CreatedBy = source.CreatedBy,
                CreatedDate = source.CreatedDate,
                UpdatedBy = source.UpdatedBy,
                UpdatedDate = source.UpdatedDate       

            };
        }
    }
}