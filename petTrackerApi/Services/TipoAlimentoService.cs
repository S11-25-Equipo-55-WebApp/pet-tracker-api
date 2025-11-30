using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Model;
using petTrackerApi.Repository.GenericRepository;
using petTrackerApi.Services.GenericServices;

namespace petTrackerApi.Services
{
    public class TipoAlimentoService : IGenericService<TipoAlimentoDTO>
    {
        private readonly IGenericRepository<TipoAlimento> _repository;

        public TipoAlimentoService(IGenericRepository<TipoAlimento> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<TipoAlimentoDTO>> Get()
        {
            var tipoAlimentos = await _repository.Get();
            return tipoAlimentos.Select(Mapper.TipoAlimentoMapToDTO);
        }

        public async Task<TipoAlimentoDTO> GetById(int id)
        {
            var encuentra = await _repository.GetById(id);
            if (encuentra == null) return null;
            var respuesta = Mapper.TipoAlimentoMapToDTO(encuentra);
            return respuesta;
        }

        public Task<TipoAlimentoDTO> Create(TipoAlimentoDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<TipoAlimentoDTO> Update(int id, TipoAlimentoDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<TipoAlimentoDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }


    }
}
