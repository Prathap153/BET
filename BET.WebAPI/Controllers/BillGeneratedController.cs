
using BET.Domain.BO;
using Microsoft.AspNetCore.Authorization;

namespace BET.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BillGeneratedController : ControllerBase
    {
        private readonly IBillGeneratedService _billGeneratedService;
        private readonly ILogger<BillGeneratedController> _logger;
        public BillGeneratedController(IBillGeneratedService billGeneratedService, ILogger<BillGeneratedController> logger)
        {
            _billGeneratedService = billGeneratedService;
            _logger = logger;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = new Response<IEnumerable<BillGenerated>>();
            response.Data = await _billGeneratedService.GetAllBillGeneratedAsync();
            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(BillGenerated entity)
        {
            var response = new Response<Guid>();
            response.Data = await _billGeneratedService.AddBillGeneratedAsync(entity);
            return Ok(response);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = new Response<BillGenerated>();
            response.Data = await _billGeneratedService.GetByIdBillGeneratedAsync(id);
            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = new Response<string>();
            await _billGeneratedService.DeleteBillGeneratedAsync(id);
            response.Data = " Deleted Successfuly ";
            _logger.LogInformation("Delete Bill Generated {id}",id);
            return Ok(response);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(BillGenerated entity)
        {
            var response = new Response<string>();
            await _billGeneratedService.UpdateBillGeneratedAsync(entity);
            _logger.LogInformation("Updated Successfully {id} ",entity.Id);
            response.Data = "Updated Successfully";
            return Ok(response);
        }

        [HttpGet("getAllByNames")]
        public async Task<IActionResult> GetAllbyNames()
        {
            var response = new Response<IEnumerable<BillGeneratedBO>>();
            response.Data = await _billGeneratedService.GetAllByNames();
            return Ok(response);
        }
    }
}
