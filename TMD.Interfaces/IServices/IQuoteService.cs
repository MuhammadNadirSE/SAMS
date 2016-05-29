using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Models.DomainModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IServices
{
    public interface IQuoteService
    {
        int AddQuote(Quote model);
        int UpdateQuote(Quote model);        
        QuoteResponse GetQuoteResponse(int? id);
        Quote GetQuoteAndQuoteDetail(int quoteId);
        bool SaveQuote(Quote model);

        //QuoteResponse GetAllInquiries(QuoteSearchRequest searchRequest);
    }
}
