using Microsoft.AspNetCore.Mvc;
using App.Service;

namespace App.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly CachedService _cached;

        public PaymentsController(CachedService cached)
        {
            _cached = cached;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            return View(_cached.GetPayments());
        }
    }
}
