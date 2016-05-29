using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMD.Web.Models
{
    public class QuoteExclusionModel
    {
        public int QuoteExclusionId { get; set; }
        public int QuoteId { get; set; }
        public int ExclusionId { get; set; }
    }
}