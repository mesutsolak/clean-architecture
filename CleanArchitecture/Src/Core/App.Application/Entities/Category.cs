using App.Application.Entities.Common;
using App.Application.Entities.Products;

namespace App.Application.Entities;

public class Category : BaseEntity<int>, IAuditEntity
{
    public string Name { get; set; } = default!;
    public List<Product>? Products { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}