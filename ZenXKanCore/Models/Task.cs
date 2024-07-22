namespace ZenXKanCore.Models;

public class Task
{
    public Task(Ulid? parentId, string title)
    {
        Id = Ulid.NewUlid();
        ParentId = parentId;
        Title = title;
    }

    public Ulid Id { get; set; }
    public Ulid? ParentId { get; set; }
    public string Title { get; set; }

    public Task Parent { get; set; }
    public ICollection<Task> SubTasks { get; set; }
}