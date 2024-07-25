using System.ComponentModel.DataAnnotations;

namespace ZenXKanAPI.Dtos;

public record ProjectItemDto(Ulid Id, string Title);

public record ProjectCreateDto([Required] string Title);