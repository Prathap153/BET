using BET.Domain.BO;
using Microsoft.AspNetCore.Authorization;

namespace BET.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsService _paymentService;
        public PaymentsController(IPaymentsService paymentsService)
        {
            _paymentService = paymentsService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = new Response<IEnumerable<Payments>>();
            response.Data = await _paymentService.GetAllPaymentsAsync();
            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(Payments entity)
        {
            var response = new Response<Guid>();
            response.Data = await _paymentService.AddPaymentsAsync(entity);
            return Ok(response);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = new Response<Payments>();
            response.Data = await _paymentService.GetByIdPaymentsAsync(id);
            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = new Response<string>();
            await _paymentService.DeletePaymentsAsync(id);
            response.Data = "Deleted Successfully";
            return Ok(response);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(Payments entity)
        {
            var response = new Response<string>();
            await _paymentService.UpdatePaymentsAsync(entity);
            response.Data = "Updated Successfully";
            return Ok(response);
        }

        [HttpGet("getAllDetails")]
        public async Task<IActionResult> GetAllDetails()
        {
            var response = new Response<IEnumerable<PaymentsBO>>();
            response.Data = await _paymentService.GetAllDetails();
            return Ok(response);
        }
    }
}
