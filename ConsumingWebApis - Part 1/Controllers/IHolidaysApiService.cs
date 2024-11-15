using ConsumingWebApi.Models;

namespace ConsumingWebApi.Controllers
{
    // New Addition
    public interface IHolidaysApiService
    {
        Task<List<HolidayModel>> GetHolidays(string countryCode, int year);
    }
}
