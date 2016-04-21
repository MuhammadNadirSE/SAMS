using System.Collections.Generic;

namespace TMD.Models.DomainModels
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public int DesignationId { get; set; }
        public string CellNumber { get; set; }
        public string CNIC { get; set; }
        public string Address { get; set; }
        public string BankName { get; set; }
        public string BankAccountTitle { get; set; }
        public string BankAccountNumber { get; set; }
        public string RecCreatedBy { get; set; }
        public System.DateTime RecCreatedDt { get; set; }
        public string RecLastUpdatedBy { get; set; }
        public System.DateTime RecLastUpdatedDt { get; set; }
        public int AllowedAnnualPaidLeaves { get; set; }
        public int AllowedAnnualCasualLeaves { get; set; }
        public int AllowedAnnualMedicalLeaves { get; set; }
        public decimal? Salary { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual ICollection<EmployeeSupervisor> SupervisorOfEmployees { get; set; }
        public virtual ICollection<EmployeeSupervisor> EmployeeSupervisors { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual ICollection<Attendance> EditedAttendances { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Leave> Leaves { get; set; }
        public virtual ICollection<Leave> LeavesApprovedBy { get; set; }
        public virtual ICollection<Ticket> ApprovedEmployeeTickets { get; set; }
        public virtual ICollection<EmployeePayroll> EmployeePayrolls { get; set; }
    }
}
