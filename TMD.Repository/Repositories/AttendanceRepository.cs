using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.Common;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public class AttendanceRepository : BaseRepository<Attendance>, IAttendanceRepository
    {
        /// <summary>
        /// Order by Column Names Dictionary statements
        /// </summary>
        private readonly Dictionary<OrderByColumnAttendance, Func<Attendance, object>> orderClause =

            new Dictionary<OrderByColumnAttendance, Func<Attendance, object>>
            {
                {OrderByColumnAttendance.Date, c => c.RecCreatedDate},
                {OrderByColumnAttendance.CheckInTime, c => c.CheckInTime},
                {OrderByColumnAttendance.CheckOutTime, c => c.CheckOutTime},
                {OrderByColumnAttendance.AwaySince, c => c.AwayFromTime},
                {OrderByColumnAttendance.AwayTill, c => c.AwayFromTime},
            };
        public AttendanceRepository(IUnityContainer container) : base(container)
        {
        }

        protected override IDbSet<Attendance> DbSet
        {
            get { return db.Attendances; }
        }

        public IEnumerable<Attendance> GetAttendanceByEmployeeId(int employeeId)
        {
            return DbSet.Where(x => x.EmployeeId.Equals(employeeId)).Select(x => x);
        }
        
        public Attendance GetAttendanceByEmployeeIdInCurrentDate(int employeeId)
        {
            var dateNow = DateTime.UtcNow.Date;
            return DbSet.FirstOrDefault(x => x.EmployeeId.Equals(employeeId) && DbFunctions.TruncateTime(x.CheckInTime) == DbFunctions.TruncateTime(dateNow));
        }

        public IEnumerable<Attendance> GetAttendanceOfCurrentMonthByEmployeeId(int employeeId)
        {
            var monthNow = DateTime.UtcNow.Month;
            var yearNow = DateTime.UtcNow.Year;
            return DbSet.Where(x => x.EmployeeId.Equals(employeeId) && (x.CheckInTime.Month.Equals(monthNow) && x.CheckInTime.Year.Equals(yearNow))).OrderByDescending(x=>x.CheckInTime).Select(x => x);
        }

        public AttendanceResponse GetAllAttendances(AttendanceSearchRequest attendanceSearchRequest)
        {
            int fromRow = (attendanceSearchRequest.PageNo - 1) * attendanceSearchRequest.PageSize;
            int toRow = attendanceSearchRequest.PageSize;
            Expression<Func<Attendance, bool>> query =
                s =>
                    (
                    (attendanceSearchRequest.EmployeeId==0 || attendanceSearchRequest.EmployeeId.Equals(s.EmployeeId)) &&
                    (attendanceSearchRequest.Date.Year == 1 || 
                    (attendanceSearchRequest.Date.Month.Equals(s.CheckInTime.Month) && (attendanceSearchRequest.Date.Year.Equals(s.CheckInTime.Year))))
                    );

            IEnumerable<Attendance> attendances = attendanceSearchRequest.IsAsc
                ? DbSet
                    .Where(query)
                    .OrderBy(orderClause[attendanceSearchRequest.OrderByColumn])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet
                    .Where(query)
                    .OrderByDescending(orderClause[attendanceSearchRequest.OrderByColumn])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
            return new AttendanceResponse { Attendances = attendances, TotalCount = DbSet.Count(query), FilteredCount = DbSet.Count(query) };
        }
    }
}
