using DataLayer.Data;
using DataLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLayer.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IDataContext _context;
        private readonly ILogger<CategoriesController> _logger;
        public CategoriesController(IDataContext context, ILogger<CategoriesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int PageSize, [FromQuery] int CurrentPage)
        {
            var query = _context.Categories.GetAll();
            List<CategoryDTO> items = query.Page(CurrentPage, PageSize)
                .Include(x => x.ProductCategories)
                .ThenInclude(x => x.Product)
                .Include(x => x.Image)
                .ToDTOs()
                .ToList();
            return Ok(items);
        }
    }
}
