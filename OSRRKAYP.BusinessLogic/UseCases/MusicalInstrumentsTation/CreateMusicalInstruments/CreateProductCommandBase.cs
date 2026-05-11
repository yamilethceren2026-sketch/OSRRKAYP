using Mapster;
using OSRRKAYP.BusinessLogic.DTOs;
using OSRRKAYP.Entities;

namespace OSRRKAYP.BusinessLogic.UseCases.MusicalInstrumentsTation.CreateMusicalInstruments
{
    internal class CreateProductCommandBase
    {

        public Task<long> Handle(Product request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<long> Handle(Product CancellationToken Product)
        {
            try
            {
                // 1. Iniciamos la transacción para asegurar la integridad de los datos
                await _repository.BeginTransactionAsync();

                // 2. Mapeamos el DTO del comando a la Entidad usando Mapster
                var newInstrument = request.Adapt<MusicalInstrument>();

                // 3. Persistimos en la base de datos
                var createdInstrument = await _repository.AddAsync(newInstrument, cancellationToken);

                // 4. Confirmamos los cambios
                await _repository.CommitAsync();

                // 5. Retornamos el ID generado (propiedad 'Id' según la entidad)
                return createdInstrument.Id;
            }
            catch
            {
                // Si algo falla, revertimos cualquier cambio pendiente
                await _repository.RollbackAsync();
                throw;
            }
        }
    }
}