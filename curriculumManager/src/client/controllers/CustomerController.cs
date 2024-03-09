using curriculumManager.src.application.interfaces;
using curriculumManager.src.domain.dtos.customer;
using curriculumManager.src.domain.dtos.genericDTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace curriculumManager.src.client.controllers
{
    public class CustomerController : BasicController<ICustomerService>
    {
        public CustomerController(ICustomerService service) : base (service){}

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> getAllCustomers(int page)
        {
            var listCustomer = await _service.selectAll(page);
            var hasNextPage = await _service.hasNextPage(page);

            return  Ok(new ListReturn<CustomerWithId> { list = listCustomer, hasNextPage= hasNextPage });
        }

        [HttpGet("getOne/{id}")]
        [Authorize(Roles = "admin,customer")]
        public async Task<ActionResult> getByIdCustomer(int id)
        {
            var Customer = await _service.getByIdAsync(id);
            return Ok(Customer);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> insertCustomer([FromBody] CustomerInsert customer)
        {
            var insertedCustomer = await _service.insertAsync(customer);

            return Ok(insertedCustomer);
        }
        [HttpPut("Photo")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> PutImage([FromForm] CustomerPhoto customer)
        {
            var verifyIfExists = await _service.verifyIfExists(customer.Id);
            if (!verifyIfExists)
                return NotFound("Customer not found");

            var imageInserted = _service.savePhoto(customer);
            var updateFilePathImage = await _service.insertPhotoOnCustomer(customer.Id, imageInserted);
            return Ok(updateFilePathImage);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> updateCustomer([FromBody] CustomerWithId customer)
        {
            var updatedCustomer = await _service.UpdateAsync(customer);
            return Ok(updatedCustomer);
        }

        // DELETE api/<ExperienceController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> deleteCustomer(int id)
        {
            int idDeleted = await _service.DeleteAsync(id);
            return Ok(idDeleted);
        }
    }
}
