using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TraversalCoreProject.Areas.Member.Models;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]

    public class CalendarController : Controller
    {
        private static List<CalendarEventViewModel> Events;

        public CalendarController()
        {
            Events = new List<CalendarEventViewModel>();


            Events.Add(new CalendarEventViewModel
            {
                Title = $"Toplantı",
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(2),
                AllDay = false
            });
            Events.Add(new CalendarEventViewModel
            {
                Title = $"Yemek",
                Start = DateTime.Now.AddDays(5),
                AllDay = true
            });
            Events.Add(new CalendarEventViewModel
            {
                Title = $"Toplantı",
                Start = DateTime.Now.AddDays(10),
                End = DateTime.Now.AddDays(10).AddHours(1),
                AllDay = false
            });
            Events.Add(new CalendarEventViewModel
            {
                Title = $"İş Görüşmesi",
                Start = DateTime.Now.AddMonths(1).AddDays(1),
                End = DateTime.Now.AddMonths(1).AddDays(1).AddHours(1),
                AllDay = false
            });
            Events.Add(new CalendarEventViewModel
            {
                Title = $"Şirket Etkinliği",
                Start = DateTime.Now.AddMonths(1).AddDays(10),
                AllDay = true
            });
        }
        public IActionResult Index()
        {
            var titleList = Events.GroupBy(x=>x.Title).Select(x => x.Key).ToList();
            ViewBag.TitleList = titleList;
            return View();
        }

        [HttpPost]
        public IActionResult GetData()
        {
            var form = HttpContext.Request.Form;
            var startDate = DateTime.Parse(form["start"]);
            var endDate = DateTime.Parse(form["end"]);
            var title = form["title"].ToString();

            List<CalendarEventViewModel> filteredList;
            if (string.IsNullOrEmpty(title)) //Title seçilmediyse tüm etkinlikleri listele
            {
                filteredList = Events.Where(x=> startDate <= x.Start && x.End <= endDate).ToList();
            }
            else //Title seçilmiş ise filtreye ekle
            {
                filteredList = Events.Where(x => x.Title == title && startDate <= x.Start && x.End <= endDate).ToList();
            }
            return Json(filteredList);
        }
    }
}

