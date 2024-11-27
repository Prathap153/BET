
using Microsoft.AspNetCore.Authorization;

namespace BET.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class BusinessUnitController : ControllerBase
    {
        private readonly IBusinessUnitService _businessUnitService;
        public BusinessUnitController(IBusinessUnitService businessUnitService)
        {
            _businessUnitService = businessUnitService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = new Response<IEnumerable<BusinessUnit>>();
            response.Data = await _businessUnitService.GetAllBusinessUnitAsync();
            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(BusinessUnit bu)
        {
            var response = new Response<Guid>();
            response.Data = await _businessUnitService.AddBusinessUnitAsync(bu);
            return Ok(response);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var response = new Response<BusinessUnit>();
            response.Data = await _businessUnitService.GetByIdBusinessUnitAsync(id);
            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = new Response<string>();
            await _businessUnitService.DeleteBusinessUnitAsync(id);
            response.Data = "Delete Successfully";
            return Ok(response);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id,BusinessUnit bu)
        {
            var response = new Response<string>();
            await _businessUnitService.UpdateBusinessUnitAsync(id,bu);
            response.Data = "Updated Successfully";
            return Ok(response);
        }
    }
}
