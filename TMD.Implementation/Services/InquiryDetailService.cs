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
    public class InquiryDetailService : IInquiryDetailService
    {
        private readonly IInquiryDetailRepository inquiryDetailRepository;

        public InquiryDetailService(IInquiryDetailRepository inquiryDetailRepository)
        {
            this.inquiryDetailRepository = inquiryDetailRepository;
           

        }
        public int AddInquiryDetail(Models.DomainModels.InquiryDetail inquiryDetail)
        {

            inquiryDetailRepository.Add(inquiryDetail);
            inquiryDetailRepository.SaveChanges();

            return inquiryDetail.InquiryDetailID; // If Exception occurs this line will not be executed

        }

        public int UpdateInquiryDetail(Models.DomainModels.InquiryDetail inquiryDetail)
        {
            inquiryDetailRepository.Update(inquiryDetail);
            inquiryDetailRepository.SaveChanges();

            return inquiryDetail.InquiryDetailID;
        }

        public IEnumerable<Models.DomainModels.InquiryDetail> GetInquiryDetailByInquiryId(int id)
        {
           // return inquiryDetailRepository.GetAll().Select(x => x.InquiryID(x.InquiryID == id).ToList());
            return null;

        }

        public InquiryDetail GeInquiryById(int id)
        {
            return inquiryDetailRepository.Find(id);
        }

       
    }
}

