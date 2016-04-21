using System.Collections.Generic;
using TMD.Models.DomainModels;
using TMD.Models.MenuModels;

namespace TMD.Interfaces.IServices
{
    public interface IMenuRightsService
    {
        /// <summary>
        /// Find Menu item by Role
        /// </summary>        
        IEnumerable<MenuRight> FindMenuItemsByRoleId(string roleId);

        /// <summary>
        /// Save Roles Menu Rights
        /// </summary>
        UserMenuResponse SaveRoleMenuRight(string roleId, string menuIds, AspNetRole role);

        /// <summary>
        /// Get Role Menu Rights
        /// </summary>
        UserMenuResponse GetRoleMenuRights(string roleId);
    }
}
