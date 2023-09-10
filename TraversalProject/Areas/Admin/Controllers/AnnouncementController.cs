using AutoMapper;
using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using TraversalProject.Areas.Admin.Models;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
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

        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDto>>(_announcementService.TGetList());
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDto dto)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TAdd(new Announcement()
                {
                    Title = dto.Title,
                    Content = dto.Content,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });

                return RedirectToAction("Index", "Announcement", new { area = "Admin" });
            }
            return View(dto);
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            var announcementID = _announcementService.TGetByID(id);
            _announcementService.TDelete(announcementID);
            return RedirectToAction("Index", "Announcement", new { area = "Admin" });
        }
        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var announcementID = _mapper.Map<AnnouncementUpdateDto>(_announcementService.TGetByID(id));
            return View(announcementID);
        }
        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TUpdate(new Announcement
                {
                    AnnouncementID = model.AnnouncementID,
                    Title = model.Title,
                    Content = model.Content,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index", "Announcement", new { area = "Admin" });
            }
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var valueID = _announcementService.TGetByID(id);
            return View(valueID);
        }
    }
}
