using System;
using System.Collections.Generic;

namespace TMD.Models.DomainModels
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            this.AspNetUserClaims = new HashSet<AspNetUserClaim>();
            this.AspNetUserLogins = new HashSet<AspNetUserLogin>();
            this.AspNetRoles = new HashSet<AspNetRole>();
            this.Employees = new HashSet<Employee>();
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string ImageName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string UserComments { get; set; }


        
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        
        public virtual ICollection<Employee> Employees { get; set; }
        
        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
        
        public virtual ICollection<Contact> CreatedContacts { get; set; }
        
        public virtual ICollection<Contact> UpdatedContacts { get; set; }
        
        public virtual ICollection<Inquiry> ConductedInquiries { get; set; }
        
        public virtual ICollection<Inquiry> CreatedInquiries { get; set; }
        
        public virtual ICollection<Inquiry> UpdatedInquiries { get; set; }
        
        public virtual ICollection<TechnicalSpec> UpdatedTechnicalSpecs { get; set; }
        
        public virtual ICollection<TechnicalSpec> CreatedTechnicalSpecs { get; set; }
        
        public virtual ICollection<Product> CreatedProducts { get; set; }
        
        public virtual ICollection<Product> UpdatedProducts { get; set; }
        
        public virtual ICollection<ProductCategory> CreatedProductCategories { get; set; }
        
        public virtual ICollection<ProductCategory> UpdatedProductCategories { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<NotificationRecipient> NotificationRecipients { get; set; }
        public virtual ICollection<Exclusion> CreatedExclusions { get; set; }
        public virtual ICollection<Exclusion> UpdatedExclusions { get; set; }
        public virtual ICollection<Quote> CreatedQuotes { get; set; }
        public virtual ICollection<Quote> UpdatedQuotes { get; set; }
    }
}
