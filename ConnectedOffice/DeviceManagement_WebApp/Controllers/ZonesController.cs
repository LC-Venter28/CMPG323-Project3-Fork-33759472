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
    public class ZonesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            ZonesRepository ZonesRepository = new ZonesRepository();

            var results = ZonesRepository.Getall();

            return View(results);
        }

    }
}
