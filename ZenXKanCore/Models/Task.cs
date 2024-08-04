namespace ZenXKanCore.Models;

public class Task : BaseEntity
{
    public Task(Guid? parentId, string title, string? description)
    {
        Id = Guid.NewGuid();
        ParentId = parentId;
        Title = title;
        Description = description;
    }

    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }

    public string Title { get; set; }
    public string? Description { get; set; }
    public double ViewOrderId { get; set; }

    public DateTime? CompletedAt { get; set; }

    public Task Parent { get; set; }

    public ICollection<Task> SubTasks { get; } = [];
    public ICollection<Tag> Tags { get; } = [];
    public ICollection<TaskTag> TaskTags { get; set; } = new List<TaskTag>();
}