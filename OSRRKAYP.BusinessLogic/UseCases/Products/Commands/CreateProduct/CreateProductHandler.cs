using Mapster;
using MediatR;
using OSRRKAYP.DataAccess.Interfaces;
using OSRRKAYP.Entities;

namespace OSRRKAYP.BusinessLogic.UseCases.Products.Commands.CreateProduct
{
    internal sealed class CreateProductHandler
        : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IEfRepository<Product> _repository;

        public CreateProductHandler(IEfRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle
        (
            CreateProductCommand command,
            CancellationToken cancellationToken
        )
        {
            var newProduct = command.Request.Adapt<Product>();

            await _repository.AddAsync(newProduct);

            return (int)newProduct.Id;
        }
    }
}