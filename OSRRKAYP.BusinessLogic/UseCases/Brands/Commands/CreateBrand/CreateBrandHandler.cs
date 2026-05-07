using MediatR;
using Mapster;
using OSRRKAYP.DataAccess.Interfaces;
using OSRRKAYP.Entities;

namespace OSRRKAYP.BusinessLogic.UseCases.Manufacturers.Commands.CreateManufacturer;

internal sealed class CreateManufacturerHandler
    (IEfRepository<Manufacturer> _repository)
    : IRequestHandler<CreateManufacturerCommand, int>
{
    public async Task<int> Handle(CreateManufacturerCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var newManufacturer = command.Request.Adapt<Manufacturer>();

            var createdManufacturer = await _repository.AddAsync(newManufacturer, cancellationToken);

            return createdManufacturer.Id;
        }
        catch (Exception)
        {
            return 0;
        }
    }
}