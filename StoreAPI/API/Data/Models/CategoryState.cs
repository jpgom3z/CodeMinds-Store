using System;
using System.Collections.Generic;

namespace API.Data.Models;

public partial class CategoryState
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Category> Category { get; set; } = new List<Category>();
}
