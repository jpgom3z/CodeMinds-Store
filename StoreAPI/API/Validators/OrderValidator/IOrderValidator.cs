using API.DataTransferObjects;
namespace API.Validators.OrderValidator
{
    public interface IOrderValidator
    {
        bool ValidateInsert(OrderRequest data, List<string> messges);
    }
}