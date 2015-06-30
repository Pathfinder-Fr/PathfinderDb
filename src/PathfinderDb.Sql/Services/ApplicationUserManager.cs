using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PathfinderDb.Datas;
using PathfinderDb.Models;
using PathfinderDb.Services;

namespace PathfinderDb.Services
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        private IApplicationUserStore appStore;

        public ApplicationUserManager(IApplicationUserStore store, IdentityFactoryOptions<ApplicationUserManager> options)
        : base(store)
        {
            this.appStore = store;

            // Configure validation logic for usernames
            this.UserValidator = new ApplicationUserValidator(this)
            {                        
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            

            // Configure validation logic for passwords
            this.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Configure user lockout defaults
            this.UserLockoutEnabledByDefault = true;
            this.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            this.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            //this.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            //{
            //    MessageFormat = "Your security code is {0}"
            //});
            this.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<IApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            this.EmailService = new EmailService();
            this.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                this.UserTokenProvider = new DataProtectorTokenProvider<IApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
        }

        public IApplicationUser New(string email, bool confirmed = false)
        {
            return this.appStore.New(email, confirmed);
        }

        private class ApplicationUserValidator : UserValidator<IApplicationUser>
        {
            public ApplicationUserValidator(ApplicationUserManager manager)
                :base(manager)
            {
            }
        }
    }
}
