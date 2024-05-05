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


        [HttpPost]
        public async Task<IActionResult> joinEducation([FromForm] Process Item)
        {
            try
            {
                TblProcess provider = new TblProcess
                {
                    ModifiedDate = DateTime.Now,
                    CreateDate = DateTime.Now,
                    EducationId = Item.EducationId,
                    IsDeleted = false,
                    IsOk = false,
                    UserId = Item.UserId
                };

                var requestData = new Dictionary<string, string>
        {
            { "UserId", provider.UserId.ToString() },
            { "EducationID", provider.EducationId.ToString() }
        };


                var responseEducation = await _httpClient.PostAsync("api/Process/Save", new FormUrlEncodedContent(requestData));


                if (responseEducation.IsSuccessStatusCode)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            catch (HttpRequestException ex)
            {

                _logger.LogError(ex.Message + ex.Source + ex.StackTrace, "Kayıt hatası!");
                return BadRequest(ex.Message);
            }
        }

    }
}
