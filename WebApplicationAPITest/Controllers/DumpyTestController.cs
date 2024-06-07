using Microsoft.AspNetCore.Mvc;

namespace WebApplicationAPITest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DumpyTestController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private const string DummyApiUrl = "https://dummyapi.io/data/v1/user?page=1&limit=10";

        public DumpyTestController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var appId = _configuration["DummyApi:AppId"];
            _httpClient.DefaultRequestHeaders.Add("app-id", appId);
            var response = await _httpClient.GetAsync(DummyApiUrl);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return Content(data, "application/json");
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
