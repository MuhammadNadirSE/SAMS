using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class ChargeMapper
    {
        public static Charge CreateFromServerToClient(this Charge source)
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

        public static Charge CreateFromClientToServer(this Charge source)
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