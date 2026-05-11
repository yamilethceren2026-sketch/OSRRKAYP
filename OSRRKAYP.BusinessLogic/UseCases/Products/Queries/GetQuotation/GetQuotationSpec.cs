namespace OSRRKAYP.BusinessLogic.UseCases.Products.Queries.GetQuotation
{
    internal class GetQuotationSpec : Ardalis.Specification.ISpecification<Quotation>
    {
        private long quotationId;

        public GetQuotationSpec(long quotationId)
        {
            this.quotationId = quotationId;
        }
    }
}