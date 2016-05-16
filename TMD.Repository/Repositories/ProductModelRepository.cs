using System.Collections.Generic;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Repository.BaseRepository;
using TMD.Models.DomainModels;
using Microsoft.Practices.Unity;
using System.Data.Entity;

namespace TMD.Repository.Repositories
{
    public class ProductModelRepository : BaseRepository<ProductModel>, IProductModelRepository
    {
        public ProductModelRepository(IUnityContainer container)
            : base(container)
        {

        }
        protected override IDbSet<ProductModel> DbSet
        {
            get { return db.ProductModel; }
        }

        public IEnumerable<ProductModel> LoadProductModelsByProductId(int productId)
        {
            return DbSet.Where(x => x.ProductId.Equals(productId));
        }
    }
}
