using Domain.Primitives;

namespace Application.DTO.User;

public class AuthorUpdateRequest
{
    public Guid Id { get; set; }
    public int? NumberOfWorks { get; set; } 
    public string? Description { get; set; }
    public FullName FullName { get; set; }
}