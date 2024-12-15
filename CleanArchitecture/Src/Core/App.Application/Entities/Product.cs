﻿using App.Application.Entities.Common;

namespace App.Application.Entities.Products;

public class Product : BaseEntity<int>, IAuditEntity
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = default!;
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}