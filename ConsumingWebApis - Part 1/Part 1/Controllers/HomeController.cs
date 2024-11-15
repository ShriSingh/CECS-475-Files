using ConsumingWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConsumingWebApi.Controllers
{
    public class HomeController : Controller
    {
        // New Addition
        private readonly IHolidaysApiService _holidaysApiService;

        // New Addition
        public HomeController(IHolidaysApiService holidaysApiService)
        {
            _holidaysApiService = holidaysApiService;
        }

        // New Addition
        public async Task<IActionResult> Index(string countryCode, int year)
        {
            List<HolidayModel> holidays = new List<HolidayModel>();
            holidays = await _holidaysApiService.GetHolidays(countryCode, year);

            return View(holidays);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
