using API.Data.Models;

namespace API.DataTransferObjects
{
    public class GetProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int ProductStateId { get; set; }
        public GetCategoryDTO Category { get; set; } = null;
        public GetProductStateDTO ProductState { get; set; } = null;
    }

    public class InsertUpdateProductDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Stock { get; set; }
        public decimal? Price { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductStateId { get; set; }
    }

    public class FilterProductDTO
    {
        public string? Name { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public int? CategoryId { get; set; }
        public int? ProductStateId { get; set; }
    }
}