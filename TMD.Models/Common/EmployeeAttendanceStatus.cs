namespace TMD.Models.Common
{
    public enum EmployeeAttendanceStatus:int
    {
        CheckedIn = 0,
        Away = 1,
        CheckedOut = 2,
        Available = 3,
        AlreadyInToday = 4,
        AlreadyAway = 5,
    }
}