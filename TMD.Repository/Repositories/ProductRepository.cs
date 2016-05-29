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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IUnityContainer container)
            : base(container)
        {

        }
        protected override IDbSet<Product> DbSet
        {
            get { return db.Product; }
        }
        public IEnumerable<Product> GetAllProductsAndModels()
        {
            return DbSet.Include(x => x.ProductModels);
        }
    }
}
