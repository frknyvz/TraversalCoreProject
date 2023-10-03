using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Destination")]
    [Authorize(Roles = "Admin")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }

        [Route("AddDestination")]
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [Route("AddDestination")]
        [HttpPost]
        public IActionResult AddDestination(Destination p)
        {
            _destinationService.TAdd(p);
            return RedirectToAction("Index");
        }

        [Route("DeleteDestination/{id}")]
        public IActionResult DeleteDestination(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return RedirectToAction("Index");
        }

        [Route("UpdateDestination/{id}")]
        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var values = _destinationService.TGetByID(id);
            return View(values);
        }

        [Route("UpdateDestination/{id}")]
        [HttpPost]
        public IActionResult UpdateDestination(Destination p)
        {
            _destinationService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
