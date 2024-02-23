using API.DataTransferObjects;
namespace API.Validators.ProductValidator
{
    public interface IProductValidator
    {
        bool ValidateInsertUpdate(int? id, InsertUpdateProductDTO data, List<string> messges);
    }
}