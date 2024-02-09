namespace API.Data.Filters
{
    public class OrderListFilter
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }  /* DEPEDNE DE RESPUESTA DEL CLIENTE */
        public string? CustomerName { get; set; }
        public string? CustomerDocumentId { get; set; }
        public decimal? TotalPriceFrom { get; set; }
        public decimal? TotalPriceTo { get; set; }
    }
}
