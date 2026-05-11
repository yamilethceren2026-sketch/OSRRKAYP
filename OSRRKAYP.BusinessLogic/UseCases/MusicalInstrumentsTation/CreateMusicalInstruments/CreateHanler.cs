using Mapster;
using MediatR;
using OSRRKAYP.BusinessLogic.DTOs;
using OSRRKAYP.BusinessLogic.UseCases.MusicalInstruments.CreateMusicalInstruments;
using OSRRKAYP.BusinessLogic.UseCases.Products.Commands.CreateProduct;
using OSRRKAYP.DataAccess.Interfaces;
using OSRRKAYP.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OSRRKAYP.BusinessLogic.UseCases.MusicalInstrumentsTation.CreateMusicalInstruments
{
    // Handler corregido: inyección por constructor, firma correcta de Handle
    internal sealed class CreateHanler : CreateProductCommandBase, IRequestHandler<CreateHanler, long>, ICreateProduct, ICreateProduct1, ICreateProduct2, ICreateProductCommand
    {
        private CancellationToken cancellationToken;
        private IEfRepository<MusicalInstrument> _repository;
        private object request;


        public CreateHanler(CancellationToken cancellationToken, IEfRepository<MusicalInstrument> repository, object request)
        {
            this.cancellationToken = cancellationToken;
            _repository = repository;
            this.request = request;
        }

        public async Task<long> Handle(CreateHanler CancellationToken CreateHanler)
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
