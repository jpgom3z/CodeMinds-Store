using API.Data.Models;

namespace API.Services
{
    public interface ICategoryStateService
    {
        IQueryable<CategoryState> ListCategoryStates();
    }
}
