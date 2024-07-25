namespace ZenXKanCore.Models;

public class Project
{
    public Project(string title)
    {
        Id = Ulid.NewUlid();
        Title = title;
    }


    public Ulid Id { get; set; }
    public string Title { get; set; }

    public ICollection<Task> Tasks { get; set; }
}