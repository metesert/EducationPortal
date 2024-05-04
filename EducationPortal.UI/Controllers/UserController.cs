using EducationPortal.Entity.Dto;
using EducationPortal.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly HttpClient _httpClient;
        public UserController(ILogger<UserController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7195/");
        }
        public async Task<IActionResult> User()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Education/GetEducationQuery");
                response.EnsureSuccessStatusCode();

                var query = await response.Content.ReadFromJsonAsync<EducationQueryDTO[]>();

                return View(query);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            
        }
    }
}
