using Domain.Primitives;

namespace Application.DTO.User;

public class AuthorCreateRequest
{
    public int NumberOfWorks { get; set; }
    public string? Description { get; set; }
    public FullName FullName { get; set; }
}