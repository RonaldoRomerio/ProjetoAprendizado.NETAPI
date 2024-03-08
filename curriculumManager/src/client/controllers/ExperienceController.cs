using curriculumManager.src.application.interfaces;
using curriculumManager.src.domain.dtos.experience;
using curriculumManager.src.domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace curriculumManager.src.client.controllers
{
    public class ExperienceController : BasicController<IExperienceService>
    {
        public ExperienceController(IExperienceService service) : base(service){}

        [HttpGet("{customerId}")]
        [Authorize(Roles = "admin,customer")]
        public async Task<ActionResult> getAllExperiences(int customerId)
        {
            var listExperience = await _service.selectAll(customerId);
            return Ok(listExperience);
        }

        [HttpGet("getOne/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> getByIdExperience(int id)
        {
            var experience = await _service.getByIdAsync(id);
            return Ok(experience);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> insertExperience([FromBody] ExperienceInsert experience)
        {
            var insertedExperience = await _service.insertAsync(experience);
            return Ok(insertedExperience);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> updateExperience([FromBody] ExperienceWithId experience)
        {
            var updatedExperience = await _service.UpdateAsync(experience);
            return Ok(updatedExperience);
        }

        // DELETE api/<ExperienceController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> deleteExperience(int id)
        {
            int idDeleted = await _service.DeleteAsync(id);
            return Ok(idDeleted);
        }
    }
}
