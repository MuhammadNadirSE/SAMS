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
