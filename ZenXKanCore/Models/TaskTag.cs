namespace ZenXKanCore.Models;

public class TaskTag : BaseEntity
{
    public Guid TaskId { get; set; }
    public Guid TagId { get; set; }
}