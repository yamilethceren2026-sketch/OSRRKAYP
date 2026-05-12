using System;
using System.Collections.Generic;
using System.Text;

namespace OSRRKAYP.BusinessLogic.DTOs
{
    public class QuotationDto
    {
        public long QuotationId { get; set; }

        public string? ClientName { get; set; }

        public string? ClientPhone { get; set; }

        public string? SellerName { get; set; }

        public string? PaymentMethodName { get; set; }

        public long? QuotationNumber { get; set; }

        public int? ValidityDays { get; set; }

        public DateTime? QuotationRegistration { get; set; }

        public bool QuotationStatus { get; set; }

        public decimal? Total { get; set; }
    }
}
