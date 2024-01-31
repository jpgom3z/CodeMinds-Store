using System;
using System.Collections.Generic;

namespace API.Data.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerDocumentId { get; set; } = null!;

    public string CustomerPhone { get; set; } = null!;

    public string CustomerEmail { get; set; } = null!;

    public string CustomerAddress { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public virtual ICollection<OrderProduct> OrderProduct { get; set; } = new List<OrderProduct>();
}
