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
            //Missing UNIQUENESS validator for Category.Name

            //else if (this._database.Category.Any(c => c.Name == data.Name && c.Id != id))
            //{
            //    innerMessages.Add("Cédula ya está registrada en el sistema");
            //}

            // CategoryState validation
            if (!data.CategoryStateId.HasValue)
            {
                innerMessages.Add("El estado de la categoria es requerido");
            }
            else if (!this._database.Category.Any(c => c.Id == data.CategoryStateId))
            {
                innerMessages.Add("Debe seleccionar un estado de la categoría que esté registrado en el sistema");
            }
            messages.AddRange(innerMessages);
            return !innerMessages.Any();
        }
    }
}