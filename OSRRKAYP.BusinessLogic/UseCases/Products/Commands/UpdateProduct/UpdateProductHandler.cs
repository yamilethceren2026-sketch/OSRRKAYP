using MediatR;
using OSRRKAYP.DataAccess.Interfaces;
using OSRRKAYP.Entities;

namespace OSRRKAYP.BusinessLogic.UseCases.Products.Commands.UpdateProduct
{
    internal sealed class UpdateProductHandler
        : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IEfRepository<Product> _repository;

        public UpdateProductHandler(IEfRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle
        (
            UpdateProductCommand command,
            CancellationToken cancellationToken
        )
        {
            var product = await _repository.GetByIdAsync(command.Request.Id);

            if (product == null)
            {
                return 0;
            }

            product.ManufacturerId = command.Request.ManufacturerId;
            product.Name = command.Request.Name;
            product.PublicPrice = command.Request.PublicPrice;
            product.CurrentInventory = command.Request.CurrentInventory;

            await _repository.UpdateAsync(product);

            return (int)product.Id;
        }
    }
}