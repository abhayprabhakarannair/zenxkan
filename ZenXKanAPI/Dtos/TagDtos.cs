namespace ZenXKanAPI.Dtos;

public record TagItemDto(Guid Id, string Name, string Color);

public record TagCreateDto(string Name, string Color);