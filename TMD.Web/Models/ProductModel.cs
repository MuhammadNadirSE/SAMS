using System.ComponentModel.DataAnnotations;

namespace TMD.Web.Models
{
    public class ProductModel
    {
        public int ProductModelId { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "Model Name")]
        [Required(ErrorMessage = "Product Model Name is required.")]
        public string ModelName { get; set; }
        [Display(Name = "Description")]
        public string ModelDescription { get; set; }
    }
}