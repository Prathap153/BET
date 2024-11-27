
using Microsoft.AspNetCore.Authorization;

namespace BET.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
 
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = new Response<IEnumerable<Category>>();
            response.Data = await _categoryService.GetAllCategoryAsync();
            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(Category category)
        {
            var response = new Response<Guid>();
            response.Data = await _categoryService.AddCategoryAsync(category);
            return Ok(response);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = new Response<Category>();
            response.Data = await _categoryService.GetByIdCategoryAsync(id);
            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = new Response<string>();
            await _categoryService.DeleteCategoryAsync(id);
            response.Data = "Delete Successfully";
            return Ok(response);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id,Category category)
        {
            var response = new Response<string>();
            await _categoryService.UpdateCategoryAsync(id,category);
            response.Data = "Updated Successfully";
            return Ok(response);
        }

    }
}
