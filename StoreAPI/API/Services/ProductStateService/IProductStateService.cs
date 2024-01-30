using API.Data.Models;
namespace API.Services
{
    public interface IProductStateService
    {
        IQueryable<ProductState> ListProductStates();
    }
}