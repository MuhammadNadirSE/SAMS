using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMD.Models.DomainModels
{
    public class Document
    {
        public long DocumentId { get; set; }
        public int RefrenceType { get; set; }
        public int RefrenceId { get; set; }
        public byte[] DocumentData { get; set; }
    }
}
