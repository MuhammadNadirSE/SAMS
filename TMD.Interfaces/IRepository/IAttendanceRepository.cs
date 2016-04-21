using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IRepository
{
    public interface IAttendanceRepository : IBaseRepository<Attendance, long>
    {
        IEnumerable<Attendance> GetAttendanceByEmployeeId(int id);
        Attendance GetAttendanceByEmployeeIdInCurrentDate(int employeeId);
        IEnumerable<Attendance> GetAttendanceOfCurrentMonthByEmployeeId(int employeeId);
        AttendanceResponse GetAllAttendances(AttendanceSearchRequest attendanceSearchRequest);
    }
}
