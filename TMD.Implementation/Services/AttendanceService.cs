using System;
using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Implementation.Services
{
    public class AttendanceService:IAttendanceService
    {
        private readonly IAttendanceRepository attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            this.attendanceRepository = attendanceRepository;
        }

        public bool SaveAttendance(Attendance attendance)
        {
            if (attendance.AttendanceId > 0)
            {
                attendance.IsEdited = true;
                attendanceRepository.Update(attendance);
            }
                
            else
                attendanceRepository.Add(attendance);

            attendanceRepository.SaveChanges();
            return true;
        }

        public AttendanceResponse GetAllAttendances(AttendanceSearchRequest attendanceSearchRequest)
        {
            return attendanceRepository.GetAllAttendances(attendanceSearchRequest);
        }

        public bool UpdateAttendance(Attendance attendance)
        {
            attendanceRepository.Update(attendance);
            attendanceRepository.SaveChanges();
            return true;
        }

        public Attendance GetAttendanceById(long id)
        {
            return attendanceRepository.Find(id);
        }

        public IEnumerable<Attendance> GetAttendanceByEmployeeId(int id)
        {
            return attendanceRepository.GetAttendanceByEmployeeId(id);
        }

        public IEnumerable<Attendance> GetAttendanceOfCurrentMonthByEmployeeId(int employeeId)
        {
            return attendanceRepository.GetAttendanceOfCurrentMonthByEmployeeId(employeeId);
        }

        public Attendance GetAttendanceByEmployeeIdInCurrentDate(int employeeId)
        {
            return attendanceRepository.GetAttendanceByEmployeeIdInCurrentDate(employeeId);
        }
    }
}
