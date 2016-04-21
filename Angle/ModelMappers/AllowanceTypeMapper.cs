using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class AllowanceTypeMapper
    {
        public static AllowanceType CreateFromClientToServer(this AllowanceTypeModel source)
        {
            return new AllowanceType
            {
                TypeId = source.TypeId,
                TypeTitle = source.TypeTitle,
                RecCreatedBy = source.RecCreatedBy,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
        public static AllowanceTypeModel CreateFromServerToClient(this AllowanceType source)
        {
            return new AllowanceTypeModel
            {
                TypeId = source.TypeId,
                TypeTitle = source.TypeTitle,
                RecCreatedBy = source.RecCreatedBy,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
    }
}