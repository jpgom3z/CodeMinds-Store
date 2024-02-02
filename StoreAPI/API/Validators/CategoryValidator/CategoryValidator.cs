using API.Data;
using API.DataTransferObjects;

namespace API.Validators
{
    public class CategoryValidator : ICategoryValidator
    {
        private readonly StoreDB _database;
        public CategoryValidator(StoreDB database)
        {
            _database = database;
        }

        public bool ValidateInsertUpdate(InsertUpdateCategoryDTO data, List<string> messages)
        {
            List<string> innerMessages = new();
            // Name validation
            if (string.IsNullOrWhiteSpace(data.Name))
            {
                innerMessages.Add("El nombre de la categoría es requerido");
            }
            else if (data.Name.Length > 50)
            {
                innerMessages.Add("El nombre de la categoría no puede contener más de 50 caracteres");
            }
            messages.AddRange(innerMessages);
            return !innerMessages.Any();
        }
    }
}