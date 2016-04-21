using Angle.Models;

namespace Angle.ModelMappers
{
    public static class ServiceProviderMapper
    {
        public static Distributor CreateFromServerToClient(this TMD.Models.DomainModels.Distributor source)
        {
            return new Distributor
            {
                DistributorId = source.DistributorId,
                DistributorName = source.DistributorName,
                DistributorLink = source.DistributorLink
            };
        }

        public static TMD.Models.DomainModels.Distributor CreateFromClientToServer(this Models.Distributor source)
        {
            return new TMD.Models.DomainModels.Distributor
            {
                DistributorId = source.DistributorId,
                DistributorName = source.DistributorName,
                DistributorLink = source.DistributorLink
            };
        }

    }
}