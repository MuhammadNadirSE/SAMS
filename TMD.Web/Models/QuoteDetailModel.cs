using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMD.Web.Models
{
    public class QuoteDetailModel
    {
        public int QuoteDetailId { get; set; }
        public int QuoteId { get; set; }
        [Display(Name = "Product")]
        [Required(ErrorMessage = "Product is required.")]
        public int ProductId { get; set; }
        public string Make { get; set; }
        [Display(Name = "Product Model")]
        public int ModelId { get; set; }
        [Required(ErrorMessage = "Product Price is required.")]
        [Range(1, double.MaxValue,ErrorMessage = "Price must be greater than 1.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Product Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 1.")]
        public int Quantity { get; set; }
        public double Discount { get; set; }
    }
}