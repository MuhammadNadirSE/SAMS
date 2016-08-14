using System;
using System.ComponentModel.DataAnnotations;

namespace TMD.Web.ViewModels.Employee
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string UserId { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string RoleTitle { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        [Required]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        public string DesignationTitle { get; set; }

        [Display(Name = "Cell #")]        
        public string CellNumber { get; set; }

        [Display(Name = "CNIC ")]
        public string CNIC { get; set; }

        [Display(Name = "Bank Account Title")]
        public string BankAccountTitle { get; set; }
        [Display(Name = "Bank Account #")]

        public string BankAccountNumber { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        

        public string RecCreatedBy { get; set; }
        public System.DateTime RecCreatedDt { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public System.DateTime RecLastUpdatedDt { get; set; }
        [Display(Name = "Annual Paid Leaves")]
        public int AllowedAnnualPaidLeaves { get; set; }
        [Display(Name = "Annual Casual Leaves")]
        public int AllowedAnnualCasualLeaves { get; set; }
        [Display(Name = "Annual Medical Leaves")]
        public int AllowedAnnualMedicalLeaves { get; set; }

        [Required]
        [Display(Name = "System Role")]
        public string RoleId { get; set; }
        [Display(Name = "Is Active User?")]
        public bool IsRegistered { get; set; }
        public decimal? Salary { get; set; }
        [Display(Name = "Joining Date")]
        public DateTime? JoiningDate { get; set; }
    }

    public class EmployeeDDL
    {
        public int EmployeeId { get; set; }
        public string EmployeeUserId { get; set; }
        public string FullName { get; set; }
    }
}
