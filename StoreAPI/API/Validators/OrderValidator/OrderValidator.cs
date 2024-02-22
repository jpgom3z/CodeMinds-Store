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

        public bool ValidateInsert(OrderRequest data, List<string> messages)
        {
            List<string> innerMessages = new();

            // Extraer Order
            InsertOrderDTO? order = data.OrderData;

            // Extraer la lista que contiene los productos 
            List<InsertOrderProductDTO>? orderProductsList = data.OrderProductData;

            // Date validator
            if (!order.Date.HasValue)
            {
                innerMessages.Add("La fecha de la orden de compra es requerida");
            }
            else if (order.Date < DateTime.Now)
            {
                innerMessages.Add("La fecha de la orden de compra no puede ser anterior a la fecha actual");
            }
            // CustomerName validator
            if (string.IsNullOrWhiteSpace(order.CustomerName))
            {
                innerMessages.Add("El nombre del cliente es requerido");
            }
            else if (order.CustomerName.Length > 100)
            {
                innerMessages.Add("El nombre del cliente no puede contener más de 100 caracteres");
            }
            // CustomerPhone validator
            if (string.IsNullOrWhiteSpace(order.CustomerPhone))
            {
                innerMessages.Add("El número de teléfono del cliente es requerido");
            }
            else if (order.CustomerPhone.Trim().Length != 8)
            {
                innerMessages.Add("El número de teléfono del cliente debe contener 8 digitos");
            }
            else if (!int.TryParse(order.CustomerPhone, out int num) || num < 0)
            {
                innerMessages.Add("El número de teléfono sólo puede contener números");
            }
            // CustomerEmail validator
            if (string.IsNullOrWhiteSpace(order.CustomerEmail))
            {
                innerMessages.Add("El email del cliente es requerido");
            }
            else if (order.CustomerName.Length > 255)
            {
                innerMessages.Add("El email del cliente no puede contener más de 50 caracteres");
            }
            // CustomerAddress validator
            if (string.IsNullOrWhiteSpace(order.CustomerAddress))
            {
                innerMessages.Add("La dirección del cliente es requerida");
            }
            else if (order.CustomerName.Length > 255)
            {
                innerMessages.Add("La dirección del cliente no puede contener más de 255 caracteres");
            }
            // TotalPrice validator
            if (!order.TotalPrice.HasValue)
            {
                innerMessages.Add("El precio total es requerido");
            }
            else if (order.TotalPrice < 0)
            {
                innerMessages.Add("El precio total debe ser mayor o igual a 0");
            }

            //PURCHASEPRODUCT VALIDATORS:
            //La lista no puede ser = null o estar sin elementos. 
            if (orderProductsList == null || !orderProductsList.Any())
            {
                innerMessages.Add("La lista de productos de compra está vacía. Debe contener al menos un producto.");
            }
            else
            {
                foreach (var orderProductItem in orderProductsList)
                {
                    // purchaseProduct.Quantity
                    if (!orderProductItem.Quantity.HasValue)
                    {
                        innerMessages.Add("La cantidad del producto es requerida");
                    }
                    else if (orderProductItem.Quantity <= 0)
                    {
                        innerMessages.Add("La cantidad del producto debe ser mayor a 0");
                    }

                    //purchaseProduct.TotalPrice
                    if (!orderProductItem.TotalPrice.HasValue)
                    {
                        innerMessages.Add("El precio total de la transaccion es requerido");
                    }
                    else if (orderProductItem.TotalPrice <= 0)
                    {
                        innerMessages.Add("El precio total del producto debe ser mayor a 0");
                    }

                    // purchaseProduct.ProductId
                    if (!orderProductItem.ProductId.HasValue)
                    {
                        innerMessages.Add("El ID del producto es requerido");
                    }
                    else if (!this._database.Product.Any(P => P.Id == orderProductItem.ProductId))
                    {
                        innerMessages.Add("Debe seleccionar un producto que este registrado en el sistema");
                    }
                }
            };

            messages.AddRange(innerMessages);
            return !innerMessages.Any();
        }
    }
}