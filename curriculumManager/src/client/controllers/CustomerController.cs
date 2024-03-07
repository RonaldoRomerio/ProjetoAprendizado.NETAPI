using curriculumManager.src.application.interfaces;
using curriculumManager.src.domain.dtos.customer;
using curriculumManager.src.domain.dtos.genericDTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace curriculumManager.src.client.controllers
{
    [ApiController]
    [Route("v1/Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("page/{customerId}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> getAllCustomers(int page)
        {
            var listCustomer = await _customerService.selectAll(page);
            var hasNextPage = await _customerService.hasNextPage(page);

            return  Ok(new ListReturn<CustomerWithPhoto> { list = listCustomer, hasNextPage= hasNextPage });
        }

        [HttpGet("getOne/{id}")]
        [Authorize(Roles = "admin,customer")]
        public async Task<ActionResult> getByIdCustomer(int id)
        {
            var Customer = await _customerService.getByIdAsync(id);
            return Ok(Customer);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> insertCustomer([FromBody] CustomerInsert customer)
        {
            var insertedCustomer = await _customerService.insertAsync(customer);
            return Ok(insertedCustomer);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> updateCustomer([FromBody] CustomerWithId customer)
        {
            var updatedCustomer = await _customerService.UpdateAsync(customer);
            return Ok(updatedCustomer);
        }

        // DELETE api/<ExperienceController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> deleteCustomer(int id)
        {
            int idDeleted = await _customerService.DeleteAsync(id);
            return Ok(idDeleted);
        }
    }
}
