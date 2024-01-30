using API.DataTransferObjects;
namespace API.Validators.ProductValidator
{
    public interface IProductValidator
    {
        bool ValidateInsertUpdate(InsertUpdateProductDTO data, List<string> messges);
    }
}