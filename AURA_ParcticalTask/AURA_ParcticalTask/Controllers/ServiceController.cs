using AURA_ParcticalTask.models;
using AURA_ParcticalTask.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AURA_ParcticalTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceController(IServiceRepository serviceRepository) 
        {
            _serviceRepository = serviceRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]ServiceModel service)
        {
            var operation = await _serviceRepository.AddOperation(service);
            return Ok(operation);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
           
            var operation= await _serviceRepository.SoftDeleteOperation(id);
            if (operation)
                return Ok();
            else
                return NotFound();
        }
        public async Task<List<ServiceModel>> GetAll()
        {
            var operations = await _serviceRepository.GetAll();
            return operations;
        }

    }
}
