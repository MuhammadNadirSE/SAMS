using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMD.Web.Models
{
    public class QuoteDetailModel
    {
        public int QuoteDetailId { get; set; }
        public int QuoteId { get; set; }
        public int ProductId { get; set; }
        public string Make { get; set; }
        public int ModelId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
    }
}