using TMD.Implementation.Identity;
using TMD.Implementation.Services;
using TMD.Interfaces.IServices;
using TMD.Models.IdentityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;

namespace TMD.Implementation
{
    public static class TypeRegistrations
    {
        public static void RegisterType(IUnityContainer unityContainer)
        {
            UnityConfig.UnityContainer = unityContainer;
            Repository.TypeRegistrations.RegisterType(unityContainer);
            unityContainer.RegisterType<ILogger, LoggerService>();
            unityContainer.RegisterType<IAspNetUserService, AspNetUserService>();
            unityContainer.RegisterType<IAspNetRoleService, AspNetRoleService>();

            unityContainer.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            unityContainer.RegisterType<IEmployeeService, EmployeeService>();
            unityContainer.RegisterType<IDesignationService, DesignationService>();
            unityContainer.RegisterType<IEmployeeSupervisorService, EmployeeSupervisorService>();
            unityContainer.RegisterType<ITicketService, TicketService>();
            unityContainer.RegisterType<ITicketTypeService, TicketTypeService>();
            unityContainer.RegisterType<IMenuRightsService, MenuRightsService>();
            unityContainer.RegisterType<IAttendanceService, AttendanceService>();
            unityContainer.RegisterType<ILeaveService, LeaveService>();
            unityContainer.RegisterType<IAllowanceTypeService, AllowanceTypeService>();
            unityContainer.RegisterType<IEmployeePayrollService, EmployeePayrollService>();
            unityContainer.RegisterType<IClientService, ClientService>();
            unityContainer.RegisterType<IDistributorService, DistributorService>();
            unityContainer.RegisterType<IBillDetailService, BillDetailService>();
            unityContainer.RegisterType<IProductCategoryService, ProductCategoryService>();
            unityContainer.RegisterType<IContactService, ContactService>();
            unityContainer.RegisterType<INotificationService, NotificationService>();
            unityContainer.RegisterType<IProductService, ProductService>();
            unityContainer.RegisterType<ITechnicalSpecsService, TechnicalSpecsService>();
            unityContainer.RegisterType<IInquiryService, InquiryService>();
            unityContainer.RegisterType<IInquiryDetailService, InquiryDetailService>();
            unityContainer.RegisterType<IProductModelService, ProductModelService>();
            unityContainer.RegisterType<IExclusionService, ExclusionService>();
            unityContainer.RegisterType<IQuoteService, QuoteService>();
            unityContainer.RegisterType<IDocumentService, DocumentService>();
        } 
    }
}
