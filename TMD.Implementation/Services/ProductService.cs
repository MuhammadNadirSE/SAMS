using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Common;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;
using TMD.Repository.Repositories;

namespace TMD.Implementation.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository prodRepository;
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IDocumentService documentService;


        public ProductService(IProductRepository prodRepository, IProductCategoryRepository productCategoryRepository, IDocumentService documentService)
        {
            this.prodRepository = prodRepository;
            this.productCategoryRepository = productCategoryRepository;
            this.documentService = documentService;

        }
        public int AddProduct(Models.DomainModels.Product product)
        {

            prodRepository.Add(product);
            prodRepository.SaveChanges();

            if (product.Documents !=null && product.Documents.Count>0)
                  documentService.AddDocuments(product.Documents, product.ProductID, DocumentType.Product);

            return product.ProductID; // If Exception occurs this line will not be executed

        }

        public int UpdateProduct(Models.DomainModels.Product product)
        {
            prodRepository.Update(product);
            prodRepository.SaveChanges();

            if (product.Documents != null && product.Documents.Count > 0)
                documentService.AddDocuments(product.Documents, product.ProductID, DocumentType.Product);


            return product.ProductID;
        }

        public IEnumerable<Models.DomainModels.Product> GetAllProducts()
        {
            return prodRepository.GetAll().ToList();

        }

        public Product GetProductById(int id)
        {
            return prodRepository.Find(id);
        }

        public ProductResponse GetProductResponse(int? id)
        {
            ProductResponse prodResp = new ProductResponse();
            if (id != null)
            {
                prodResp.Product = prodRepository.Find((int)id);
            }
            prodResp.ProductCategories = productCategoryRepository.GetAllLeafCategories();
            return prodResp;
        }
    }
}
