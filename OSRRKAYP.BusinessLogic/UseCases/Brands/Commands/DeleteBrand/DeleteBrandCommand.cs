using MediatR;

namespace OSRRKAYP.BusinessLogic.UseCases.Manufacturers.Commands.DeleteManufacturer;

public record DeleteManufacturerCommand(int Id) : IRequest<int>;