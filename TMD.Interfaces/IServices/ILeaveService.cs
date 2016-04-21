using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface ILeaveService
    {
        bool SaveLeave(Leave leave);
        IEnumerable<Leave> GetaAlLeaves();
    }
}