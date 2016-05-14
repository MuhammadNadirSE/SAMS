using TMD.Models.DomainModels;
using TMD.Web.ViewModels.EmployeeSupervisor;

namespace TMD.Web.ModelMappers
{
    public static class EmployeeSupervisorMapper
    {
        public static EmployeeSupervisorModel CreateFromServerToClient(this EmployeeSupervisor source)
        {
            return new EmployeeSupervisorModel
            {
                EmployeeId = source.EmployeeId,
                SupervisorId = source.SupervisorId,
                Comment = source.Comment
                
                
            };
        }

        public static EmployeeSupervisor CreateFromClientToServer(this EmployeeSupervisorModel source)
        {
            return new EmployeeSupervisor
            {
                EmployeeId = source.EmployeeId,
                SupervisorId = source.SupervisorId,
                Comment = source.Comment
            };
        }
 
    }
}