using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.Common;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.Resources;
using TMD.Models.ResponseModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public class EmployeePayrollRepository : BaseRepository<EmployeePayroll>, IEmployeePayrollRepository
    {
        #region Constructor
        public EmployeePayrollRepository(IUnityContainer container)
            : base(container)
        {
        }

        protected override IDbSet<EmployeePayroll> DbSet
        {
            get { return db.EmployeePayrolls; }
        }
        #endregion

        #region Private
        private static readonly long basicSalaryId = Convert.ToInt64(ConfigurationManager.AppSettings["BasicSalaryId"].ToString());
        private readonly Dictionary<OrderByColumnPayroll, Func<EmployeePayroll, object>> orderClause =

            new Dictionary<OrderByColumnPayroll, Func<EmployeePayroll, object>>
            {
                {OrderByColumnPayroll.Date, c => c.AllowanceMonth},
                {OrderByColumnPayroll.Employee, c => c.EmployeeId},
                {OrderByColumnPayroll.BasicSalary, c => c.AllowanceTypeId.Equals(basicSalaryId)},
            };
        #endregion

        #region Public
        public EmployeePayroll GetPayroll()
        {
            return DbSet.FirstOrDefault(x => x.EmployeeId == 1);
        }

        public IEnumerable<EmployeePayroll> GetCurrentDatePayrollData()
        {
            return DbSet.Where(x => x.RecCreatedDate.Equals(DateTime.Today));
        }

        public IEnumerable<EmployeePayroll> GetPayrollByEmployeeId(int employeeId, DateTime month)
        {
            return DbSet.Where(x => x.EmployeeId.Equals(employeeId) && (x.AllowanceMonth.Month.Equals(month.Month) && x.AllowanceMonth.Year.Equals(month.Year)));
        }

        public PayrollResponse GetAllPayrolls(PayrollSearchRequest payrollSearchRequest)
        {
            int fromRow = (payrollSearchRequest.PageNo - 1) * payrollSearchRequest.PageSize;
            int toRow = payrollSearchRequest.PageSize;
            if (payrollSearchRequest.Date.Year.Equals(1))
                payrollSearchRequest.Date = DateTime.UtcNow;
            Expression<Func<EmployeePayroll, bool>> query =
                s =>
                    (
                    (payrollSearchRequest.EmployeeId == 0 || payrollSearchRequest.EmployeeId.Equals(s.EmployeeId)) &&
                    ((payrollSearchRequest.Date.Month.Equals(s.AllowanceMonth.Month) && (payrollSearchRequest.Date.Year.Equals(s.AllowanceMonth.Year))))
                    );

            var basicSalaryId = Convert.ToInt64(ConfigurationManager.AppSettings["BasicSalaryId"].ToString());
             IEnumerable<PayRollGroupByModel> payrolls = payrollSearchRequest.IsAsc
                ? DbSet
                    .Where(query)
                    .OrderBy(orderClause[payrollSearchRequest.OrderByColumn])
                    .Skip(fromRow)
                    .Take(toRow)
                    .GroupBy(x => new { x.EmployeeId })
                    .Select(x => new PayRollGroupByModel
                    {
                        EmployeeId = x.Key.EmployeeId,
                        TotalAllowances = x.Where(y=>y.AllowanceTypeId!=basicSalaryId).Sum(z=>z.Amount), 
                        EmployeeName = x.First().Employee.FullName,
                        AllowanceDate = x.First().AllowanceMonth,
                        BasicSalary = x.First(y => y.AllowanceTypeId.Equals(basicSalaryId)).Amount,
                        TotalAmount = x.Sum(y => y.Amount)
                    })
                    .ToList()
                : DbSet
                    .Where(query)
                    .OrderBy(orderClause[payrollSearchRequest.OrderByColumn])
                    .GroupBy(x => new { x.EmployeeId})
                    .Select(x => new PayRollGroupByModel
                    {
                        EmployeeId = x.Key.EmployeeId,
                        TotalAllowances = x.Where(y => y.AllowanceTypeId != basicSalaryId).Sum(z => z.Amount),
                        EmployeeName = x.First().Employee.FullName,
                        AllowanceDate = x.First().AllowanceMonth,
                        BasicSalary = x.First(y => y.AllowanceTypeId.Equals(basicSalaryId)).Amount,
                        TotalAmount = x.Sum(y => y.Amount)
                    })
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
            return new PayrollResponse { EmployeePayrollGroupBy = payrolls.ToList() , TotalCount = DbSet.Count(query), FilteredCount = DbSet.Count(query) };
        }

        #endregion
    }
}
