using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class ExclusionMapper
    {
       
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
      

    }
}