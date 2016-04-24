using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;

namespace TMD.Implementation.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository prodCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository prodCategoryRepository)
        {
            this.prodCategoryRepository = prodCategoryRepository;
        }
        public int AddCategory(Models.DomainModels.ProductCategory productCategory)
        {
            
             prodCategoryRepository.Add(productCategory);
             prodCategoryRepository.SaveChanges();

             return productCategory.ProductCategoryID; // If Exception occurs this line will not be executed
            
        }

        public int UpdateCategory(Models.DomainModels.ProductCategory productCategory)
        {
            prodCategoryRepository.Update(productCategory);
            prodCategoryRepository.SaveChanges();

            return productCategory.ProductCategoryID;
        }

        public IEnumerable<Models.DomainModels.ProductCategory> GetAllCategories()
        {
            return prodCategoryRepository.GetAll().ToList();

        }

        public ProductCategory GetProductCategoryById(int id)
        {
            return prodCategoryRepository.Find(id);
        }

        public ProductCategoryResponse GetProductCategoryResponse(int? id)
        {
            ProductCategoryResponse prodCateResp = new ProductCategoryResponse();
            if (id != null)
            {
                prodCateResp.ProductCategory = prodCategoryRepository.Find((int)id);
            }
            prodCateResp.ProductCategories = prodCategoryRepository.GetAll();
            return prodCateResp;
        }
    }
}
