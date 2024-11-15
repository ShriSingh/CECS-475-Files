// New Addition
using ConsumingWebApi2.Models;
using System.Text.Json;

namespace ConsumingWebApi2.Controllers
{
    // New Addition
    public class HolidaysApiService : IHolidaysApiService
    {
        // New Addition
        private static readonly HttpClient client;

        // New Addition
        static HolidaysApiService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://date.nager.at")
            };
        }

        // New Addition
        public async Task<List<HolidayModel>> GetHolidays(string countryCode, int year)
        {
            var url = string.Format("/api/v2/PublicHolidays/{0}/{1}", year, countryCode);
            var result = new List<HolidayModel>();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<List<HolidayModel>>(stringResponse,
                    new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
            }
            else
            {
                if (countryCode == null && year == 0) { }
                else
                {
                    throw new HttpRequestException($"Request to {url} failed with status code {(int)response.StatusCode}:{response.ReasonPhrase}");
                }
            }

            return result;
        }
    }
}
