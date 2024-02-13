using API.Data;
using API.DataTransferObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace API.Validators.OrderValidator
{
    public class OrderValidator : IOrderValidator
    {
        private readonly StoreDB _database;

        public OrderValidator(StoreDB database)
        {
            _database = database;
        }

        public bool ValidateInsert(InsertOrderDTO data, List<string> messages)
        {
            List<string> innerMessages = new();

            // Date validator
            if (!data.Date.HasValue)
            {
                innerMessages.Add("La fecha de la orden de compra es requerida");
            }
            else if (data.Date < DateTime.Now)
            {
                innerMessages.Add("La fecha de la orden de compra no puede ser anterior a la fecha actual");
            }
            // CustomerName validator
            if (string.IsNullOrWhiteSpace(data.CustomerName))
            {
                innerMessages.Add("El nombre del cliente es requerido");
            }
            else if (data.CustomerName.Length > 50)
            {
                innerMessages.Add("El nombre del cliente no puede contener más de 50 caracteres");
            }
            // CustomerPhone validator
            if (string.IsNullOrWhiteSpace(data.CustomerPhone))
            {
                innerMessages.Add("El número de teléfono del cliente es requerido");
            }
            else if (data.CustomerPhone.Trim().Length != 8)
            {
                innerMessages.Add("El número de teléfono del cliente debe contener 8 digitos");
            }
            else if (!int.TryParse(data.CustomerPhone, out int num) || num < 0)
            {
                innerMessages.Add("El número de teléfono sólo puede contener números");
            }
            // CustomerEmail validator
            if (string.IsNullOrWhiteSpace(data.CustomerEmail))
            {
                innerMessages.Add("El email del cliente es requerido");
            }
            else if (data.CustomerName.Length > 255)
            {
                innerMessages.Add("El email del cliente no puede contener más de 50 caracteres");
            }
            // CustomerAddress validator
            if (string.IsNullOrWhiteSpace(data.CustomerAddress))
            {
                innerMessages.Add("La dirección del cliente es requerida");
            }
            else if (data.CustomerName.Length > 255)
            {
                innerMessages.Add("La dirección del cliente no puede contener más de 255 caracteres");
            }
            // TotalPrice validator
            if (!data.TotalPrice.HasValue)
            {
                innerMessages.Add("El precio total es requerido");
            }
            else if (data.TotalPrice < 0)
            {
                innerMessages.Add("El precio total debe ser mayor o igual a 0");
            }
            messages.AddRange(innerMessages);
            return !innerMessages.Any();
        }
    }
}