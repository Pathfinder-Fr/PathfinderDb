using System.Web.Http;
using PathfinderDb.Services;
using PathfinderDb.ViewModels;

namespace PathfinderDb.Controllers
{
    public class AccountController : ApiController
    {
        private ApplicationUserManager userManager;

        private ApplicationSignInManager signInManager;

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public string Register(AccountRegisterViewModel model)
        {
            //if(this.ModelState.IsValid)
            //{
            //    var user = this.userManager.New();
            //    user.UserName = model.Email;
            //    user.Email = model.Email;

            //    var result = await this.userManager.CreateAsync(user, model.Password);
            //    if (result.Succeeded)
            //    {
            //        await this.signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

            //        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
            //        // Send an email with this link
            //        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
            //        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
            //        // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

            //        return RedirectToAction("Index", "Home");
            //    }
            //    AddErrors(result);
            //}

            return "Hello World!";
        }
    }
}
