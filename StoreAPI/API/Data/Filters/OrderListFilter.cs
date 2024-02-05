namespace API.Data.Filters
{
    public class OrderListFilter
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string CustomerDocumentId { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public decimal? TotalPriceFrom { get; set; }
        public decimal? TotalPriceTo { get; set; }
    }
}
