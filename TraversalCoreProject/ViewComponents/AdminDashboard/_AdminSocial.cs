using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TraversalCoreProject.ViewComponents.AdminDashboard
{
    public class _AdminSocial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
