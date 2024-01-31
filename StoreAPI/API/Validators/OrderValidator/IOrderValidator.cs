using API.DataTransferObjects;
namespace API.Validators.OrderValidator
{
    public interface IOrderValidator
    {
        bool ValidateInsert(InsertOrderDTO data, List<string> messges);
    }
}