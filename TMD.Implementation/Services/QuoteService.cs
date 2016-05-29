using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly IQuoteRepository quoteRepository;
        private readonly IQuoteDetailRepository quoteDetailRepository;
        private readonly IQuoteExclusionRepository quoteExclusionRepository;
        private readonly IContactRepository contactRepository;
        private readonly IProductRepository productRepository;
        private readonly IProductModelRepository productModelRepository;

        public QuoteService(IQuoteRepository quoteRepository, IQuoteDetailRepository quoteDetailRepository, IQuoteExclusionRepository quoteExclusionRepository, IContactRepository contactRepository, IProductRepository productRepository, IProductModelRepository productModelRepository)
        {
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

            //BaseData
            response.Contacts = contactRepository.GetAll().ToList();
            response.Products = productRepository.GetAll().ToList();
            response.ProductModels = productModelRepository.GetAll().ToList();

            return response;
        }

        public Quote GetQuoteAndQuoteDetail(int quoteId)
        {
            return quoteRepository.GetQuoteAndQuoteDetail(quoteId);
        }

        public bool SaveQuote(Quote model)
        {
            if (model.QuoteID > 0)
            {
                AddQuote(model);
            }
            else
            {
                UpdateQuote(model);
            }
            SaveQuoteDetails(model);
            SaveQuoteExclusions(model);

            return true;
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
    }
}
