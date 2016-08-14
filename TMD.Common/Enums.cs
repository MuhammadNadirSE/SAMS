namespace TMD.Common
{
    public enum ContactType 
    {
            Customer =1 
    }

    public enum AddressType
    {
        PrimaryAddress =1,
        SecondaryAddress=2
    }

    public enum Priority
    {
        Low=1,
        Medium=2,
        High=3
    }
    public enum DocumentType
    {
        Product = 1,
        Inquiry = 2,
        EmployeePhoto=3
    }

    public enum NotificationType
    {
        Quote = 1,
        Inquiry = 2
    }
    public enum ActionPerformed
    {
        Created = 1,
        Read = 2,
        Updated = 3,
        Deleted = 4
    }
}
