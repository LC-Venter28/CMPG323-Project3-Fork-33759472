using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;

public class ZonesRepository : GenericRepository<Zone>, IZonesRepository
{
    private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

    public ZonesRepository(ConnectedOfficeContext context) : base(context)
    {

    }

    public Device GetMostRecentDevice()
    {
        return _context.Device.OrderByDescending(device => device.DateCreated).FirstOrDefault();
    }

    public Zone GetMostRecentZone()
    {
        throw new NotImplementedException();
    }

    
}

