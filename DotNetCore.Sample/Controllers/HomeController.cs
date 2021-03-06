﻿using DotNetCore.Sample.DataAccess;
using DotNetCore.Sample.DataAccess.Entities;
using DotNetCore.Sample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;

namespace DotNetCore.Sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //private readonly SampleContext _db;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            //var records = _db.Books.ToList();

            //_db.Books.Add(new Book
            //{
            //    Id = Guid.NewGuid(),
            //    Name = $"Testing-{DateTime.UtcNow.Ticks}",
            //    Description = "Hello World!",
            //    IsShelf = true,
            //    ModifyBy = Guid.NewGuid()
            //});
            //_db.SaveChanges();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
