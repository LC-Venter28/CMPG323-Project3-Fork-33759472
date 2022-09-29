using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;

public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
{
    private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

    public DeviceRepository(ConnectedOfficeContext context) : base(context)
    {

    }

    public Category GetCategory()
    {
        throw new NotImplementedException();
    }

    public Device GetMostRecentDevice()
    {
        return _context.Device.OrderByDescending(device => device.DateCreated).FirstOrDefault();
    }

    public Zone GetZone()
    {
        throw new NotImplementedException();
    }
}

