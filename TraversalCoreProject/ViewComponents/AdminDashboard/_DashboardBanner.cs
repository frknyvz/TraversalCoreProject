using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProject.ViewComponents.AdminDashboard
{
    public class _DashboardBanner : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.visitorCount = c.Testimonials.Count();
            ViewBag.userCount = c.Users.Where(x => x.Gender == "E" || x.Gender == "K").Count();
            return View();
        }
    }
}
