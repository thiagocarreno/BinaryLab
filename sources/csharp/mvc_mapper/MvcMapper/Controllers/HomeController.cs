using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMapper.Models;
using MvcMapper.ViewModels;
using AutoMapper;

namespace MvcMapper.Controllers
{
    public class HomeController 
        : Controller
    {
        public ActionResult Index()
        {
            var client = new Client 
            {
                Name = "First Name",
                LastName = "Last Name",
                Birth = new DateTime(1985, 10, 27),
                Active = true
            };

            var clientView = Mapper.Map<Client, ClientViewModel>(client);
            var rnd = new Random();

            clientView.LuckyNumber = rnd.Next();

            return View(clientView);
        }
    }
}