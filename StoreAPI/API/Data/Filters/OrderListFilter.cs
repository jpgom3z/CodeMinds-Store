namespace API.Data.Filters
{
    public class OrderListFilter
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal? TotalPriceFrom { get; set; }
        public decimal? TotalPriceTo { get; set; }
    }
}
