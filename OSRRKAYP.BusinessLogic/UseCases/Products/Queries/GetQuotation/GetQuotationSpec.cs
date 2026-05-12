using Ardalis.Specification;
using OSRRKAYP.Entities;

namespace OSRRKAYP.BusinessLogic.UseCases.Products.Queries.GetQuotation
{
    internal sealed class GetQuotationQuery
        : Specification<Quotation>
    {
        public GetQuotationQuery (long quotationId)
        {
            Query.Where(q => q.QuotationId == quotationId);
        }
    }
}