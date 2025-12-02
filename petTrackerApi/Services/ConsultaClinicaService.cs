using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Repository.IRepository;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Services
{
    public class ConsultaClinicaService : IGenericService<ConsultaClinicaDTO>
    {
        private readonly IGenericRepository<ConsultaClinica> _repository;
        public ConsultaClinicaService(IGenericRepository<ConsultaClinica> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ConsultaClinicaDTO>> Get()
        {
            var consultasClinicas = await _repository.Get();
            return consultasClinicas.Select(Mapper.ConsultaClinicaMapToDTO);
        }

        public Task<ConsultaClinicaDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<ConsultaClinicaDTO> Create(ConsultaClinicaDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<ConsultaClinicaDTO> Update(int id, ConsultaClinicaDTO dto)
        {
            throw new NotImplementedException();
        }
        public Task<ConsultaClinicaDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
