using EmployeeApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeController(EmployeeRepository employeeRepo)
        {
            _employeeRepository = employeeRepo;
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] Employee model)
        {
            await _employeeRepository.AddEmployee(model);
            return Ok();
        }
        [HttpGet]

        public async Task<ActionResult> GetAllEmployeeAsync()
        {
            return Ok(await _employeeRepository.GetAllEmployee());

        }

        [HttpGet("{id}")]

        public async Task<ActionResult> GetEmployee([FromRoute] int id )
        {

            return Ok(await _employeeRepository.GetEmployee(id));

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteEmployee([FromRoute] int id)
        {
            await _employeeRepository.DeleteEmployee(id);
            return Ok();

        }

        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateEmployee([FromRoute] int id , [FromBody] Employee emp)
        {
            await _employeeRepository.UpdateEmployee(id , emp);
            return Ok();

        }




    }
}
