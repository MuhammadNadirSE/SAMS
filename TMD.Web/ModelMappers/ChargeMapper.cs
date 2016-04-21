using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class ChargeMapper
    {
        public static Models.Charge CreateFromServerToClient(this Charge source)
        {
            return new Models.Charge
            {
                ChargeId = source.ChargeId,
                CaseId = source.CaseId,
                ChargeDescription = source.ChargeDescription,
                DispositionDate = source.DispositionDate,
                Disposition = source.Disposition,
                ChargeLevel = source.ChargeLevel
            };
        }

        public static Charge CreateFromClientToServer(this Models.Charge source)
        {
            return new Charge
            {
                ChargeId = source.ChargeId,
                CaseId = source.CaseId,
                ChargeDescription = source.ChargeDescription,
                DispositionDate = source.DispositionDate,
                Disposition = source.Disposition,
                ChargeLevel = source.ChargeLevel
            };
        }
    }
}