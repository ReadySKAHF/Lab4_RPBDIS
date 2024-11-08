using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App;
using App.Service;


namespace App.Controllers
{
    public class CarServicesController : Controller
    {
        private readonly CachedService _cached;

        public CarServicesController(CachedService cached)
        {
            _cached = cached;
        }

        // GET: CarServices
        public async Task<IActionResult> Index()
        {
            return View(_cached.GetCarServices());
        }
    }
}
