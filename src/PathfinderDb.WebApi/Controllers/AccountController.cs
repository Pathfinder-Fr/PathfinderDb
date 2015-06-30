using System.Threading.Tasks;
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

        [HttpPost]
        public async void Register(AccountRegisterViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = this.userManager.New(model.Email, true);

                var result = await this.userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await this.signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Login(string userName, string password)
        {
            var user = await this.userManager.FindAsync(userName, password);
            if (user == null)
            {
                return this.NotFound();
            }

            await this.signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

            return Ok();
        }
    }
}
