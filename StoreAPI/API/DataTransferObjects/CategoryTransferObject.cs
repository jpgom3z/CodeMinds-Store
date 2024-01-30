using API.Data.Models;

namespace API.DataTransferObjects
{
    public class GetCategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public GetCategoryStateDTO CategoryState { get; set; } = null!;
    }

    public class InsertUpdateCategoryDTO
    {
        public string? Name { get; set; }
        public int? CategoryStateId { get; set; }
    }
}
