namespace API.Data.Filters
{
    public class ProductListFilter
    {
        public string? Name { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductStateId { get; set; }
    }
}