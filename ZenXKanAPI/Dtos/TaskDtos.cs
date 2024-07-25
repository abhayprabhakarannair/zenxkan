using System.ComponentModel.DataAnnotations;

namespace ZenXKanAPI.Dtos;

public record TaskItemDto(Ulid Id, Ulid ProjectId, Ulid? ParentId, string Title);

public record TaskCreateDto([Required] Ulid ProjectId, Ulid? ParentId, [Required] string Title);