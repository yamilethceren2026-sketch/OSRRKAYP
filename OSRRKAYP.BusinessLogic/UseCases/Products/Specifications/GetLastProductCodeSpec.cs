using Ardalis.Specification;
using OSRRKAYP.Entities;

namespace OSRRKAYP.BusinessLogic.UseCases.Products.Specifications
{
    internal sealed class GetLastProductCodeSpec : Specification<Product>
    {
        public GetLastProductCodeSpec()
        {
            Query
                .OrderByDescending(p => p.Id)
                .Take(1);
        }
    }
}