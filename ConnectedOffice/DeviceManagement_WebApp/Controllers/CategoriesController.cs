using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            CategoriesRepository CategoriesRepository = new CategoriesRepository();

            var results = CategoriesRepository.Getall();

            return View(results);
        }

    }
}
