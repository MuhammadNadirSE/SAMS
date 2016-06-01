using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class ExclusionMapper
    {
        #region Exclusion Mappers  
        public static Exclusion MapClientToServer(this ExclusionModel source)
        {
            return new Exclusion
            {

                ExclusionId = source.ExclusionId,
                Name=   source.Name,
                CreatedDate = source.CreatedDate,
                CreatedBy=source.CreatedBy,
                UpdatedBy=source.UpdatedBy,
                UpdatedDate=source.UpdatedDate

            };
        }
        public static ExclusionModel MapServerToClient(this Exclusion source)
        {
            return new ExclusionModel
            {

                ExclusionId = source.ExclusionId,
                Name = source.Name,
                CreatedDate = source.CreatedDate,
                CreatedBy = source.CreatedBy,
                UpdatedBy = source.UpdatedBy,
                UpdatedDate = source.UpdatedDate
            };
        }
        #endregion
        #region QuoteExclusion Mappers  
        public static QuoteExclusion MapClientToServer(this QuoteExclusionModel source)
        {
            return new QuoteExclusion
            {
                QuoteExclusionId = source.QuoteExclusionId,
                ExclusionId = source.ExclusionId,
                QuoteId = source.QuoteId
            };
        }
        public static QuoteExclusionModel MapServerToClient(this QuoteExclusion source)
        {
            return new QuoteExclusionModel
            {
                QuoteExclusionId = source.QuoteExclusionId,
                ExclusionId = source.ExclusionId,
                QuoteId = source.QuoteId,
                ExclusionName = source.Exclusion.Name
            };
        }
        #endregion
    }
}