using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD.Models.DomainModels
{
    public class EmployeeSupervisor
    {
        public int EmployeeId { get; set; }
        public int SupervisorId { get; set; }
        public string Comment { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Employee Supervisor { get; set; }
    }
}
