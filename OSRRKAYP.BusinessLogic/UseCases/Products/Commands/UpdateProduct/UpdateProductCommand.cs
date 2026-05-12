using MediatR;
using OSRRKAYP.BusinessLogic.DTOs;

namespace OSRRKAYP.BusinessLogic.UseCases.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<int>
    {
        public UpdateProductCommand(OSRRKAYP.WebApplication.Controllers.UpdateProductRequest updateProductRequest)
        {
            UpdateProductRequest = updateProductRequest;
        }

        public UpdateProductDto Request { get; set; } = null!;
        public OSRRKAYP.WebApplication.Controllers.UpdateProductRequest UpdateProductRequest { get; }
    }
}