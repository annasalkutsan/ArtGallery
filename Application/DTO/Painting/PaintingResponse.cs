namespace Application.DTO.User;

public class PaintingResponse
{
    public DateTime CreationDate { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImagePath { get; set; } // Добавляем путь к изображению
    public Guid AuthorId { get; set; }
    public Guid? OrderId { get; set; }
}