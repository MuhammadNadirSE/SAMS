using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface IAttendanceService
    {
        bool SaveAttendance(Attendance attendance);

        AttendanceResponse GetAllAttendances(AttendanceSearchRequest attendanceSearchRequest);
        bool UpdateAttendance(Attendance attendance);
        Attendance GetAttendanceById(long id);
        IEnumerable<Attendance> GetAttendanceByEmployeeId(int id);
        IEnumerable<Attendance> GetAttendanceOfCurrentMonthByEmployeeId(int employeeId);
        Attendance GetAttendanceByEmployeeIdInCurrentDate(int employeeId);

    }
}