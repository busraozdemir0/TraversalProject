using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.ContactDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TraversalProject.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly IMapper _mapper;

        public ContactController(IContactUsService contactUsService, IMapper mapper)
        {
            _contactUsService = contactUsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SendMessageDto model)
        {
            if(ModelState.IsValid)
            {
                _contactUsService.TAdd(new EntityLayer.Concrete.ContactUs()
                {
                    Mail = model.Mail,
                    Name = model.Name,
                    Subject = model.Subject,
                    MessageBody = model.MessageBody,
                    MessageStatus = true,
                    MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index", "Default");
            }
            return View(model);
        }
    }
}
