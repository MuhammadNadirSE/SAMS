using TMD.Models.DomainModels;
using TMD.Web.ViewModels.Designation;

namespace TMD.Web.ModelMappers
{
    public static class DesignationMapper
    {
        public static DesignationModel CreateFromServerToClient(this Designation source)
        {

            return new DesignationModel
            {
                DesignationId = source.DesignationId,
                Abbreviation = source.Abbreviation,
                Description = source.Description,
                Title = source.Title,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDt = source.RecCreatedDt,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDt = source.RecLastUpdatedDt
            };
        }

        public static Designation CreateFromClientToServer(this DesignationModel source)
        {
            return new Designation
            {
                DesignationId = source.DesignationId,
                Abbreviation = source.Abbreviation,
                Description = source.Description,
                Title = source.Title,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDt = source.RecCreatedDt,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDt = source.RecLastUpdatedDt
            };
        }

        public static Models.DesignationModel MapServerToClient(this Designation source)
        {

            return new Models.DesignationModel
            {
                DesignationId = source.DesignationId,
                Abbreviation = source.Abbreviation,
                Description = source.Description,
                Title = source.Title,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDt = source.RecCreatedDt,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDt = source.RecLastUpdatedDt
            };
        }

        public static Designation MapClientToServer(this Models.DesignationModel source)
        {
            return new Designation
            {
                DesignationId = source.DesignationId,
                Abbreviation = source.Abbreviation,
                Description = source.Description,
                Title = source.Title,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDt = source.RecCreatedDt,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDt = source.RecLastUpdatedDt
            };
        }
    }
}