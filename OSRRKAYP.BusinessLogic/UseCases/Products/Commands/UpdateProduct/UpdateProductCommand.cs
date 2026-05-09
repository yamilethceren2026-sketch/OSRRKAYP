using MediatR;
using OSRRKAYP.BusinessLogic.DTOs;

namespace OSRRKAYP.BusinessLogic.UseCases.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<int>
    {
        public UpdateProductDto Request { get; set; } = null!;
    }
}