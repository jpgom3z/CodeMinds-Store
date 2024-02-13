using API.Data;
using API.DataTransferObjects;
namespace API.Validators.ProductValidator
{
    public class ProductValidator : IProductValidator
    {
        private readonly StoreDB _database;

        public ProductValidator(StoreDB database)
        {
            _database = database;
        }

        public bool ValidateInsertUpdate(int? id, InsertUpdateProductDTO data, List<string> messages)
        {
            List<string> innerMessages = new();

            // Name validator
            if (string.IsNullOrWhiteSpace(data.Name))
            {
                innerMessages.Add("El nombre del producto es requerido");
            }
            else if (data.Name.Length > 50)
            {
                innerMessages.Add("El nombre del producto no puede contener más de 50 caracteres");
            }
            else if (this._database.Product.Any(p =>  p.Name == data.Name && p.Id != id)) 
            {
                innerMessages.Add("El nombre del producto ya existe en el sistema");
            }
            //Missing UNIQUENESS validator for Category.Name

            //else if (this._database.Category.Any(c => c.Name == data.Name && c.Id != id))
            //{
            //    innerMessages.Add("Cédula ya está registrada en el sistema");
            //}

            // Description validator
            if (string.IsNullOrWhiteSpace(data.Description))
            {
                innerMessages.Add("La descripción del producto es requerida");
            }
            else if (data.Description.Length > 255)
            {
                innerMessages.Add("La descripción del producto no puede contener más de 255 caracteres");
            }
            // Stock validator
            if (!data.Stock.HasValue)
            {
                innerMessages.Add("La cantidad del producto es requerida");
            }
            else if (data.Stock < 0)
            {
                innerMessages.Add("La cantidad del producto debe ser mayor o igual a 0");
            }
            // Price validator
            if (!data.Price.HasValue)
            {
                innerMessages.Add("Precio del producto es requerido");
            }
            else if (data.Price < 0)
            {
                innerMessages.Add("Precio del producto debe ser mayor o igual a 0");
            }
            // Category validator
            if (!data.CategoryId.HasValue)
            {
                innerMessages.Add("Categoría es requerida");
            }
            else if (!_database.Product.Any(c => c.Id == data.CategoryId))
            {
                innerMessages.Add("Debe seleccionar una categoría que esté registrada en el sistema");
            }
            // ProductState validator eliminado
            messages.AddRange(innerMessages);
            return !innerMessages.Any();
        }
    }
}