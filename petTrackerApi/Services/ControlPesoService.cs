using petTrackerApi.Data;
using petTrackerApi.DTO;
using petTrackerApi.Helpers;
using petTrackerApi.Model;
using petTrackerApi.Repository.IRepository;
using petTrackerApi.Services.IServices;

namespace petTrackerApi.Services
{
    public class ControlPesoService : IControlPesoService
    {
        private readonly IControlPesoRepository _repository;
        public ControlPesoService(IControlPesoRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ControlPesoDTO>> Get()
        {
             var controlPesos = await _repository.Get();
            return controlPesos.Select(Mapper.ControlPesoMapToDTO);
        }

        public async Task<ControlPesoDTO> GetById(int id)
        {
            var encuentra = await _repository.GetById(id);
            if (encuentra == null) return null;
            var respuesta = Mapper.ControlPesoMapToDTO(encuentra);
            return respuesta;
        }

        public async Task<ControlPesoDTO> Create(ControlPesoDTO dtoControlPeso)
        {
            var mapControl= Mapper.ControlPesoDTOMapToEntity(dtoControlPeso);
            mapControl.CreadoAt = DateTime.Now;
            mapControl.EditadoAt = DateTime.Now;
            mapControl.Codigo = CodeGenerator.GenerarCodigoDobleFechaDateTime(mapControl.MascotaId, mapControl.CreadoAt, mapControl.EditadoAt);

            var controlCreado = await _repository.Create(mapControl);
            var controlResult = Mapper.ControlPesoMapToDTO(controlCreado);
            return controlResult;
        }

        public async Task<ControlPesoDTO> Update(int id, ControlPesoDTO dtoControlPeso)
        {
            var controlDB = await _repository.GetById(id);
            if (controlDB == null) return null;

            controlDB.Codigo = CodeGenerator.GenerarCodigoDobleFechaDateTime(controlDB.MascotaId, controlDB.CreadoAt, controlDB.EditadoAt);
            controlDB.Peso = dtoControlPeso.Peso;
            controlDB.Notas = dtoControlPeso.Notas; 
            controlDB.MascotaId = dtoControlPeso.MascotaId;
            controlDB.UnidadMedidaId = dtoControlPeso.UnidadMedidaId;
            controlDB.EditadoAt = DateTime.Now;

            var actualizado = await _repository.Update(controlDB);
            return actualizado == null ? null : Mapper.ControlPesoMapToDTO(actualizado);
        }

        public async Task<ControlPesoDTO> Delete(int id)
        {
            var controlEncontrado = await _repository.GetById(id);
            if (controlEncontrado == null) return null;

            await _repository.Delete(controlEncontrado);

            return Mapper.ControlPesoMapToDTO(controlEncontrado);
        }

        public async Task<IEnumerable<ControlPesoDTO>> GetControlPesoByIdMascota(int id)
        {
            var listado = await _repository.GetControlPesoByIdMascota(id);
            return listado.Select(Mapper.ControlPesoMapToDTO);
        }
    }
}
