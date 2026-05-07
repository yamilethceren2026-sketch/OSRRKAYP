using MediatR;
using OSRRKAYP.BusinessLogic.DTOs;

namespace OSRRKAYP.BusinessLogic.UseCases.Manufacturers.Commands.CreateManufacturer;

public record CreateManufacturerCommand(CreateManufacturerDto Request) : IRequest<int>;