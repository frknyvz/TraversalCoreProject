using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.MemberDashboard
{
    public class _RouteSlide : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
