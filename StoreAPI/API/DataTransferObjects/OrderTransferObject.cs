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
            public OrderProduct OrderProduct { get; set; } = null!; /* ¿ES NECESARIO YA QUE ES UN GET? */
        }

    public class InsertOrderDTO
    {
        public DateTime? Date { get; set; }

        public string CustomerName { get; set; } = null!;

        public string CustomerDocumentId { get; set; } = null!;

        public string CustomerPhone { get; set; } = null!;

        public string CustomerEmail { get; set; } = null!;

        public string CustomerAddress { get; set; } = null!;

        public decimal? TotalPrice { get; set; }
        public OrderProduct? OrderProduct { get; set; } = null!; /* ¿ES NECESARIO POR SER UN INSERT? */
    }

    public class FilterOrderDTO
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }  /*SEGÚN RESPUESTA DEL CLIENTE VICTOR */
        public string? CustomerName { get; set; }
        public string? CustomerDocumentId { get; set; }
        public decimal? TotalPriceFrom { get; set; }
        public decimal? TotalPriceTo { get; set; }
    }
}
