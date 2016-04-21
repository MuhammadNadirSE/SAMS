using System.Linq;
using TMD.Models.MenuModels;

namespace TMD.Interfaces.IRepository
{
    public interface IMenuRightRepository : IBaseRepository<MenuRight, int>
    {
        IQueryable<MenuRight> GetMenuByRole(string roleId);
    }
}
