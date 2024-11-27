
using BET.Domain.BO;
using Microsoft.AspNetCore.Authorization;

namespace BET.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeService _incomeService;
        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = new Response<IEnumerable<Income>>();
            response.Data = await _incomeService.GetAllIncomeAsync();
            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(Income entity)
        {
            var response = new Response<Guid>();
            response.Data = await _incomeService.AddIncomeAsync(entity);
            return Ok(response);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = new Response<Income>();
            response.Data = await _incomeService.GetByIdIncomeAsync(id);
            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = new Response<string>();
            await _incomeService.DeleteIncomeAsync(id);
            response.Data = "Deleted Successfully";
            return Ok(response);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(Income entity)
        {
            var response = new Response<string>();
            await _incomeService.UpdateIncomeAsync(entity);
            response.Data = "Updated Successfully";
            return Ok(response);
        }

        [HttpGet("getAllByNames")]
        public async Task<IActionResult> GetAllByNames()
        {
            var response = new Response<IEnumerable<IncomeBO>>();
            response.Data = await _incomeService.GetAllByNames();
            return Ok(response);
        }
    }
}
