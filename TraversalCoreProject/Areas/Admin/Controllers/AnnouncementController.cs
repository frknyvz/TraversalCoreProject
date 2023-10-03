using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Announcement")]
    [Authorize(Roles = "Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            //List<Announcement> announcements = _announcementService.TGetList();
            //List<AnnouncementListViewModel> model = new List<AnnouncementListViewModel>();
            //foreach (var x in announcements)
            //{
            //    AnnouncementListViewModel announcementListViewModel = new AnnouncementListViewModel();
            //    announcementListViewModel.ID = x.AnnouncementID;
            //    announcementListViewModel.Title = x.Title;
            //    announcementListViewModel.Content = x.Content;
            //    announcementListViewModel.Date = x.Date;

            //    model.Add(announcementListViewModel);

            //}
            var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.TGetList());

            return View(values);
        }

        [Route("AddAnnouncement")]
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [Route("AddAnnouncement")]
        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDTO model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TAdd(new Announcement()
                {
                    Content = model.Content,
                    Title = model.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                });

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Route("DeleteAnnouncement/{id}")]
        public IActionResult DeleteAnnouncement(int id)
        {
            var values = _announcementService.TGetByID(id);
            _announcementService.TDelete(values);
            return RedirectToAction("Index");
        }

        [Route("UpdateAnnouncement/{id}")]
        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var values = _mapper.Map<AnnouncementUpdateDTO>(_announcementService.TGetByID(id));
            return View(values);
        }

        [Route("UpdateAnnouncement/{id}")]
        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDTO model)
        {
            if( ModelState.IsValid)
            {
                _announcementService.TUpdate(new Announcement
                {
                    AnnouncementID= model.AnnouncementID,
                    Content = model.Content,
                    Title = model.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                });
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
