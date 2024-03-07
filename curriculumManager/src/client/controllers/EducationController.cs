using curriculumManager.src.application.interfaces;
using curriculumManager.src.application.services;
using curriculumManager.src.domain.dtos.education;
using curriculumManager.src.domain.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace curriculumManager.src.client.controllers
{
    [ApiController]
    [Route("v1/Education")]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;
        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }
        [HttpGet("{customerId}")]
        [Authorize(Roles = "admin,customer")]
        public async Task<ActionResult> getAllEducations(int customerId)
        {
            var listEducation = await _educationService.selectAll(customerId);
            return Ok(listEducation);
        }

        [HttpGet("getOne/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> getOneEducation(int id)
        {
            var education = await _educationService.getByIdAsync(id);
            return Ok(education);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> insertEducation([FromBody] EducationInsert education)
        {
            var educationInserted = await _educationService.insertAsync(education);
            return Ok(educationInserted);
        }

        // PUT api/<EducationController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> updateEducation([FromBody] EducationWithId education)
        {
            var educationInserted = await _educationService.UpdateAsync(education);
            return Ok(educationInserted);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> deleteEducation(int id)
        {
            int idDeleted = await _educationService.DeleteAsync(id);
            return Ok(idDeleted);
        }
    }
}
