using System;

namespace Angle.Models
{
    public class Client
    {
        public long ClientId { get; set; }
        public string ClientName { get; set; }
        public long AccountNumber { get; set; }
        public string Image { get; set; }
        public int DistributorId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? CrawlDate { get; set; }
        public string DistributorName { get; set; }
    }
}