namespace App.Application.Entities.Common;

public interface IAuditEntity
{
    DateTime Created { get; set; }
    DateTime? Updated { get; set; }
}
