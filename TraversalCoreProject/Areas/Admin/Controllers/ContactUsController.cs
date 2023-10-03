using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ContactUs")]
    [Authorize(Roles = "Admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _contactUsService.TGetList();
            return View(values);
        }

        [Route("DeleteMessage/{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var values = _contactUsService.TGetByID(id);
            _contactUsService.TDelete(values);
            return RedirectToAction("Index", "ContactUs", new { area = "Admin" });
        }
    }
}
