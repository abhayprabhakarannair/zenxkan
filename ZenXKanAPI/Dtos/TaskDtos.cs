namespace ZenXKanAPI.Dtos;

public record TaskItemDto(Guid Id, Guid? ParentId, string Title, IEnumerable<TagItemDto>? Tags = null);

public record TaskCreateDto(Guid? ParentId, string Title, IEnumerable<Guid>? TagIds);

public record TaskUpdateDto(Guid? ParentId, string Title, IEnumerable<Guid>? TagIds);