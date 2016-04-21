using System.ComponentModel.DataAnnotations;

namespace TMD.Models.Common
{
    public enum LeaveType : int
    {
        [Display(Name = "Casual (Full Day) Leave")]
        Casual = 0,

        [Display(Name = "Medical/Sick Leave")]
        Medical = 1,

        [Display(Name = "Casual (Half Day) Leave")]
        HalfDay = 2,

        [Display(Name = "Annual (Paid) Leave")]
        Annual = 3,
    }
}
