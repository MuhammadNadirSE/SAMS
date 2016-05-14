using System;
using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class AttendanceModelMapper
    {
        public static AttendanceModel MapFromServerToClient(this Attendance source,int GMT)
        {
            var attendance = new AttendanceModel
            {
                AttendanceId = source.AttendanceId,
                AwayFromTime = source.AwayFromTime != null ? Utility.ConvertTimeByGMT(GMT, source.AwayFromTime.Value) : source.AwayFromTime,
                AwayToTime = source.AwayToTime != null ? Utility.ConvertTimeByGMT(GMT, source.AwayToTime.Value) : source.AwayToTime,
                CheckInTime = Utility.ConvertTimeByGMT(GMT, source.CheckInTime),
                Comments = source.Comments,
                EditedBy = source.EditedBy,
                EditedDate = source.EditedDate != null ? Utility.ConvertTimeByGMT(GMT, source.EditedDate.Value) : source.EditedDate,
                EmployeeId = source.EmployeeId,
                IP = source.IP,
                IsEdited = source.IsEdited,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate,
                EmployeeName = source.AttendeeEmployee.FullName//to show on edit page
            };
            if (source.CheckOutTime != null)
            {
                attendance.CheckOutTime = Utility.ConvertTimeByGMT(GMT, Convert.ToDateTime(source.CheckOutTime));
            }
            return attendance;
        }

        public static Attendance MapFromClientToServer(this AttendanceModel source)
        {
            return new Attendance
            {
                AttendanceId = source.AttendanceId,
                AwayFromTime = source.AwayFromTime,
                AwayToTime = source.AwayToTime,
                CheckInTime = source.CheckInTime,
                CheckOutTime = source.CheckOutTime,
                Comments = source.Comments,
                EditedBy = source.EditedBy,
                EditedDate = source.EditedDate,
                EmployeeId = source.EmployeeId,
                IP = source.IP,
                IsEdited = source.IsEdited,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }

        public static AttendanceWebModel MapAttendanceResponseFromServerToClient(this Attendance source,int GMT)
        {
            var awayFromTime = source.AwayFromTime != null ? Utility.ConvertTimeByGMT(GMT, source.AwayFromTime.Value).ToShortTimeString() : "0:00";
            var awayToTime = source.AwayToTime != null && source.AwayFromTime != null ? Utility.ConvertTimeByGMT(GMT, source.AwayToTime.Value).ToShortTimeString() : "0:00";
            var differenceOfAwayTime = Convert.ToDateTime(awayToTime) - Convert.ToDateTime(awayFromTime);
            var totalTime = source.CheckOutTime == null ? "0" : Convert.ToDateTime(source.CheckOutTime).Subtract(source.CheckInTime).Subtract(differenceOfAwayTime).ToString().Split('.')[0];

            var attendance = new AttendanceWebModel
            {
                
                AttendanceId = source.AttendanceId,
                AwayFromTime = awayFromTime,
                AwayToTime = awayToTime,
                CheckInTime = Utility.ConvertTimeByGMT(GMT, source.CheckInTime).ToShortTimeString(),
                CheckInDate = Utility.ConvertTimeByGMT(GMT, source.CheckInTime).ToShortDateString(),
                Comments = source.Comments,
                EmployeeId = source.EmployeeId,
                EmployeeName = source.AttendeeEmployee.FullName,
                IsEdited = source.IsEdited,
                EditedBy = source.EditedBy,
                EditedDate = source.EditedDate != null ? Utility.ConvertTimeByGMT(GMT, source.EditedDate.Value) : source.EditedDate,
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = Utility.ConvertTimeByGMT(GMT, source.RecCreatedDate).ToShortDateString(),
                WorkingHours = totalTime //- differenceOfAwayTime.Hours
            };
            if (source.CheckOutTime != null)
            {
                attendance.CheckOutTime =
                    Utility.ConvertTimeByGMT(GMT, Convert.ToDateTime(source.CheckOutTime)).ToShortTimeString();
            }
            return attendance;
        }
    }
}