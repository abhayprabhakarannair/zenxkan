namespace ZenXKanCore.Models;

public class Tag : BaseEntity
{
    public Tag(string name, string color)
    {
        Id = new Guid();
        Name = name;
        Color = color;
    }


    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }


    public ICollection<Task> Tasks { get; } = [];
    public ICollection<TaskTag> TaskTags { get; } = [];
}