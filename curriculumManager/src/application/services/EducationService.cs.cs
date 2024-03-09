using AutoMapper;
using curriculumManager.src.application.interfaces;
using curriculumManager.src.domain.dtos.education;
using curriculumManager.src.domain.dtos.experience;
using curriculumManager.src.domain.models;
using curriculumManager.src.infrastructure.repositories.interfaces;

namespace curriculumManager.src.application.services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;

        public EducationService(IEducationRepository educationRepository, IMapper mapper)
        {
            _educationRepository = educationRepository;
            _mapper = mapper;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _educationRepository.DeleteAsync(id);
        }

        public async Task<EducationWithId> getByIdAsync(int id)
        {
            var educationDAO = await _educationRepository.getByIdAsync(id);
            var educationWithId = _mapper.Map<EducationWithId>(educationDAO);

            return educationWithId;
        }

        public async Task<EducationWithId> insertAsync(EducationInsert education)
        {
            var educationComplete = _mapper.Map<Education>(education);
            educationComplete.Created_at = DateTime.UtcNow;
            var educationDAO = await _educationRepository.insertAsync(educationComplete);
            var educationWithId = _mapper.Map<EducationWithId>(educationDAO);

            return educationWithId;
        }

        public async Task<List<EducationWithId>> selectAll(int customerId)
        {
            var educationDAO = await _educationRepository.selectAll(customerId);
            var educationWithId = _mapper.Map<List<EducationWithId>>(educationDAO);

            return educationWithId;
        }

        public async Task<EducationWithId> UpdateAsync(EducationWithId education)
        {
            var educationComplete = _mapper.Map<Education>(education);
            var educationDAO = await _educationRepository.UpdateAsync(educationComplete);
            var educationWithId = _mapper.Map<EducationWithId>(educationDAO);

            return educationWithId;
        }
    }
}
