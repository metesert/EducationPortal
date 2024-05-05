using EducationPortal.Business.Abstract;
using EducationPortal.DataAccess.Abstract;
using EducationPortal.Entity.Dto;
using EducationPortal.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly IUnitOfWorks _UnitOfWork;
        private readonly IConfiguration _config;
        private readonly ILogger<FileController> _logger;
        private readonly IProcessService _Process;

        public ProcessController(IUnitOfWorks UnitOfWork, IConfiguration Config, IProcessService Process, ILogger<FileController> logger)
        {
            _UnitOfWork = UnitOfWork;
            _config = Config;
            _Process = Process;
            _logger = logger;
        }


        //[HttpGet("GetEducationQuery")]
        //public async Task<IActionResult> GetQuery()
        //{
        //    try
        //    {
        //        var list = await _Education.EducationQuery();
        //        return Ok(list);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPost("Save")]
        public async Task<IActionResult> Insert([FromForm] ProcessDTO Item)
        {
            try
            {
                TblProcess provider = new TblProcess
                {
                    CreateDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    EducationId = Item.EducationID,
                    UserId = Item.UserId,
                    IsDeleted = false
                };
                await _Process.InsertAsync(provider);
                _logger.LogInformation("Kayıt Başarılı.");
                return Ok(("Kayıt Başarılı."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hata!");
                return BadRequest(ex.Message + "Kayıt sırasında hata oluştu.");
            }
        }


        [HttpPut("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _Process.Delete(id);
                _logger.LogInformation("Kayıt Silindi");
                return Ok(("Kayıt Silindi."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hata!");
                return BadRequest(ex.Message + "Silme sırasında hata oluştu.");
            }
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                TblProcess provider = new TblProcess
                {
                    IsOk = true
                };
                await _Process.Update(id, provider);
                _logger.LogInformation("Kayıt Güncellendi");
                return Ok(("Kayıt Güncellendi."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hata!");
                return BadRequest(ex.Message + "Güncelleme sırasında hata oluştu.");
            }
        }




    }
}
