namespace Angle.ModelMappers
{
    public static class ClientMapper
    {
        public static Models.Client CreateFromServerToClient(this TMD.Models.DomainModels.Client source)
        {

            return new Models.Client
            {
                ClientId = source.ClientId,
                ClientName = source.ClientName,
                AccountNumber = source.AccountNumber,
                Image = source.Image,
                DistributorId = source.DistributorId,
                Username = source.Username,
                Password = source.Password,
                CrawlDate = source.CrawlDate,
                DistributorName = source.Distributor.DistributorName
            };
        }

        public static TMD.Models.DomainModels.Client CreateFromClientToServer(this Models.Client source)
        {

            return new TMD.Models.DomainModels.Client
            {
                ClientId = source.ClientId,
                ClientName = source.ClientName,
                AccountNumber = source.AccountNumber,
                Image = source.Image,
                DistributorId = source.DistributorId,
                Username = source.Username,
                Password = source.Password,
                CrawlDate = source.CrawlDate,
            };
        }
    }
}