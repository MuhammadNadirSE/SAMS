using System;
using System.ComponentModel.DataAnnotations;

namespace TMD.Web.Models
{
    public class Order
    {
        public long OrderId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [RegularExpression(@"^\d{9}|\d{3}-\d{2}-\d{4}$", ErrorMessage = "Invalid Social Security Number")]
        public string SSN { get; set; }
        public int? CountryId { get; set; }
        public int? CountyId { get; set; }
        public string RecCreatedBy { get; set; }
        public DateTime RecCreatedDt { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public DateTime RecLastUpdatedDt { get; set; }
        public long OrderStatusId { get; set; }
        public string CountryName { get; set; }
        public string CountyName { get; set; }
        public string Dob { get; set; }
        public string OrderDate { get; set; }
    }
}
