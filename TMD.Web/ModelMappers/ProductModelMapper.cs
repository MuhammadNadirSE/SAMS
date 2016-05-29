using TMD.Models.DomainModels;

namespace TMD.Web.ModelMappers
{
    public static class ProductModelMapper
    {
        public static ProductModel MapClientToServer(this Models.ProductModel source)
        {
            return new ProductModel
            {
                ProductModelID = source.ProductModelId,
                ProductId = source.ProductId,
                ModelName = source.ModelName,
                ModelDescription = source.ModelDescription
            };
        }
        public static Models.ProductModel MapServerToClient(this ProductModel source)
        {
            return new Models.ProductModel
            {
                ProductModelId = source.ProductModelID,
                ProductId = source.ProductId,
                ModelName = source.ModelName,
                ModelDescription = source.ModelDescription
            };
        }

        public static Models.ProductModel CreateDDL(this ProductModel source)
        {
            return new Models.ProductModel
            {
                ProductModelId = source.ProductModelID,
                ProductId = source.ProductId,
                ModelName = source.ModelName,
            };
        }
    }
}