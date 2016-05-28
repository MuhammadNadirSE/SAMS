﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD.Models.DomainModels
{
    public class QuoteDetail
    {
        public int QuoteDetailId { get; set; }
        public int QuoteId { get; set; }
        public int ProductId { get; set; }
        public string Make { get; set; }
        public int ModelId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductModel ProductModel { get; set; }
        public virtual Quote Quote { get; set; }
    }
}
