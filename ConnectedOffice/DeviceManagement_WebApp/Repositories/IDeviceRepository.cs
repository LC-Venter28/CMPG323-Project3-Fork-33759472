﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;

public interface IDeviceRepository : IGenericRepository<Device>
{
    Device GetMostRecentDevice();
    Category GetCategory();
    Zone GetZone();
}

