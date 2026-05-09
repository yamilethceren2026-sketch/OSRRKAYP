using MediatR;
using OSRRKAYP.BusinessLogic.DTOs;

namespace OSRRKAYP.BusinessLogic.UseCases.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public CreateProductDto Request { get; set; } = null!;
    }
}