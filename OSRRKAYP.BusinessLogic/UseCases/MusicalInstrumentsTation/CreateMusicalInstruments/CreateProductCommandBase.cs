using Mapster;
using OSRRKAYP.Entities;
using OSRRKAYP.DataAccess.Interfaces;

namespace OSRRKAYP.BusinessLogic.UseCases.MusicalInstrumentsTation.CreateMusicalInstruments
{
    internal class CreateProductCommandBase : ICreateProduct
    {
        private readonly IEfRepository<Product> _repository;

        public CreateProductCommandBase(IEfRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<long> Handle(Product request, CancellationToken cancellationToken)
        {
            try
            {
                // Iniciar transacción
                await _repository.BeginTransactionAsync();

                // Mapear entidad
                var newProduct = request.Adapt<Product>();

                // Guardar en base de datos
                var createdProduct = await _repository.AddAsync(newProduct, cancellationToken);

                // Confirmar cambios
                await _repository.CommitAsync();

                // Retornar ID generado
                return createdProduct.Id;
            }
            catch
            {
                // Revertir cambios si ocurre un error
                await _repository.RollbackAsync();
                throw;
            }
        }
    }
}