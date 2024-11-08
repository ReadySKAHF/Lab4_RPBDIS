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
    public class CarsController : Controller
    {
        private readonly CachedService _cached;

        public CarsController(CachedService cached)
        {
            _cached = cached;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            
            //return View(_cached.GetPenis());
            return View(_cached.GetCars());
        }

       
    }
}
