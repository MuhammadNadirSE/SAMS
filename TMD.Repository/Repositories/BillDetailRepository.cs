using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.Common;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    internal class BillDetailRepository : BaseRepository<BillDetail>, IBillDetailRepository
    {
        public BillDetailRepository(IUnityContainer container) : base(container)
        {
        }

        protected override IDbSet<BillDetail> DbSet
        {
            get { return db.BillDetails; }
        }

        #region Private

        private readonly Dictionary<BillDetailByColumn, Func<BillDetail, object>> orderClause =

            new Dictionary<BillDetailByColumn, Func<BillDetail, object>>
            {
                {BillDetailByColumn.BillDetailId, c => c.BillDetailId},
                {BillDetailByColumn.AccountNumber, c => c.Client.AccountNumber},
                {BillDetailByColumn.BillIssueDate, c => c.BillIssueDate},
                {BillDetailByColumn.ServiceNumber, c => c.ServiceNumber},
                {BillDetailByColumn.ServiceType, c => c.BillDetailChargeType.ChargeTypeName},
                {BillDetailByColumn.ChargeType, c => c.BillDetailChargeType.ChargeTypeName},
                {BillDetailByColumn.Description, c => c.Description},
                {BillDetailByColumn.Quantity, c => c.Quantity},
                {BillDetailByColumn.InclGst, c => c.InclGst},
            };

        #endregion

        public BillDetailResponse GetAllBillDetails(BillDetailSearchRequest searchRequest)
        {
            int fromRow = (searchRequest.PageNo - 1) * searchRequest.PageSize;
            int toRow = searchRequest.PageSize;

            Expression<Func<BillDetail, bool>> query =
                s =>
                    (((searchRequest.BillDetailId == 0) || s.BillDetailId == searchRequest.BillDetailId ||
                      s.BillDetailId.Equals(searchRequest.Id)) ||
                     (searchRequest.AccountNumber == 0 || s.Client.AccountNumber == searchRequest.AccountNumber) ||
                     (searchRequest.BillIssueDate == null || s.BillIssueDate == searchRequest.BillIssueDate) ||
                     (searchRequest.ServiceNumber == 0 || s.ServiceNumber == searchRequest.ServiceNumber) ||
                     (string.IsNullOrEmpty(searchRequest.ServiceType) || s.BillDetailServiceType.ServiceTypeName.Equals(searchRequest.ServiceType)) ||
                     (string.IsNullOrEmpty(searchRequest.ChargeType) || s.BillDetailChargeType.ChargeTypeName.Equals(searchRequest.ChargeType)) ||
                     (string.IsNullOrEmpty(searchRequest.Description) || s.Description.Equals(searchRequest.Description)) ||
                     (searchRequest.Quantity == null || s.Quantity == searchRequest.Quantity) ||
                     (searchRequest.InclGst == null || s.InclGst == searchRequest.InclGst));

            IEnumerable<BillDetail> details = searchRequest.IsAsc
                ? DbSet
                    .Where(query)
                    .OrderBy(orderClause[searchRequest.BillDetailByColumn])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet
                    .Where(query)
                    .OrderByDescending(orderClause[searchRequest.BillDetailByColumn])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();

            return new BillDetailResponse { BillDetails = details, TotalCount = DbSet.Count(query), FilteredCount = DbSet.Count(query) };
        }
    }
}