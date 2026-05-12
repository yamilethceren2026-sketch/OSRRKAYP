using Ardalis.Specification;
using OSRRKAYP.Entities;

namespace OSRRKAYP.BusinessLogic.UseCases.Products.Queries.GetQuotation
{
    internal class GetQuotationSpec : Specification<Quotation>
    {
        public GetQuotationSpec(long quotationId)
        {
            Query.Where(q => q.QuotationId == quotationId);
        }
    }
}
