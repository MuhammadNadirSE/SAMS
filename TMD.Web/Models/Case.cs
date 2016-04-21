using System;
using System.ComponentModel.DataAnnotations;

namespace TMD.Web.Models
{
    public class Case
    {
        public long CaseId { get; set; }
        public string CaseNumber { get; set; }
        public DateTime? FilingDate { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [RegularExpression(@"^\d{9}|\d{3}-\d{2}-\d{4}$", ErrorMessage = "Invalid Social Security Number")]
        public string SSN { get; set; }
        public DateTime? DispositionDate { get; set; }
        public string Address { get; set; }
        public string Aliases { get; set; }
        public string Sentencing { get; set; }
        public string CaseNotes { get; set; }
        public long OrderId { get; set; }
        public string RecCreatedBy { get; set; }
        public DateTime RecCreatedDt { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public DateTime RecLastUpdatedDt { get; set; }

    }
}