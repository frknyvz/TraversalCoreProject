using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.MemberDashboard
{
    public class _ProfileInformation : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
