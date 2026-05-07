using OSRRKAYP.DataAccess.Interfaces;
using OSRRKAYP.Entities;
using Mapster;
using MediatR;

namespace OSRRKAYP.BusinessLogic.UseCases.Manufacturers.Commands.UpdateManufacturer;

internal sealed class UpdateManufacturerHandler(IEfRepository<Manufacturer> _repository)
    : IRequestHandler<UpdateManufacturerCommand, int>
{
    public async Task<int> Handle(UpdateManufacturerCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var existingManufacturer = await _repository.GetByIdAsync(command.Request.Id);

            if (existingManufacturer is null) return 0;

            existingManufacturer = command.Request.Adapt(existingManufacturer);

            await _repository.UpdateAsync(existingManufacturer, cancellationToken);

            return existingManufacturer.Id;
        }
        catch (Exception)
        {
            return 0;
        }
    }
}