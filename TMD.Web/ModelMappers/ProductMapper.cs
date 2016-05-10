using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.Models.DomainModels;
using TMD.Web.Models;


namespace TMD.Web.ModelMappers
{
    public static class ProductMappers
    {
        public static Product MapClientToServer(this TMD.Web.Models.ProductModel source)
        {
            return new Product
            {
                ProductID = source.ProductID,
                ProductName = source.ProductName,
                ShortDescription = source.ShortDescription,
                DetailDescription = source.DetailDescription,
                Price = source.Price,
                ProductCategoryID = source.ProductCategoryID,
                CreatedBy = source.CreatedBy,
                CreatedDate = source.CreatedDate,
                UpdatedBy = source.UpdatedBy,
                UpdatedDate = source.UpdatedDate  

            };
        }
        public static TMD.Web.Models.ProductModel MapServerToClient(this Product source)
        {
            return new TMD.Web.Models.ProductModel
            {

                ProductID = source.ProductID,
                ProductName = source.ProductName,
                ShortDescription = source.ShortDescription,
                DetailDescription = source.DetailDescription,
                Price = source.Price,
                ProductCategoryID = source.ProductCategoryID,
                CreatedBy = source.CreatedBy,
                CreatedDate = source.CreatedDate,
                UpdatedBy = source.UpdatedBy,
                UpdatedDate = source.UpdatedDate       

            };
        }
    }
}