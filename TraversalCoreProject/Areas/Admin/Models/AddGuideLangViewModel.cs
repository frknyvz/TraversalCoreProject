using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TraversalCoreProject.Areas.Admin.Models
{
    public class AddGuideLangViewModel
    {
        public Guide Guide { get; set; }
        public List<SelectListItem> Languages { get; set; }

    }
}
