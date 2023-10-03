using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/User")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;
        private readonly ICommentService _commentService;

        public UserController(IAppUserService appUserService, IReservationService reservationService, ICommentService commentService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
            _commentService = commentService;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _appUserService.TGetList();
            return View(values);
        }

        [Route("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var values = _appUserService.TGetByID(id);
            _appUserService.TDelete(values);
            return RedirectToAction("Index");
        }

        [Route("EditUser/{id}")]
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values = _appUserService.TGetByID(id);
            return View(values);
        }

        [Route("EditUser/{id}")]
        [HttpPost]
        public IActionResult EditUser(AppUser p)
        {
            _appUserService.TUpdate(p);
            return RedirectToAction("Index");
        }

        [Route("CommentUser/{id}")]
        public IActionResult CommentUser(int id)
        {
            var values = _commentService.TGetListWithCommentById(id);
            return View(values);
        }

        [Route("ReservationUser/{id}")]
        public IActionResult ReservationUser(int id)
        {
            var values = _reservationService.GetListWithReservationByAccepted(id);
            return View(values);
        }
    }
}
