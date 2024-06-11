using Domain.Primitives;

namespace Application.DTO.User;

public class AuthorResponse
{
    public DateTime CreationDate { get; set; }
    public Guid Id { get; set; }
    public FullName FullName { get; set; }
    public int NumberOfWorks { get; set; }
    public string? Description { get; set; }
   
}