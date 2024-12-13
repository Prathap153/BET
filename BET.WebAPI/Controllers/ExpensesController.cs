
using BET.Domain.BO;
using Microsoft.AspNetCore.Authorization;

namespace BET.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpensesService _expensesService;
        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = new Response<IEnumerable<Expenses>>();
            response.Data = await _expensesService.GetAllExpensesAsync();
            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(Expenses entity)
        {
            var response = new Response<Guid>();
            response.Data = await _expensesService.AddExpensesAsync(entity);
            return Ok(response);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = new Response<Expenses>();
            response.Data = await _expensesService.GetByIdExpensesAsync(id);
            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = new Response<string>();
            await _expensesService.DeleteExpensesAsync(id);
            response.Data = "Deleted Successfully";
            return Ok(response);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id,Expenses entity)
        {
            var response = new Response<string>();
            await _expensesService.UpdateExpensesAsync(id,entity);
            response.Data = "Updated Successfully";
            return Ok(response);    
        }

        [HttpGet("getAllByName")]
        public async Task<IActionResult> GetAllByNames()
        {
            var response = new Response<IEnumerable<ExpensesBO>>();
            response.Data = await _expensesService.GetAllByNames();
            return Ok(response);
        }
    }
}
