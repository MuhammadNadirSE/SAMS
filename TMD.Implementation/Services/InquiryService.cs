using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;
using TMD.Repository.Repositories;

namespace TMD.Implementation.Services
{
    public class InquiryService : IInquiryService
    {
        private readonly IInquiryRepository inquiryRepository;
        private readonly IContactRepository contactRepository;

        public InquiryService(IInquiryRepository inquiryRepository, IContactRepository contactRepository)
        {
            this.inquiryRepository = inquiryRepository;
            this.contactRepository = contactRepository;

        }
        public int AddInquiry(Models.DomainModels.Inquiry inquiry)
        {

            inquiryRepository.Add(inquiry);
            inquiryRepository.SaveChanges();

            return inquiry.InquiryID; // If Exception occurs this line will not be executed

        }

        public int UpdateInquiry(Models.DomainModels.Inquiry inquiry)
        {
            inquiryRepository.Update(inquiry);
            inquiryRepository.SaveChanges();

            return inquiry.InquiryID;
        }

        public IEnumerable<Models.DomainModels.Inquiry> GetAllInquiries()
        {
            return inquiryRepository.GetAll().ToList();

        }

        public Inquiry GeInquiryById(int id)
        {
            return inquiryRepository.Find(id);
        }

        public InquiryResponse GetInquiryResponse(int? id)
        {
            InquiryResponse inquiryResponse = new InquiryResponse();
            if (id != null)
            {
                inquiryResponse.Inquiry = inquiryRepository.Find((int)id);
            }
            inquiryResponse.Contacts = contactRepository.GetAll();
            return inquiryResponse;
        }
    }
}
