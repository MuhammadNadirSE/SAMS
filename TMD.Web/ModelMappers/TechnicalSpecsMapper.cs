using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class TechnicalSpecsMapper
    {
        #region Technical Specs
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
        #endregion
        #region Product Technical Specs
        public static ProductTechSpec MapClientToServer(this ProductTechnicalSpec source)
        {
            return new ProductTechSpec
            {
                ProductTechSpecsId = source.ProductTechSpecsId,
                ProductModelId = source.ProductModelId,
                TechSpecId = source.TechSpecId,
                SpecValue = source.SpecValue
            };
        }
        public static ProductTechnicalSpec MapServerToClient(this ProductTechSpec source)
        {
            return new ProductTechnicalSpec
            {
                ProductTechSpecsId = source.ProductTechSpecsId,
                ProductModelId = source.ProductModelId,
                TechSpecId = source.TechSpecId,
                SpecValue = source.SpecValue,
                TechSpecName = source.TechnicalSpec.SpecName
            };
        }
        #endregion

    }
}