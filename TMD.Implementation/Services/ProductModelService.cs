using System;
using System.Collections.Generic;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;

namespace TMD.Implementation.Services
{
    public class ProductModelService : IProductModelService
    {
        private readonly IProductModelRepository productModelRepository;
        private readonly ITechnicalSpecsRepository technicalSpecsRepository;
        private readonly IProductTechnicalSpecsRepository productTechnicalSpecsRepository;

        public ProductModelService(IProductModelRepository productModelRepository, ITechnicalSpecsRepository technicalSpecsRepository, IProductTechnicalSpecsRepository productTechnicalSpecsRepository)
        {
            this.productModelRepository = productModelRepository;
            this.technicalSpecsRepository = technicalSpecsRepository;
            this.productTechnicalSpecsRepository = productTechnicalSpecsRepository;
        }

        public int SaveProductModel(ProductModel productModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductModel> GetAllProductModelsByProductId(int productId)
        {
            throw new NotImplementedException();
        }

        public Product GetProductModelById(int id)
        {
            throw new NotImplementedException();
        }

        public ProductModelResponse GetProductModelResponse(int? modelId)
        {
            ProductModelResponse productModelResponse=new ProductModelResponse();
            if (modelId != null)
            {
                productModelResponse.ProductModel = productModelRepository.Find((int) modelId);
                productModelResponse.ProductModelTechnicalSpec =
                    productTechnicalSpecsRepository.LoadTechnicalSpecsByModelId((int) modelId).ToList();
            }
            productModelResponse.TechnicalSpec = technicalSpecsRepository.GetAll().ToList();
            return productModelResponse;
        }
    }
}
