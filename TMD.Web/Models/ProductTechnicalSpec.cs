namespace TMD.Web.Models
{
    public class ProductTechnicalSpec
    {
        public int ProductTechSpecsId { get; set; }
        public int ProductModelId { get; set; }
        public int TechSpecId { get; set; }
        public string TechSpecName { get; set; }
        public string SpecValue { get; set; }
    }
}