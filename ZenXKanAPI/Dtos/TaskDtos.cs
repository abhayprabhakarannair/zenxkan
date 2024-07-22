namespace ZenXKanAPI.Dtos;

public record TaskItemDto(Ulid Id, Ulid? ParentId, string Title);

public record TaskCreateDto(Ulid? ParentId, string Title);