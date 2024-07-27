namespace ZenXKanCore.Models;

public class Task : BaseEntity
{
    public Task(Guid? parentId, string title)
    {
        Id = Guid.NewGuid();
        ParentId = parentId;
        Title = title;
    }

    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }

    public string Title { get; set; }

    public Task Parent { get; set; }

    public ICollection<Task> SubTasks { get; } = [];
    public ICollection<Tag> Tags { get; } = [];
    public ICollection<TaskTag> TaskTags { get; set; } = new List<TaskTag>();
}