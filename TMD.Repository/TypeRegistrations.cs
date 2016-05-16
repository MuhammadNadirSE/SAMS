using System.Data.Entity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;
using TMD.Repository.Repositories;
using Microsoft.Practices.Unity;
namespace TMD.Repository
{
    public static class TypeRegistrations
    {
        public static void RegisterType(IUnityContainer unityContainer)
        {

            unityContainer.RegisterType<IAspNetUserRepository, AspNetUserRepository>();
            unityContainer.RegisterType<DbContext, BaseDbContext>(new PerRequestLifetimeManager());
            unityContainer.RegisterType<IAspNetRoleRepository, AspNetRoleRepository>();
            unityContainer.RegisterType<IEmployeeRepository, EmployeeRepository>();
            unityContainer.RegisterType<IDesignationRepository, DesignationRepository>();
            unityContainer.RegisterType<IEmployeeSupervisorRepository, EmployeeSupervisorRepository>();
            unityContainer.RegisterType<ITicketRepository, TicketRepository>();
            unityContainer.RegisterType<ITicketTypeRepository, TicketTypeRepository>();
            unityContainer.RegisterType<IMenuRepository, MenuRepository>();
            unityContainer.RegisterType<IMenuRightRepository, MenuRightRepository>();
            unityContainer.RegisterType<IAttendanceRepository, AttendanceRepository>();
            unityContainer.RegisterType<ILeaveRepository, LeaveRepository>();
            unityContainer.RegisterType<IAllowanceTypeRepository, AllowanceTypeRepository>();
            unityContainer.RegisterType<IEmployeePayrollRepository, EmployeePayrollRepository>();
            unityContainer.RegisterType<IClientRepository, ClientRepository>();
            unityContainer.RegisterType<IDistributorRepository, DistributorRepository>();
            unityContainer.RegisterType<IBillDetailRepository, BillDetailRepository>();
            unityContainer.RegisterType<IProductCategoryRepository, ProductCategoryRepository>();
            unityContainer.RegisterType<IContactRepository, ContactRepository>();
            unityContainer.RegisterType<IAddressRepository, AddressRepository>();
            unityContainer.RegisterType<INotificationRepository, NotificationRepository>();
            unityContainer.RegisterType<INotificationRecipientRepository, NotificationRecipientRepository>();
            unityContainer.RegisterType<IProductRepository, ProductRepository>();
            unityContainer.RegisterType<ITechnicalSpecsRepository, TechnicalSpecsRepository>();
            unityContainer.RegisterType<IInquiryRepository, InquiryRepository>();
            unityContainer.RegisterType<IInquiryDetailRepository, InquiryDetailRepository>();
            unityContainer.RegisterType<IProductModelRepository, ProductModelRepository>();
            unityContainer.RegisterType<IProductTechnicalSpecsRepository, ProductTechnicalSpecsRepository>();
        }
    }
}
