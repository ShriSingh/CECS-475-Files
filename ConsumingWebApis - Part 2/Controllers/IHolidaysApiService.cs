using ConsumingWebApi2.Models;

namespace ConsumingWebApi2.Controllers
{
    public interface IHolidaysApiService
    {
        Task<List<HolidayModel>> GetHolidays(string countryCode, int year);
    }
}
