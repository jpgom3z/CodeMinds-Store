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

        public class OrderRequest
        {
            public InsertOrderDTO? OrderData { get; set; }
            public List<InsertOrderProductDTO>? OrderProductData { get; set; }
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
    public class InsertOrderProductDTO
    {
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
    }

    public class FilterOrderDTO
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerDocumentId { get; set; }
        public decimal? TotalPriceFrom { get; set; }
        public decimal? TotalPriceTo { get; set; }
    }
}
