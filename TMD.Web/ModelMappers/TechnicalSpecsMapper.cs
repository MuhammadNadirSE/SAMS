using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class TechnicalSpecsMapper
    {
        public static TechnicalSpec MapClientToServer(this TechnicalSpecsModel source)
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
        public static TechnicalSpecsModel MapServerToClient(this TechnicalSpec source)
        {
            return new TechnicalSpecsModel
            {

                TechnicalSpecId = source.TechnicalSpecId,
                SpecName = source.SpecName,

                CreatedBy = source.CreatedBy,
                CreatedDate = source.CreatedDate,
                UpdatedBy = source.UpdatedBy,
                UpdatedDate = source.UpdatedDate
            };
        }
        public static TechnicalSpecsModel CreateDropDownList(this TechnicalSpec source)
        {
            return new TechnicalSpecsModel
            {
                TechnicalSpecId = source.TechnicalSpecId,
                SpecName = source.SpecName
            };
        }
    }
}