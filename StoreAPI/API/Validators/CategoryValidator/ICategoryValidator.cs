using API.DataTransferObjects;

namespace API.Validators
{
    public interface ICategoryValidator
    {
        bool ValidateInsertUpdate(int? id, InsertUpdateCategoryDTO data, List<string> messages);
    }
}