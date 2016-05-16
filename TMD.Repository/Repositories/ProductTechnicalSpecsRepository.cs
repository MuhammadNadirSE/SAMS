using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;


namespace TMD.Repository.Repositories
{
    public class ProductTechnicalSpecsRepository : BaseRepository<ProductTechSpec>, IProductTechnicalSpecsRepository
    {
        public ProductTechnicalSpecsRepository(IUnityContainer container)
            : base(container)
        {

        }
        protected override IDbSet<ProductTechSpec> DbSet
        {
            get { return db.ProductTechSpec; }
        }

        public IEnumerable<ProductTechSpec> LoadTechnicalSpecsByModelId(int productModelId)
        {
            return DbSet.Where(x => x.ProductModelId.Equals(productModelId));
        }
    }
}
