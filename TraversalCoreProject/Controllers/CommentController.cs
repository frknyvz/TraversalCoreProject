using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TraversalCoreProject.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        private readonly UserManager<AppUser> _userManager;
        public CommentController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            // ViewBag.destID = id;
            //var value = await _userManager.FindByNameAsync(User.Identity.Name);
            //ViewBag.userID = 5;
            // ViewBag.a = "merhaba";
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(Comment p, Destination d)
        {
            var destId = d.DestinationID;
            p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.CommentState = true;
            commentManager.TAdd(p);
            return RedirectToAction("DestinationDetails", "Destination", new { id = destId });
        }
    }
}
