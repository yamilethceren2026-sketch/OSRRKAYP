using Mapster;
using MediatR;
using OSRRKAYP.BusinessLogic.DTOs;
using OSRRKAYP.BusinessLogic.UseCases.MusicalInstruments.CreateMusicalInstruments;
using OSRRKAYP.BusinessLogic.UseCases.Products.Commands.CreateProduct;
using OSRRKAYP.DataAccess.Interfaces;
using OSRRKAYP.Entities;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace OSRRKAYP.BusinessLogic.UseCases.MusicalInstrumentsTation.CreateMusicalInstruments
{
    // Handler corregido: inyección por constructor, firma correcta de Handle
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    internal sealed class Product : CreateProductCommandBase, IRequestHandler<Product, long>, ICreateProduct, ICreateProduct1, ICreateProduct2, ICreateProductCommand
    {
        private CancellationToken cancellationToken;
        private IEfRepository<MusicalInstrument> _repository;
        private object request;

        public Product()
        {
        }

        public Product(CancellationToken cancellationToken, IEfRepository<MusicalInstrument> repository, object request)
        {
            this.cancellationToken = cancellationToken;
            _repository = repository;
            this.request = request;
        }

        public long Id { get; internal set; }

        public override bool Equals(object? obj)
        {
            return obj is Product hanler &&
                   cancellationToken.Equals(hanler.cancellationToken) &&
                   EqualityComparer<IEfRepository<MusicalInstrument>>.Default.Equals(_repository, hanler._repository) &&
                   EqualityComparer<object>.Default.Equals(request, hanler.request);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(cancellationToken, _repository, request);
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
