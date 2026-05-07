using MediatR;
using OSRRKAYP.BusinessLogic.DTOs;

namespace OSRRKAYP.BusinessLogic.UseCases.Manufacturers.Commands.UpdateManufacturer;

public record UpdateManufacturerCommand(UpdateManufacturerDto Request) : IRequest<int>;