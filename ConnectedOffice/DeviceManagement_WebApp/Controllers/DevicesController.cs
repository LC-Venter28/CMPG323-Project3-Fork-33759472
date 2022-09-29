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
    public class DevicesController : Controller
    {
        private readonly IDeviceRepository _deviceRepository;

        public DevicesController(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public IActionResult Index()
        {
            return View(_deviceRepository.GetAll());
        }

        // GET: Devices/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _deviceRepository.GetById(id);
    
        if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Devices/Create
        public IActionResult Create()
    {
        //var device;
        //ViewData["CategoryId"] = _deviceRepository.ShowCat(device);
        //ViewData["ZoneId"] = _deviceRepository.ShowZone(device);
        return View();
    }

    // POST: Devices/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
    {
        device.DeviceId = Guid.NewGuid();
        _deviceRepository.Add(device);
        
        return RedirectToAction(nameof(Index));


    }

    // GET: Devices/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var device = _deviceRepository.GetById(id);
        if (device == null)
        {
            return NotFound();
        }
        ViewData["CategoryId"] = _deviceRepository.ShowCat(device);
        ViewData["ZoneId"] = _deviceRepository.ShowZone(device);
        return View(device);
    }

    // POST: Devices/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
    {
        if (id != device.DeviceId)
        {
            return NotFound();
        }
        try
        {
                _deviceRepository.Add(device);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DeviceExists(device.DeviceId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return RedirectToAction(nameof(Index));

    }

    /*// GET: Devices/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var device = await _context.Device
            .Include(d => d.Category)
            .Include(d => d.Zone)
            .FirstOrDefaultAsync(m => m.DeviceId == id);
        if (device == null)
        {
            return NotFound();
        }

        return View(device);
    }

    // POST: Devices/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var device = await _context.Device.FindAsync(id);
        _context.Device.Remove(device);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }*/

    private bool DeviceExists(Guid id)
    {
        return _deviceRepository.DevExists(id);
    }
    }
}
