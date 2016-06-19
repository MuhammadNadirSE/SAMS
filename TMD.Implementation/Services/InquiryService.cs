using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Common;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;
using TMD.Repository.Repositories;

namespace TMD.Implementation.Services
{
    public class InquiryService : IInquiryService
    {
        private readonly INotificationService notificationService;
        private readonly IInquiryRepository inquiryRepository;
        private readonly IDocumentService documentService;
        private readonly IContactRepository contactRepository;
        private readonly IProductRepository productRepository;
        private readonly IInquiryDetailRepository inquiryDetailRepository;


        public InquiryService(INotificationService notificationService,IInquiryRepository inquiryRepository,IDocumentService documentService, IContactRepository contactRepository, IProductRepository productRepository, IInquiryDetailRepository inquiryDetailRepository)
        {
            this.notificationService = notificationService;
            this.inquiryRepository = inquiryRepository;
            this.documentService = documentService;
            this.contactRepository = contactRepository;
            this.productRepository = productRepository;
            this.inquiryDetailRepository = inquiryDetailRepository;

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
                inquiryResponse.InquiryDetails = inquiryDetailRepository.GetInquiryDailByByInquiryId((int)id).ToList();
                inquiryResponse.InquiryDocuments = documentService.GetAllDocumentByRefId((int) id, (int)DocumentType.Inquiry).ToList();
            }
            inquiryResponse.Contacts = contactRepository.GetAll().ToList();
            inquiryResponse.Products = productRepository.GetAll().ToList();
            

            return inquiryResponse;
        }

        public Inquiry GetInquiryAndInquiryDetail(int InquiryId)
        {
            return inquiryRepository.GetInquiryAndInquiryDetail(InquiryId);
        }

        public bool SaveInquiry(InquiryResponse inquiryResp)
        {
            bool isCreated = true;
            if (inquiryResp.Inquiry.InquiryID > 0)
            {
                inquiryRepository.Update(inquiryResp.Inquiry);
                isCreated = false;
            }
            else
            {
                inquiryRepository.Add(inquiryResp.Inquiry);
            }
            inquiryRepository.SaveChanges();

            SaveInquiryDetails(inquiryResp);
            documentService.AddDocuments(inquiryResp.InquiryDocuments, inquiryResp.Inquiry.InquiryID,DocumentType.Inquiry);

            //Send Notification
            notificationService.AddNotification(new Notification
            {
                CategoryId = (int)NotificationType.Inquiry,
                ItemId = inquiryResp.Inquiry.InquiryID,
                ActionPerformed = isCreated?(int)ActionPerformed.Created: (int)ActionPerformed.Updated,
                CreatedBy = inquiryResp.Inquiry.UpdatedBy,
                CreatedDate = DateTime.UtcNow,
                Title = "Inquiry - " + (inquiryResp.Inquiry.CompanyName.Length>35? inquiryResp.Inquiry.CompanyName.Substring(0,35) + "..." : inquiryResp.Inquiry.CompanyName)
            });
            return true;
        }

        private void SaveInquiryDetails(InquiryResponse inquiryResp)
        {
            if (inquiryResp.Inquiry.InquiryID > 0)
            {
                var inquiryDetails = inquiryDetailRepository.GetInquiryDailByByInquiryId(inquiryResp.Inquiry.InquiryID).ToList();

                foreach (var inquirydetail in inquiryDetails)
                {
                    inquiryDetailRepository.Delete(inquirydetail);
                }
            }
            if (inquiryResp.InquiryDetails != null && inquiryResp.InquiryDetails.Any())
            {
                foreach (var inquiryDetail in inquiryResp.InquiryDetails)
                {
                    inquiryDetail.InquiryID = inquiryResp.Inquiry.InquiryID;

                    inquiryDetailRepository.Add(inquiryDetail);
                }
            }
            inquiryDetailRepository.SaveChanges();
        }
        public InquiryResponse GetAllInquiries(InquirySearchRequest searchRequest)
        {
            var inquiries = inquiryRepository.GetAllInquiries(searchRequest);
            return inquiries;
        }
    }
}
