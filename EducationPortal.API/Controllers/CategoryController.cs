using EducationPortal.Business.Abstract;
using EducationPortal.Business.Concrete;
using EducationPortal.DataAccess.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWorks _UnitOfWork;
        private readonly IConfiguration _config;
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _category;

        public CategoryController(IUnitOfWorks UnitOfWork, IConfiguration Config, ICategoryService Category, ILogger<CategoryController> logger)
        {
            _UnitOfWork = UnitOfWork;
            _config = Config;
            _category = Category;
            _logger = logger;
        }

        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            try
            {
                var list = _category.GetAll();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetListById")]
        public IActionResult GetListById(int id)
        {
            try
            {
                var list = _category.GetById(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
