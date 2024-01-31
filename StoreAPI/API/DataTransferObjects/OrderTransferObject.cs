using API.Data.Models;

namespace API.DataTransferObjects
{
        public class GetOrderDTO
        {
            public int Id { get; set; }

            public DateTime Date { get; set; }

            public string CustomerName { get; set; } = null!;

            public string CustomerDocumentId { get; set; } = null!;

            public string CustomerPhone { get; set; } = null!;

            public string CustomerEmail { get; set; } = null!;

            public string CustomerAddress { get; set; } = null!;

            public decimal TotalPrice { get; set; }
        }

    public class InsertOrderDTO
    {
        public DateTime? Date { get; set; }

        public string CustomerName { get; set; } = null!;

        public string CustomerDocumentId { get; set; } = null!;

        public string CustomerPhone { get; set; } = null!;

        public string CustomerEmail { get; set; } = null!;

        public string CustomerAddress { get; set; } = null!;

        public decimal? TotalPrice { get; set; }
    }

    public class FilterOrderDTO
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal? TotalPriceFrom { get; set; }
        public decimal? TotalPriceTo { get; set; }
    }
}
