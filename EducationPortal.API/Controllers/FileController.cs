using EducationPortal.Business.Abstract;
using EducationPortal.DataAccess.Abstract;
using EducationPortal.DataAccess.Concrete;
using EducationPortal.Entity.Dto;
using EducationPortal.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducationPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IUnitOfWorks _UnitOfWork;
        private readonly IConfiguration _config;
        private readonly ILogger<FileController> _logger;
        private readonly IFilesService _File;

        public FileController(IUnitOfWorks UnitOfWork, IConfiguration Config, IFilesService File, ILogger<FileController> logger)
        {
            _UnitOfWork = UnitOfWork;
            _config = Config;
            _File = File;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var list = _File.GetAll();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            try
            {
                var list = _File.GetById(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("FileSave")]
        public async Task<IActionResult> Insert([FromForm] FileDTO Item)
        {
            try
            {
                byte[] fileBytes;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await Item.Files.CopyToAsync(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }
                TblEducationFile Provider = new TblEducationFile
                {
                    EducationId = Item.EducationID,
                    Name = Item.Files.FileName,
                    Files = fileBytes
                };
                await _File.InsertAsync(Provider);
                _logger.LogInformation("Dosya başarıyla yüklendi.");
                return Ok(("Dosya başarıyla yüklendi."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Dosya yükleme sırasında bir hata oluştu.");
                return BadRequest(ex.Message + " Dosya yükleme sırasında bir hata oluştu.");
            }
        }

    }
}
