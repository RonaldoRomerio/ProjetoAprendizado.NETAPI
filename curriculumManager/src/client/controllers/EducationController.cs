using curriculumManager.src.application.interfaces;
using curriculumManager.src.application.services;
using curriculumManager.src.domain.dtos.education;
using curriculumManager.src.domain.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace curriculumManager.src.client.controllers
{
    public class EducationController : BasicController<IEducationService>
    {
        public EducationController(IEducationService service) : base(service){}
        [HttpGet("{customerId}")]
        [Authorize(Roles = "admin,customer")]
        public async Task<ActionResult> getAllEducations(int customerId)
        {
            var listEducation = await _service.selectAll(customerId);
            return Ok(listEducation);
        }

        [HttpGet("getOne/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> getOneEducation(int id)
        {
            var education = await _service.getByIdAsync(id);
            return Ok(education);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> insertEducation([FromBody] EducationInsert education)
        {
            var educationInserted = await _service.insertAsync(education);
            return Ok(educationInserted);
        }

        // PUT api/<EducationController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> updateEducation([FromBody] EducationWithId education)
        {
            var educationInserted = await _service.UpdateAsync(education);
            return Ok(educationInserted);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> deleteEducation(int id)
        {
            int idDeleted = await _service.DeleteAsync(id);
            return Ok(idDeleted);
        }
    }
}
