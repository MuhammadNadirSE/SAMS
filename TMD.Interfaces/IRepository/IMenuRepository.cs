using TMD.Models.MenuModels;

namespace TMD.Interfaces.IRepository
{
    public interface IMenuRepository : IBaseRepository<Menu, int>
    {
        long GetMenuIdByPermissionKey(string permissionKey);
    }
}
