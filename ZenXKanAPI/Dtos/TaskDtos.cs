namespace ZenXKanAPI.Dtos;

public record TaskItemDto(Guid Id, Guid? ParentId, string Title);

public record TaskCreateDto(Guid? ParentId, string Title);