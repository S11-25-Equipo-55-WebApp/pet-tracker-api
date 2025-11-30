using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Model;
using petTrackerApi.Repository;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Services
{
    public class TipoDesparacitacionService : IGenericService<TipoDesparacitacionDTO>
    {
        private readonly IGenericRepository<TipoDesparacitacion> _repository;
        private readonly TipoDesparacitacionRepository _repoTipoDesparacitacion;

        public TipoDesparacitacionService(IGenericRepository<TipoDesparacitacion> repository, TipoDesparacitacionRepository repoTipoDesparacitacion)
        {
            _repository = repository;
            _repoTipoDesparacitacion = repoTipoDesparacitacion;
        }
        public async Task<IEnumerable<TipoDesparacitacionDTO>> Get()
        {
            var tiposDesparacitaciones = await _repository.Get();
            return tiposDesparacitaciones.Select(Mapper.TipoDesparacitacionMapToDTO);
        }
        public async Task<TipoDesparacitacionDTO> GetById(int id)
        {
            var encuentra = await _repository.GetById(id);
            if (encuentra == null) return null;
            var respuesta = Mapper.TipoDesparacitacionMapToDTO(encuentra);
            return respuesta;
        }

        public Task<TipoDesparacitacionDTO> Create(TipoDesparacitacionDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<TipoDesparacitacionDTO> Update(int id, TipoDesparacitacionDTO dto)
        {
            throw new NotImplementedException();
        }
        public Task<TipoDesparacitacionDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
