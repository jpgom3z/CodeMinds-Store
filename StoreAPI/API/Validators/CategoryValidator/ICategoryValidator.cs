using API.DataTransferObjects;

namespace API.Validators
{
    public interface ICategoryValidator
    {
        bool ValidateInsertUpdate(InsertUpdateCategoryDTO data, List<string> messges);
    }
}