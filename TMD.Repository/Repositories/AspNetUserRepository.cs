﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace TMD.Repository.Repositories
{
    public class AspNetUserRepository : BaseRepository<AspNetUser>, IAspNetUserRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AspNetUserRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<AspNetUser> DbSet
        {
            get { return db.AspNetUsers; }
        }

        #endregion

        public IEnumerable<AspNetUser> GetAllUsers()
        {

            //var adminUsers = db.Users.Include("AspNetRoles").Where(t=>t.AspNetRoles.Any() && t.AspNetRoles.Any(x=>x.Name!="Admin"));
            var adminUsers = db.Users.Include("AspNetRoles").Where(t=>t.AspNetRoles.Any());
            
            var abc = adminUsers.ToList();
            return adminUsers;
            // return DbSet.Include("AspNetRoles").Where(x => x.Id != "53752d93-51ba-4374-86fe-c289a8662872");//AspNetRoles.Any(y => y.Name != "Admin")

            //.Where(x => x.AspNetRoles.Any(y => y.Name != "Admin"));//TEmperory check
        }

        public IEnumerable<AspNetUser> GetAllUsersOfEmployeeRole()
        {
            return db.Users.Include("AspNetRoles").Where(t => t.AspNetRoles.Any() && t.AspNetRoles.Any(x => x.Name == "Employee"));
        }

        public IEnumerable<string> GetAllUsersEmailOfSpecificRole(string roleName)
        {
            var emails = db.Users.Where(t => t.AspNetRoles.Any() && t.AspNetRoles.Any(x => x.Name == roleName)).Select(x=>x.Email);

            return emails;
        }
    }
}
