using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _SliderPartial : ViewComponent
    {
		DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
		Context c = new Context();
		public IViewComponentResult Invoke()
        {
            List<SelectListItem> values = (from x in destinationManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationID.ToString()
                                           }).ToList();
            ViewBag.destList = values;
            return View();
        }
    }
}
