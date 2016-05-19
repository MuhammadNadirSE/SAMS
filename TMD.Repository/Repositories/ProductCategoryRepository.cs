using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Interfaces.IRepository;
using TMD.Repository.BaseRepository;
using TMD.Models.DomainModels;
using Microsoft.Practices.Unity;
using System.Data.Entity;

namespace TMD.Repository.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>,IProductCategoryRepository
    {
        public ProductCategoryRepository(IUnityContainer container)
            : base(container)
        {

        }
        protected override IDbSet<ProductCategory> DbSet
        {
            get { return db.ProductCategory; }
        }

        public IEnumerable<ProductCategory> GetAllLeafCategories()
        {
            return DbSet.Where(x => x.SubProductCategories.Count == 0);
        }
    }
}
