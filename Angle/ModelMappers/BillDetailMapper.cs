namespace Angle.ModelMappers
{
    public static class BillDetailMapper
    {
        public static Models.BillDetail CreateFromServerToClient(this TMD.Models.DomainModels.BillDetail source)
        {

            return new Models.BillDetail
            {
                ClientId = source.ClientId,
                BillDetailId = source.BillDetailId,
                AccountNumber = source.Client.AccountNumber,
                BatchId = source.BatchId,
                BillIssueDate = source.BillIssueDate,
                Description = source.Description,
                InclGst = source.InclGst,
                Quantity = source.Quantity,
                ServiceNumber = source.ServiceNumber,
                BillDetailChargeTypeId = source.BillDetailChargeTypeId,
                BillDetailServiceTypeId = source.BillDetailServiceTypeId,
            };
        }

        public static TMD.Models.DomainModels.BillDetail CreateFromClientToServer(this Models.BillDetail source)
        {

            return new TMD.Models.DomainModels.BillDetail
            {
                ClientId = source.ClientId,
                BillDetailId = source.BillDetailId,
                BatchId = source.BatchId,
                BillIssueDate = source.BillIssueDate,
                Description = source.Description,
                InclGst = source.InclGst,
                Quantity = source.Quantity,
                ServiceNumber = source.ServiceNumber,
                BillDetailChargeTypeId = source.BillDetailChargeTypeId,
                BillDetailServiceTypeId = source.BillDetailServiceTypeId,
            };
        }
    }
}