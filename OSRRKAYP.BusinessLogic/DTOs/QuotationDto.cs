using System;

namespace OSRRKAYP.BusinessLogic.DTOs
{
    public class QuotationDto
    {
        public long QuotationId { get; set; }

        public string ClientName { get; set; } = string.Empty;

        public string ClientPhone { get; set; } = string.Empty;

        public string SellerName { get; set; } = string.Empty;

        public string PaymentMethodName { get; set; } = string.Empty;

        public long QuotationNumber { get; set; }

        public int ValidityDays { get; set; }

        public DateTime QuotationRegistration { get; set; }

        public bool QuotationStatus { get; set; }

        public decimal Total { get; set; }
    }
}
