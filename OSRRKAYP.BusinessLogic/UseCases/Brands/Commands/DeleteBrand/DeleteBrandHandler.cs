using OSRRKAYP.DataAccess.Interfaces;
using OSRRKAYP.Entities;
using MediatR;

namespace OSRRKAYP.BusinessLogic.UseCases.Manufacturers.Commands.DeleteManufacturer;

internal sealed class DeleteManufacturerHandler(IEfRepository<Manufacturer> _repository)
    : IRequestHandler<DeleteManufacturerCommand, int>
{
    public async Task<int> Handle(DeleteManufacturerCommand command, CancellationToken cancellationToken)
    {
        var existingManufacturer = await _repository.GetByIdAsync(command.Id);

        if (existingManufacturer is null) return 0;

        await _repository.DeleteAsync(existingManufacturer, cancellationToken);

        return existingManufacturer.Id;
    }
}