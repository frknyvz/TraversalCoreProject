using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }
        public async Task<IActionResult> DestinationDetailsAsync(int id)
        {
            ViewBag.i = id;
            ViewBag.destID = id;
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Login");
            }
            else
            {
                var value = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.userID = value.Id;
            }
            var values = destinationManager.TGetDestinationWithGuide(id);
            return View(values);
        }
    }
}
