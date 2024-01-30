using API.Data.Models;

namespace API.DataTransferObjects
{
        public class GetOrderDTO
        {
            public int Id { get; set; }

            public DateTime Date { get; set; }

            public string CustomerName { get; set; } = null!;

            public string CustomerDocumentId { get; set; } = null!;

            public string CustomerPhone { get; set; } = null!;

            public string CustomerEmail { get; set; } = null!;

            public string CustomerAddress { get; set; } = null!;

            public decimal TotalPrice { get; set; }
        }
    }
