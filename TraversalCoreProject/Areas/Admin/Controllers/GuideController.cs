using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Guide")]
    [Authorize(Roles = "Admin")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }

        [Route("AddGuide")]
        [HttpGet]
        public IActionResult AddGuide()
        {
            var viewModel = new AddGuideLangViewModel
            {
                Languages = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Text = "Almanca",
                        Value = "Almanca"
                    },
                    new SelectListItem
                    {
                        Text = "Çince",
                        Value = "Çince"
                    },
                    new SelectListItem
                    {
                        Text = "Fransızca",
                        Value = "Fransızca"
                    },
                    new SelectListItem
                    {
                        Text = "İngilizce",
                        Value = "İngilizce"
                    },
                    new SelectListItem
                    {
                        Text = "İspanyolca",
                        Value = "İspanyolca"
                    },
                    new SelectListItem
                    {
                        Text = "Japonca",
                        Value = "Japonca"
                    },
                    new SelectListItem
                    {
                        Text = "Korece",
                        Value = "Korece"
                    },
                    new SelectListItem
                    {
                        Text = "Türkçe",
                        Value = "Türkçe"
                    },
                    new SelectListItem
                    {
                        Text = "Yunanca",
                        Value = "Yunanca"
                    },
                }
            };
            return View(viewModel);
        }

        [Route("AddGuide")]
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            GuideValidator validationRules = new GuideValidator();
            ValidationResult validationResult = validationRules.Validate(guide);
            if (validationResult.IsValid)
            {
                _guideService.TAdd(guide);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var x in validationResult.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
                return View();
            }
        }

        [Route("EditGuide/{id}")]
        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var values = _guideService.TGetByID(id);
            return View(values);
        }

        [Route("EditGuide/{id}")]
        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideService.TUpdate(guide);
            return RedirectToAction("Index");
        }

        [Route("ChangeToTrue/{id}")]
        public IActionResult ChangeToTrue(int id)
        {
            _guideService.TChangeToTrueByGuide(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }

        [Route("ChangeToFalse/{id}")]
        public IActionResult ChangeToFalse(int id)
        {
            _guideService.TChangeToFalseByGuide(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
    }
}
