using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;
using TMD.Repository.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Practices.Unity;

namespace TMD.Implementation.Identity
{
    /// <summary>
    /// Application User Manager
    /// </summary>
    public class ApplicationUserManager : UserManager<AspNetUser, string>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ApplicationUserManager(IUserStore<AspNetUser, string> store)
            : base(store)
        {
        }

        /// <summary>
        /// Send Email
        /// </summary>
        /// <param name="email">email of reciever</param>
        /// <param name="subject">Subject Of the Email</param>
        /// <param name="body">Body message of email</param>
        /// <returns></returns>
        public override Task SendEmailAsync(string email ,string subject, string body)
        {

            string fromAddress = ConfigurationManager.AppSettings["FromAddress"];
            string fromPwd = ConfigurationManager.AppSettings["FromPassword"];
            string fromDisplayName = ConfigurationManager.AppSettings["FromDisplayName"];
            //string cc = ConfigurationManager.AppSettings["CC"];
            string bcc = ConfigurationManager.AppSettings["BCC"];

            //Getting the file from config, to send
            MailMessage oEmail = new MailMessage
            {
                From = new MailAddress(fromAddress, fromDisplayName),
                Subject = subject,
                IsBodyHtml = true,
                Body = body,
                Priority = MailPriority.High,
                
                
            };
            oEmail.Bcc.Add(bcc);
            oEmail.To.Add(email);
            string smtpServer = ConfigurationManager.AppSettings["SMTPServer"];
            string smtpPort = ConfigurationManager.AppSettings["SMTPPort"];
            string enableSsl = ConfigurationManager.AppSettings["EnableSSL"];
            SmtpClient client = new SmtpClient(smtpServer, Convert.ToInt32(smtpPort))
            {
                EnableSsl = enableSsl == "1",
                Credentials = new NetworkCredential(fromAddress, fromPwd)
            };

            return client.SendMailAsync(oEmail);

        }

        /// <summary>
        /// Send Attendance Notification Email
        /// </summary>
        /// <param name="email">Email of Reciever</param>
        /// <param name="supervisorsEmails">Email id's ofsupervisors (,) separated</param>
        /// <param name="subject">Subject Of Email</param>
        /// <param name="body">Body Of Email</param>
        /// <returns></returns>
        public void SendAttendanceEmailAsync(string email, string subject, string body, string supervisorsEmails="")
        {
            string fromAddress = ConfigurationManager.AppSettings["FromAddress"];
            string fromPwd = ConfigurationManager.AppSettings["FromPassword"];
            string fromDisplayName = ConfigurationManager.AppSettings["FromDisplayName"];
            //string cc = ConfigurationManager.AppSettings["CC"];
            string bcc = ConfigurationManager.AppSettings["BCC"];

            MailMessage oEmail = new MailMessage
            {
                From = new MailAddress(fromAddress, fromDisplayName),
                Subject = subject,
                IsBodyHtml = true,
                Body = body,
                Priority = MailPriority.High,
            };

            if(!string.IsNullOrEmpty(supervisorsEmails))
                oEmail.CC.Add(supervisorsEmails);

            if (!string.IsNullOrEmpty(bcc))
                oEmail.Bcc.Add(bcc);

            oEmail.To.Add(email);

            string smtpServer = ConfigurationManager.AppSettings["SMTPServer"];
            string smtpPort = ConfigurationManager.AppSettings["SMTPPort"];
            string enableSsl = ConfigurationManager.AppSettings["EnableSSL"];
            SmtpClient client = new SmtpClient(smtpServer, Convert.ToInt32(smtpPort))
            {
                EnableSsl = enableSsl == "1",
                Credentials = new NetworkCredential(fromAddress, fromPwd)
            };

            client.Send(oEmail);
        }

        /// <summary>
        /// Create User
        /// </summary>
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["BaseDbContext"].ConnectionString;


            BaseDbContext db = (BaseDbContext)UnityConfig.UnityContainer.Resolve(typeof(BaseDbContext),
                new ResolverOverride[] { new ParameterOverride("connectionString", connectionString) });

            var manager = new ApplicationUserManager(new UserStore(db));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<AspNetUser, string>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };
            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = false;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<AspNetUser, string>
            {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<AspNetUser, string>
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<AspNetUser, string>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

    }
}