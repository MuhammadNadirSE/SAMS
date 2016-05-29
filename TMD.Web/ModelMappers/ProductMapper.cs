using TMD.Models.DomainModels;

namespace TMD.Web.ModelMappers
{
    public static class ProductMappers
    {
        public static Product MapClientToServer(this Models.Product source)
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
        public static Models.Product MapServerToClient(this Product source)
        {
            return new Models.Product
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
        public static Models.Product CreateDDL(this Product source)
        {
            return new Models.Product
            {

                ProductID = source.ProductID,
                ProductName = source.ProductName,
                Price = source.Price,
            };
        }
    }
}