namespace ZenXKanCore.Models;

public class Task
{
    public Task(Ulid projectId, Ulid? parentId, string title)
    {
        Id = Ulid.NewUlid();
        ProjectId = projectId;
        ParentId = parentId;
        Title = title;
    }

    public Ulid Id { get; set; }
    public Ulid? ParentId { get; set; }

    public string Title { get; set; }

    public Task Parent { get; set; }
    public ICollection<Task> SubTasks { get; set; }


    public Ulid ProjectId { get; set; }
    public Project Project { get; set; }
}