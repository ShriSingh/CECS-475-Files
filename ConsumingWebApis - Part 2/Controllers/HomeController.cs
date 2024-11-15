// New Addition
using ConsumingWebApi2.Controllers;
using Microsoft.AspNetCore.Mvc;

// New Addition
[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    // New Addition
    private readonly IHolidaysApiService _holidaysApiService;

    // New Addition
    public HomeController(IHolidaysApiService holidaysApiService)
    {
        _holidaysApiService = holidaysApiService;
    }

    // New Addition
    [HttpGet]
    public async Task<IActionResult> GetHolidays(string countryCode, int year)
    {
        try
        {
            var holidays = await _holidaysApiService.GetHolidays(countryCode, year);
                
            return Ok(holidays);

        } catch (HttpRequestException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

