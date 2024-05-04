using Azure;
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
    public class EducationController : ControllerBase
    {

        private readonly IUnitOfWorks _UnitOfWork;
        private readonly IConfiguration _config;
        private readonly ILogger<EducationController> _logger;
        private readonly IEducationService _Education;

        public EducationController(IUnitOfWorks UnitOfWork, IConfiguration Config, IEducationService Education, ILogger<EducationController> logger)
        {
            _UnitOfWork = UnitOfWork;
            _config = Config;
            _Education = Education;
            _logger = logger;
        }

        [HttpGet("GetEducation")]
        public IActionResult GetAll()
        {
            try
            {
                var list = _Education.GetAll();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetEducationQuery")]
        public async  Task<IActionResult> GetQuery()
        {
            try
            {
                var list = await _Education.EducationQuery();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("InsertEducation")]
        public async Task<IActionResult> Insert([FromForm] EducationDTO Item)
        {
            try
            {
                TblEducation tblEducation = new TblEducation
                {
                    Name = Item.Name,
                    CategoryId = Item.CategoryID,
                    Cost = Item.Cost,
                    EductorId = Item.EductorID,
                    Time = Item.Time,
                    Quota = Item.Quota,
                    CreateDate = DateTime.Now,
                    ModifiedDate = DateTime.Now                    

                };
                await _Education.InsertAsync(tblEducation);
                return Ok(new { id = tblEducation.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
