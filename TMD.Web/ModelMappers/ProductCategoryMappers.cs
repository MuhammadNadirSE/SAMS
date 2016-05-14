using System;
using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class ProductCategoryMappers
    {
        public static ProductCategory MapClientToServer(this ProductCategoryModel source)
        {
            return new ProductCategory {

                ProductCategoryID = source.ProductCategoryID,
                CatName = source.CatName ?? "",
                ShortDescription = String.IsNullOrEmpty(source.ShortDescription) ? "" : source.ShortDescription,
                DetailDescription = source.DetailDescription??"",
                IsParent = source.IsParent,
                ParentCatID = source.ParentCatID,
                UpdatedBy = source.UpdatedBy,
                UpdatedDate = source.UpdatedDate,
                CreatedDate = source.CreatedDate,
                CreatedBy = source.CreatedBy
                    
                };
        }
        public static ProductCategoryModel MapServerToClient(this ProductCategory source)
        {
            return new ProductCategoryModel
            {

                ProductCategoryID = source.ProductCategoryID,
                CatName = source.CatName,
                ShortDescription = source.ShortDescription,
                DetailDescription = source.DetailDescription,
                IsParent = source.IsParent,
                ParentCatID = source.ParentCatID,
                UpdatedBy = source.UpdatedBy,
                UpdatedDate = source.UpdatedDate,
                CreatedDate = source.CreatedDate,
                CreatedBy = source.CreatedBy

            };
        }
    }
}