using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class CaseMapper
    {
        public static Models.Case CreateFromServerToClient(this Case source)
        {
            return new Models.Case
            {
                CaseId = source.CaseId,
                CaseNumber = source.CaseNumber,
                FilingDate = source.FilingDate,
                FirstName = source.FirstName,
                MiddleName = source.MiddleName,
                LastName = source.LastName,
                DispositionDate = source.DispositionDate,
                Sentencing = source.Sentencing,
                OrderId = source.OrderId,
                Address = source.Address,
                Aliases = source.Aliases,
                CaseNotes = source.CaseNotes,
                SSN = source.SSN,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDt = source.RecCreatedDt,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDt = source.RecLastUpdatedDt,
            };
        }

        public static Case CreateFromClientToServer(this Models.Case source)
        {
            return new Case
            {
                CaseId = source.CaseId,
                CaseNumber = source.CaseNumber,
                FilingDate = source.FilingDate,
                FirstName = source.FirstName,
                MiddleName = source.MiddleName,
                LastName = source.LastName,
                DispositionDate = source.DispositionDate,
                Sentencing = source.Sentencing,
                OrderId = source.OrderId,
                Address = source.Address,
                Aliases = source.Aliases,
                CaseNotes = source.CaseNotes,
                SSN = source.SSN,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDt = source.RecCreatedDt,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDt = source.RecLastUpdatedDt,
            };
        }
    }
}