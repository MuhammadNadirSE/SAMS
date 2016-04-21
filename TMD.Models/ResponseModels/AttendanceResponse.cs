using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Models.ResponseModels
{
    public class AttendanceResponse
    {
        public AttendanceResponse()
        {
            Attendances = new List<Attendance>();
        }

        public IEnumerable<Attendance> Attendances { get; set; }

        public int TotalCount { get; set; }
        public int TotalRecords { get; set; }
        public int FilteredCount { get; set; }
    }
}
