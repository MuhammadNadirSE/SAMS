using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class OrderMapper
    {
        public static Models.Order CreateFromServerToClient(this Order source)
        {
            return new Models.Order
            {
                OrderId = source.OrderId,
                LastName = source.LastName,
                FirstName = source.FirstName,
                CountyId = source.CountyId,
                DateOfBirth = source.DateOfBirth,
                SSN = source.SSN,
                OrderStatusId = source.OrderStatusId,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDt = source.RecCreatedDt,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDt = source.RecLastUpdatedDt,
                //CountyName = source.County != null ? source.County.CountyName : "",
                Dob = source.DateOfBirth.HasValue ? source.DateOfBirth.Value.ToString(("dd MMMM yyyy")) :"",
                OrderDate = source.RecCreatedDt.ToString(("dd MMMM yyyy"))
                
            };
        }

        public static Order CreateFromClientToServer(this Models.Order source)
        {
            return new Order
            {
                OrderId = source.OrderId,
                LastName = source.LastName,
                FirstName = source.FirstName,
                DateOfBirth = source.DateOfBirth,
                CountyId = source.CountyId,
                SSN = source.SSN,
                OrderStatusId = source.OrderStatusId,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDt = source.RecCreatedDt,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDt = source.RecLastUpdatedDt,
            };
        }
    }
}