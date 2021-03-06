﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IRepository
{
    public interface IQuoteRepository : IBaseRepository<Quote, int>
    {
        QuoteResponse GetAllQuotes(QuoteSearchRequest searchRequest);
        Quote GetQuoteAndQuoteDetail(int quoteId);
    }
}
