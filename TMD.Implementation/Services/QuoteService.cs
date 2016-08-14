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
    public class QuoteService : IQuoteService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly INotificationService notificationService;
        private readonly IExclusionRepository exclusionRepository;
        private readonly IQuoteRepository quoteRepository;
        private readonly IQuoteDetailRepository quoteDetailRepository;
        private readonly IQuoteExclusionRepository quoteExclusionRepository;
        private readonly IContactRepository contactRepository;
        private readonly IProductRepository productRepository;
        private readonly IProductModelRepository productModelRepository;

        public QuoteService(IEmployeeRepository employeeRepository,INotificationService notificationService,IExclusionRepository exclusionRepository,IQuoteRepository quoteRepository, IQuoteDetailRepository quoteDetailRepository, IQuoteExclusionRepository quoteExclusionRepository, IContactRepository contactRepository, IProductRepository productRepository, IProductModelRepository productModelRepository)
        {
            this.employeeRepository = employeeRepository;
            this.notificationService = notificationService;
            this.exclusionRepository = exclusionRepository;
            this.quoteRepository = quoteRepository;
            this.quoteDetailRepository = quoteDetailRepository;
            this.quoteExclusionRepository = quoteExclusionRepository;
            this.contactRepository = contactRepository;
            this.productRepository = productRepository;
            this.productModelRepository = productModelRepository;
        }
        public int AddQuote(Quote model)
        {

            quoteRepository.Add(model);
            quoteRepository.SaveChanges();

            return model.QuoteID; // If Exception occurs this line will not be executed

        }

        public int UpdateQuote(Quote model)
        {
            quoteRepository.Update(model);
            quoteRepository.SaveChanges();

            return model.QuoteID;
        }

        public QuoteResponse GetQuoteResponse(int? id)
        {
            QuoteResponse response = new QuoteResponse();
            if (id != null)
            {
                response.Quote = quoteRepository.GetQuoteAndQuoteDetail((int)id);
            }
            else
            {
                response.QuoteCount = quoteRepository.GetAll().Count()+1;
            }

            //BaseData
            response.Contacts = contactRepository.GetAll().ToList();
            response.Products = productRepository.GetAll().ToList();
            response.ProductModels = productModelRepository.GetAll().ToList();
            response.Exclusions = exclusionRepository.GetAll().ToList();
         

            return response;
        }

        public Quote GetQuoteAndQuoteDetail(int quoteId)
        {
            return quoteRepository.GetQuoteAndQuoteDetail(quoteId);
        }

        public bool SaveQuote(Quote model)
        {
            try
            {
                bool isCreated = true;
                if (model.QuoteID > 0)
                {
                    UpdateQuote(model);
                    SaveQuoteDetails(model);
                    SaveQuoteExclusions(model);
                    isCreated = false;
                }
                else
                {
                    AddQuote(model);
                    string ModelNo = Convert.ToString(model.QuoteID).PadLeft(3, '0');

                    model.QuoteReferenceNo = "ZAM-" + ModelNo;
                    UpdateQuote(model);
                }

                //Send Notification
                notificationService.AddNotification(new Notification
                {
                    CategoryId = (int)NotificationType.Quote,
                    ItemId = model.QuoteID,
                    ActionPerformed = isCreated ? (int)ActionPerformed.Created : (int)ActionPerformed.Updated,
                    CreatedBy = model.UpdatedBy,
                    CreatedDate = DateTime.UtcNow,
                    Title = "Quote - " + (model.QuoteReferenceNo.Length > 35 ? model.QuoteReferenceNo.Substring(0, 35) + "..." : model.QuoteReferenceNo)
                });
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void SaveQuoteDetails(Quote model)
        {
            if (model.QuoteID > 0)
            {
                var details = quoteDetailRepository.GetQuoteDetailByQuoteId(model.QuoteID).ToList();

                foreach (var detail in details)
                {
                    quoteDetailRepository.Delete(detail);
                }
            }
            if (model.QuoteDetails != null && model.QuoteDetails.Any())
            {
                foreach (var detail in model.QuoteDetails)
                {
                    detail.QuoteId = model.QuoteID;

                    quoteDetailRepository.Add(detail);
                }
            }
            quoteDetailRepository.SaveChanges();
        }

        private void SaveQuoteExclusions(Quote model)
        {
            if (model.QuoteID > 0)
            {
                var details = quoteExclusionRepository.GetQuoteExclusionsByQuoteId(model.QuoteID).ToList();

                foreach (var detail in details)
                {
                    quoteExclusionRepository.Delete(detail);
                }
            }
            if (model.QuoteExclusions != null && model.QuoteExclusions.Any())
            {
                foreach (var detail in model.QuoteExclusions)
                {
                    detail.QuoteId = model.QuoteID;

                    quoteExclusionRepository.Add(detail);
                }
            }
            quoteExclusionRepository.SaveChanges();
        }
        public QuoteResponse GetAllQuotes(QuoteSearchRequest searchRequest)
        {
            var inquiries = quoteRepository.GetAllQuotes(searchRequest);
            return inquiries;
        }
    }
}
