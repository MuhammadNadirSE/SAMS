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

        public int SaveProductModel(ProductModelResponse productModel)
        {
            if (productModel.ProductModel.ProductModelID > 0)
            {
                productModelRepository.Update(productModel.ProductModel);
            }
            else
            {
                productModelRepository.Add(productModel.ProductModel);
            }
            productModelRepository.SaveChanges();

            SaveTechSpecs(productModel);

            return productModel.ProductModel.ProductModelID;
        }

        private void SaveTechSpecs(ProductModelResponse productModel)
        {
            if (productModel.ProductModel.ProductModelID > 0)
            {
                var specs = productTechnicalSpecsRepository.LoadTechnicalSpecsByModelId(productModel.ProductModel.ProductModelID).ToList();

                foreach (var spec in specs)
                {
                    productTechnicalSpecsRepository.Delete(spec);
                }
            }
            if (productModel.ProductModelTechnicalSpec != null && productModel.ProductModelTechnicalSpec.Any())
            {
                foreach (var spec in productModel.ProductModelTechnicalSpec)
                {
                    spec.ProductModelId = productModel.ProductModel.ProductModelID;

                    productTechnicalSpecsRepository.Add(spec);
                }
            }
            productTechnicalSpecsRepository.SaveChanges();
        }

        public List<ProductModel> GetAllProductModelsByProductId(int productId)
        {
            return productModelRepository.LoadProductModelsByProductId(productId).ToList();
        }

        public ProductModel GetProductModelById(int id)
        {
            return productModelRepository.Find(id);
        }

        public ProductModelResponse GetProductModelResponse(int? productId, int? modelId)
        {
            ProductModelResponse productModelResponse=new ProductModelResponse();
            if (productId != null)
            {
                productModelResponse.ProductModels = productModelRepository.LoadProductModelsByProductId((int) productId);
            }
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
