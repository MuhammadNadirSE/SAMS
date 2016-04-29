﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;

namespace TMD.Implementation.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        public int AddCategory(Models.DomainModels.Contact Contact)
        {

            contactRepository.Add(Contact);
            contactRepository.SaveChanges();

            return Contact.ContactID; // If Exception occurs this line will not be executed

        }

        public int UpdateCategory(Models.DomainModels.Contact Contact)
        {
            contactRepository.Update(Contact);
            contactRepository.SaveChanges();

            return Contact.ContactID;
        }

        public IEnumerable<Models.DomainModels.Contact> GetAllContacts()
        {
            return contactRepository.GetAll().ToList();

        }

        public Contact GetContactById(int id)
        {
            return contactRepository.Find(id);
        }

        //public ProductCategoryResponse GetProductCategoryResponse(int? id)
        //{
        //    ProductCategoryResponse prodCateResp = new ProductCategoryResponse();
        //    if (id != null)
        //    {
        //        prodCateResp.ProductCategory = prodCategoryRepository.Find((int)id);
        //    }
        //    prodCateResp.ProductCategories = prodCategoryRepository.GetAll();
        //    return prodCateResp;
        //}
    }
}