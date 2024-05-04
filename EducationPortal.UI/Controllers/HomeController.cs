using Azure;
using EducationPortal.Entity.Dto;
using EducationPortal.UI.Enums;
using EducationPortal.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EducationPortal.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7195/");
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Category/GetList");
                response.EnsureSuccessStatusCode();

                var kategoriler = await response.Content.ReadFromJsonAsync<Category[]>();

                return View(kategoriler);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveForm([FromForm] Education Item)
        {
            try
            {

                EducationDTO EducationProvider = new EducationDTO
                {
                    CategoryID = Item.CategoryID,
                    Cost = Item.Cost,
                    EductorID = Item.EductorID,
                    Name = Item.Name,
                    Quota = Item.Quota,
                    Time = Item.Time
                };
                var responseEducation = await _httpClient.PostAsync("api/Education/InsertEducation", new FormUrlEncodedContent(new Dictionary<string, string>
                        {
                            { "Name", EducationProvider.Name },
                            { "CategoryID", EducationProvider.CategoryID.ToString() },
                            { "Cost", EducationProvider.Cost.ToString() },
                            { "EductorID", EducationProvider.EductorID.ToString() },
                            { "Time", EducationProvider.Time },
                            { "Quota", EducationProvider.Quota.ToString() }
                        }));
                if (responseEducation.IsSuccessStatusCode)
                {
                    var content = await responseEducation.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<dynamic>(content);
                    int newEducationId = result.id;
                    var contentx = new MultipartFormDataContent();
                    contentx.Add(new StringContent(newEducationId.ToString()), "EducationID");
                    contentx.Add(new StreamContent(Item.Files.OpenReadStream()), "Files", Item.Files.FileName);
                    var responseFile = await _httpClient.PostAsync("api/File/FileSave", contentx);
                }
                else
                {
                    _logger.LogError(responseEducation.IsSuccessStatusCode.ToString(), "Kayıt Hatalı!");
                    return BadRequest();
                }
                _logger.LogInformation(responseEducation.IsSuccessStatusCode.ToString(), "Kayıt Başarılı");

                return Json(new { success = true });
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex.Message + ex.Source + ex.StackTrace, "Kayıt hatası!");
                return BadRequest(ex.Message);
            }


        }


    }
}