namespace TMD.Models.DomainModels
{
    public class Document
    {
        public long DocumentId { get; set; }
        public byte[] DocumentData { get; set; }
        public string DocumentType { get; set; }
        public string DocumentName { get; set; }
        public int RefrenceId { get; set; }
        public int RefrenceType { get; set; }
    }
}
