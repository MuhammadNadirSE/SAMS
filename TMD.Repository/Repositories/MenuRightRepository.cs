using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.MenuModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public class MenuRightRepository : BaseRepository<MenuRight>, IMenuRightRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MenuRightRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<MenuRight> DbSet
        {
            get { return db.MenuRights; }
        }
        #endregion

        /// <summary>
        /// Get Menu items by role id
        /// </summary>
        public IQueryable<MenuRight> GetMenuByRole(string roleId)
        {
            return
                 DbSet.Where(menu => menu.Role_Id == roleId)
                     .Include(menu => menu.Menu)
                     .Include(menu => menu.Menu.ParentItem);
        }
    }
}
